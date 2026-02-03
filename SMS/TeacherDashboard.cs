using System;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;

using SMS.Services;
using SMS.Data;
using SMS.Data.Entities;
using SMS.Session;

namespace SMS
{
    public partial class TeacherDashboard : Form
    {
        private SMSDbContext db;
        private Teacher currentTeacher;

        public TeacherDashboard()
        {
            InitializeComponent();
            this.db = SchoolContextFactory.Create();
            LoadTeacherData();
            LoadTeacherCourses();
            LoadAllStudents();
        }

        private void btnDeleteCourse_Click(object sender, EventArgs e)
        {
            DeleteSelectedCourse();
        }


        private void LoadTeacherData()
        {
            if (SessionManager.CurrentUser == null)
            {
                MessageBox.Show("No user logged in!");
                this.Close();
                return;
            }

            // Get teacher profile for current user
            currentTeacher = db.Teachers
                .Include(t => t.User)
                .FirstOrDefault(t => t.UserId == SessionManager.CurrentUser.Id);

            if (currentTeacher == null)
            {
                MessageBox.Show("Teacher profile not found!");
                this.Close();
                return;
            }

            lblWelcome.Text = $"Welcome, {currentTeacher.FirstName} {currentTeacher.LastName}";
            lblEmail.Text = $"Email: {currentTeacher.Email}";
            lblDepartment.Text = $"Department: {currentTeacher.Department}";
        }

        private void LoadTeacherCourses()
        {
            if (currentTeacher == null) return;

            var courses = db.Courses
                .Where(c => c.TeacherId == currentTeacher.Id)
                .ToList();

            dataGridViewCourses.DataSource = courses.Select(c => new
            {
                c.Id,
                c.CourseName,
                c.CourseCode,
                c.Description,
                Created = c.CreatedDate.ToString("yyyy-MM-dd"),
                Students = db.Enrollments.Count(e => e.CourseId == c.Id)
            }).ToList();
        }

        private void LoadAllStudents()
        {
            var students = db.Students.ToList();
            dataGridViewStudents.DataSource = students.Select(s => new
            {
                s.Id,
                Name = s.FirstName + " " + s.LastName,
                s.Email,
                EnrollmentDate = s.EnrollmentDate.ToString("yyyy-MM-dd"),
                Courses = db.Enrollments.Count(e => e.StudentId == s.Id)
            }).ToList();
        }

        private void btnCreateCourse_Click(object sender, EventArgs e)
        {
            using (var form = new AddCourseForm())
            {
                // Set default teacher to current teacher
                form.SetTeacherId(currentTeacher.Id);

                if (form.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        var course = new Course
                        {
                            CourseName = form.CourseName,
                            CourseCode = form.CourseCode,
                            Description = form.Description,
                            TeacherId = currentTeacher.Id, // Always use current teacher
                            CreatedDate = DateTime.Now
                        };

                        db.Courses.Add(course);
                        db.SaveChanges();

                        MessageBox.Show("Course created successfully!", "Success",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadTeacherCourses();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error creating course: {ex.Message}", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnAssignStudent_Click(object sender, EventArgs e)
        {
            if (currentTeacher == null) return;

            // Get teacher's courses
            var teacherCourses = db.Courses
                .Where(c => c.TeacherId == currentTeacher.Id)
                .ToList();

            if (!teacherCourses.Any())
            {
                MessageBox.Show("You need to create courses first before assigning students.",
                    "No Courses", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var form = new AssignCourseForm())
            {
                // Pass teacher's courses to the form
                form.SetTeacherCourses(teacherCourses);

                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadTeacherCourses();
                    LoadAllStudents();
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

        private void TeacherDashboard_FormClosed(object sender, FormClosedEventArgs e)
        {
            SessionManager.Logout();

            // Show login form
            foreach (Form form in Application.OpenForms)
            {
                if (form is Form1 loginForm)
                {
                    loginForm.Show();
                    break;
                }
            }
        }

        private void DeleteSelectedCourse()
        {
            if (dataGridViewCourses.CurrentRow == null)
            {
                MessageBox.Show("Please select a course to delete.");
                return;
            }

            int courseId = Convert.ToInt32(
                dataGridViewCourses.CurrentRow.Cells["Id"].Value);

            var confirm = MessageBox.Show(
                "Are you sure you want to delete this course?\nAll enrollments will also be removed.",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirm != DialogResult.Yes)
                return;

            try
            {
                // 1) remove enrollments first
                var enrollments = db.Enrollments
                    .Where(e => e.CourseId == courseId)
                    .ToList();

                if (enrollments.Any())
                    db.Enrollments.RemoveRange(enrollments);

                // 2) remove course
                var course = db.Courses.FirstOrDefault(c =>
                    c.Id == courseId && c.TeacherId == currentTeacher.Id);

                if (course == null)
                {
                    MessageBox.Show("Course not found or not owned by you.");
                    return;
                }

                db.Courses.Remove(course);
                db.SaveChanges();

                MessageBox.Show("Course deleted successfully.");
                LoadTeacherCourses();
                LoadAllStudents();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Error deleting course: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }


        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadTeacherCourses();
            LoadAllStudents();
        }

        private void TeacherDashboard_FormClosing(object sender, FormClosingEventArgs e)
        {
            db?.Dispose();
        }
    }
}
