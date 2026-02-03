using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;

using SMS.Utilities;

using SMS.Services;
using SMS.Data;
using SMS.Data.Entities;
using SMS.Session;

namespace SMS
{
    public partial class AdminDashboard : Form
    {
        private class UserGridRow
        {
            public int Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Email { get; set; }
            public string Role { get; set; }
            public DateTime CreatedAt { get; set; }
        }

        private SMSDbContext db;

        public AdminDashboard()
        {
            InitializeComponent();
            this.db = SchoolContextFactory.Create();

            // UX: Replace the old multi-step user creation flow (inline email/password/role + extra popups)
            // with a single "Add User" button that opens one form.
            ConfigureAddUserUx();
            RemoveStudentAndTeacherTabs();
            LoadDashboardData();
        }

        private void ConfigureAddUserUx()
        {
            // Hide old inline inputs; keep the structure/files intact.
            if (txtEmail != null) txtEmail.Visible = false;
            if (txtPassword != null) txtPassword.Visible = false;
            if (comboBoxRole != null) comboBoxRole.Visible = false;

            // Labels are designer-created (label1/label2/label3) for Email/Password/Role.
            if (label1 != null) label1.Visible = false;
            if (label2 != null) label2.Visible = false;
            if (label3 != null) label3.Visible = false;

            // Make the remaining UI look intentional.
            if (groupBox1 != null)
            {
                groupBox1.Text = "Create User";
                groupBox1.Height = 90;
            }

            if (btnAddUser != null)
            {
                btnAddUser.Text = "Add User";
                btnAddUser.Width = 180;
                btnAddUser.Height = 40;
                btnAddUser.Left = 20;
                btnAddUser.Top = 30;
            }
        }

        private void LoadDashboardData()
        {
            try
            {
                ConfigureUsersGrid();

                var users = db.Users.ToList();

                // Build lookup dictionaries
                var teachersByUserId = db.Teachers
                    .ToList()
                    .ToDictionary(t => t.UserId, t => t);

                var studentsByUserId = db.Students
                    .ToList()
                    .ToDictionary(s => s.UserId, s => s);

                var usersGrid = users.Select(u =>
                {
                    string firstName = "";
                    string lastName = "";

                    if (u.Role == "Teacher" && teachersByUserId.ContainsKey(u.Id))
                    {
                        firstName = teachersByUserId[u.Id].FirstName;
                        lastName = teachersByUserId[u.Id].LastName;
                    }
                    else if (u.Role == "Student" && studentsByUserId.ContainsKey(u.Id))
                    {
                        firstName = studentsByUserId[u.Id].FirstName;
                        lastName = studentsByUserId[u.Id].LastName;
                    }

                    return new
                    {
                        u.Id,
                        FirstName = firstName,
                        LastName = lastName,
                        u.Email,
                        u.Role,
                        u.CreatedAt
                    };
                }).ToList();

                dataGridViewUsers.DataSource = usersGrid;

                // Safety: hide Username if it exists
                if (dataGridViewUsers.Columns["Username"] != null)
                    dataGridViewUsers.Columns["Username"].Visible = false;

                // Column order
                dataGridViewUsers.Columns["Id"].DisplayIndex = 0;
                dataGridViewUsers.Columns["FirstName"].DisplayIndex = 1;
                dataGridViewUsers.Columns["LastName"].DisplayIndex = 2;
                dataGridViewUsers.Columns["Email"].DisplayIndex = 3;
                dataGridViewUsers.Columns["Role"].DisplayIndex = 4;
                dataGridViewUsers.Columns["CreatedAt"].DisplayIndex = 5;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading users: {ex.Message}");
            }
        }


        private void btnDeleteUser_Click(object sender, EventArgs e)
        {
            if (dataGridViewUsers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select a user first.");
                return;
            }

            int userId = Convert.ToInt32(dataGridViewUsers.SelectedRows[0].Cells["Id"].Value);

            var user = db.Users.FirstOrDefault(u => u.Id == userId);
            if (user == null)
            {
                MessageBox.Show("User not found.");
                return;
            }

            // Optional: prevent deleting yourself
            // if (SessionManager.CurrentUser != null && SessionManager.CurrentUser.Id == userId)
            // {
            //     MessageBox.Show("You cannot delete the account you are currently logged in with.");
            //     return;
            // }

            var confirm = MessageBox.Show($"Delete user {user.Email}?", "Confirm", MessageBoxButtons.YesNo);
            if (confirm != DialogResult.Yes) return;

            try
            {
                using (var tx = db.Database.BeginTransaction())
                {
                    // If this user is a Teacher -> delete Enrollments for their Courses, then Courses, then Teacher row
                    var teacher = db.Teachers.FirstOrDefault(t => t.UserId == userId);
                    if (teacher != null)
                    {
                        var teacherCourseIds = db.Courses
                            .Where(c => c.TeacherId == teacher.Id)
                            .Select(c => c.Id)
                            .ToList();

                        if (teacherCourseIds.Any())
                        {
                            var enrollmentsToRemove = db.Enrollments
                                .Where(e1 => teacherCourseIds.Contains(e1.CourseId))
                                .ToList();

                            db.Enrollments.RemoveRange(enrollmentsToRemove);

                            var coursesToRemove = db.Courses
                                .Where(c => teacherCourseIds.Contains(c.Id))
                                .ToList();

                            db.Courses.RemoveRange(coursesToRemove);
                        }

                        db.Teachers.Remove(teacher);
                    }

                    // If this user is a Student -> delete Enrollments, then Student row
                    var student = db.Students.FirstOrDefault(s => s.UserId == userId);
                    if (student != null)
                    {
                        var studentEnrollments = db.Enrollments
                            .Where(e1 => e1.StudentId == student.Id)
                            .ToList();

                        db.Enrollments.RemoveRange(studentEnrollments);
                        db.Students.Remove(student);
                    }

                    // Finally delete the user
                    db.Users.Remove(user);

                    db.SaveChanges();
                    tx.Commit();
                }

                MessageBox.Show("User deleted successfully.");
                LoadDashboardData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Delete failed. This usually happens because the user still has related records.\n\n" +
                    $"Details: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }


        private void HideUsersGridColumn(string columnName)
        {
            if (dataGridViewUsers.Columns[columnName] != null)
                dataGridViewUsers.Columns[columnName].Visible = false;
        }

        private void btnEditUser_Click(object sender, EventArgs e)
        {
            if (dataGridViewUsers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a user row first.", "Edit User",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int userId = Convert.ToInt32(dataGridViewUsers.SelectedRows[0].Cells["Id"].Value);

            using (var frm = new EditUserForm(db, userId))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    LoadDashboardData();
                }
            }
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            using (var form = new AddUserForm())
            {
                if (form.ShowDialog() != DialogResult.OK)
                    return;

                try
                {
                    string email = form.Email.Trim();
                    string password = form.Password;
                    string passwordHash = Utilities.PasswordHasher.Sha256(password);
                    string role = form.Role;

                    // Check if email already exists
                    if (db.Users.Any(u => u.Email == email))
                    {
                        MessageBox.Show("Email already exists!", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Create base user (legacy DB stores password as-is).
                    var user = new User
                    {
                        Username = email.Contains("@") ? email.Split('@')[0] : email,
                        Email = email,
                        Password = passwordHash,
                        Role = role,
                        IsActive = true,
                        CreatedAt = DateTime.Now
                    };

                    db.Users.Add(user);
                    db.SaveChanges();

                    // Create related profile record when needed.
                    if (role == "Teacher")
                    {
                        db.Teachers.Add(new Teacher
                        {
                            FirstName = form.FirstName,
                            LastName = form.LastName,
                            Email = email,
                            Department = form.Department,
                            UserId = user.Id
                        });
                        db.SaveChanges();
                    }
                    else if (role == "Student")
                    {
                        db.Students.Add(new Student
                        {
                            FirstName = form.FirstName,
                            LastName = form.LastName,
                            Email = email,
                            EnrollmentDate = DateTime.Now,
                            UserId = user.Id
                        });
                        db.SaveChanges();
                    }

                    MessageBox.Show($"{role} created successfully!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LoadDashboardData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error adding user: {ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnAddTeacher_Click(object sender, EventArgs e)
        {
            using (var form = new AddTeacherForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        var user = new User
                        {
                            Username = form.Email.Contains("@") ? form.Email.Split('@')[0] : form.Email,
                            Email = form.Email,
                            Password = form.Password,
                            Role = "Teacher",
                            IsActive = true,
                            CreatedAt = DateTime.Now
                        };

                        db.Users.Add(user);
                        db.SaveChanges();

                        var teacher = new Teacher
                        {
                            FirstName = form.FirstName,
                            LastName = form.LastName,
                            Email = form.Email,
                            Department = form.Department,
                            UserId = user.Id
                        };

                        db.Teachers.Add(teacher);
                        db.SaveChanges();

                        MessageBox.Show($"Teacher created successfully!\n\nLogin with:\nEmail: {form.Email}\nPassword: (what you entered)",
                            "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadDashboardData();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error creating teacher: {ex.Message}",
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnAddCourse_Click(object sender, EventArgs e)
        {
            using (var form = new AddCourseForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        var course = new Course
                        {
                            CourseName = form.CourseName,
                            CourseCode = form.CourseCode,
                            Description = form.Description,
                            TeacherId = form.TeacherId,
                            CreatedDate = DateTime.Now
                        };
                        db.Courses.Add(course);
                        db.SaveChanges();

                        MessageBox.Show("Course created successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadDashboardData();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error creating course: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnAssignCourse_Click(object sender, EventArgs e)
        {
            using (var form = new AssignCourseForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadDashboardData();
                }
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to logout?",
                "Confirm Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void ClearInputs()
        {
            txtEmail.Clear();
            txtPassword.Clear();
            comboBoxRole.SelectedIndex = -1;
        }

        

        private void AdminDashboard_FormClosing(object sender, FormClosingEventArgs e)
        {
            db?.Dispose();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadDashboardData();
        }

        private void AdminDashboard_FormClosed(object sender, FormClosedEventArgs e)
        {
            SessionManager.Logout();

            foreach (Form form in Application.OpenForms)
            {
                if (form is Form1 loginForm)
                {
                    loginForm.Show();
                    break;
                }
            }
        }
        private void RemoveStudentAndTeacherTabs()
        {
            // Find the TabControl on the form
            TabControl tabControl = this.Controls
                .OfType<TabControl>()
                .FirstOrDefault();

            if (tabControl == null)
                return;

            // Remove tabs by text or name (safe)
            var tabsToRemove = tabControl.TabPages
                .Cast<TabPage>()
                .Where(tp =>
                    tp.Text.Equals("Students", StringComparison.OrdinalIgnoreCase) ||
                    tp.Text.Equals("Teachers", StringComparison.OrdinalIgnoreCase) ||
                    tp.Name.ToLower().Contains("student") ||
                    tp.Name.ToLower().Contains("teacher")
                )
                .ToList();

            foreach (var tab in tabsToRemove)
                tabControl.TabPages.Remove(tab);
        }

        private void ConfigureUsersGrid()
        {
            // This forces the grid to follow whatever we bind to it
            // and removes any old designer-created columns like Username.
            dataGridViewUsers.AutoGenerateColumns = true;
            dataGridViewUsers.Columns.Clear();
        }
        private void groupBox2_Enter(object sender, EventArgs e) { }
        private void label4_Click(object sender, EventArgs e) { }
    }
}
