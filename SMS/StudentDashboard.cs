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
    public partial class StudentDashboard : Form
    {
        private SMSDbContext db;
        private Student currentStudent;

        public StudentDashboard()
        {
            InitializeComponent();
            this.db = SchoolContextFactory.Create();
            LoadStudentData();
            LoadEnrolledCourses();
        }

        private void LoadStudentData()
        {
            if (SessionManager.CurrentUser == null)
            {
                MessageBox.Show("No user logged in!");
                this.Close();
                return;
            }

            // Get student profile for current user
            currentStudent = db.Students
                .Include(s => s.User)
                .FirstOrDefault(s => s.UserId == SessionManager.CurrentUser.Id);

            if (currentStudent == null)
            {
                MessageBox.Show("Student profile not found!");
                this.Close();
                return;
            }

            lblWelcome.Text = $"Welcome, {currentStudent.FirstName} {currentStudent.LastName}";
            lblEmail.Text = $"Email: {currentStudent.Email}";
            lblEnrollmentDate.Text = $"Enrolled: {currentStudent.EnrollmentDate:yyyy-MM-dd}";
        }

        private void LoadEnrolledCourses()
        {
            if (currentStudent == null) return;

            var enrollments = db.Enrollments
                .Include(e => e.Course)
                .Include(e => e.Course.Teacher)
                .Where(e => e.StudentId == currentStudent.Id)
                .ToList();

            dataGridViewCourses.DataSource = enrollments.Select(e => new
            {
                e.Course.CourseCode,
                e.Course.CourseName,
                Teacher = e.Course.Teacher != null ?
                    e.Course.Teacher.FirstName + " " + e.Course.Teacher.LastName : "N/A",
                e.EnrollmentDate
            }).ToList();

            lblCourseCount.Text = $"Enrolled in {enrollments.Count} course(s)";
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

        private void StudentDashboard_FormClosed(object sender, FormClosedEventArgs e)
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

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadEnrolledCourses();
        }
    }
}
