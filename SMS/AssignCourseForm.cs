using System;
using System.Linq;
using System.Windows.Forms;

using SMS.Services;
using SMS.Data;
using SMS.Data.Entities;
using SMS.Session;

namespace SMS
{
    public partial class AssignCourseForm : Form
    {
        private SMSDbContext db = SchoolContextFactory.Create();

        public AssignCourseForm()
        {
            InitializeComponent(); // This calls the designer file
            LoadData();
        }

        public void SetTeacherCourses(List<Course> teacherCourses)
        {
            // Clear existing data source
            cmbCourse.DataSource = null;

            // Set new data source with only teacher's courses
            cmbCourse.DataSource = teacherCourses.Select(c => new
            {
                c.Id,
                Name = $"{c.CourseCode} - {c.CourseName}"
            }).ToList();

            cmbCourse.DisplayMember = "Name";
            cmbCourse.ValueMember = "Id";

            if (cmbCourse.Items.Count > 0)
                cmbCourse.SelectedIndex = 0;
        }

        private void LoadData()
        {
            // Load students
            var students = db.Students.Select(s => new
            {
                s.Id,
                Name = s.FirstName + " " + s.LastName
            }).ToList();

            cmbStudent.DataSource = students;
            cmbStudent.DisplayMember = "Name";
            cmbStudent.ValueMember = "Id";

            // Load courses
            var courses = db.Courses.Select(c => new
            {
                c.Id,
                Name = c.CourseCode + " " + c.CourseName
            }).ToList();

            cmbCourse.DataSource = courses;
            cmbCourse.DisplayMember = "Name";
            cmbCourse.ValueMember = "Id";
        }

        private void btnAssign_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbStudent.SelectedItem == null || cmbCourse.SelectedItem == null)
                {
                    MessageBox.Show("Please select both student and course.", "Validation",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int studentId = (int)cmbStudent.SelectedValue;
                int courseId = (int)cmbCourse.SelectedValue;

                // Assign course without any grade-related data.
                string sql = @"
IF NOT EXISTS (
    SELECT 1 FROM Enrollments 
    WHERE StudentId = @StudentId AND CourseId = @CourseId
)
BEGIN
    INSERT INTO Enrollments (StudentId, CourseId, EnrollmentDate)
    VALUES (@StudentId, @CourseId, GETDATE());
    SELECT 1;
END
ELSE
    SELECT 0;";

                var parameters = new[]
                {
            new System.Data.SqlClient.SqlParameter("@StudentId", studentId),
            new System.Data.SqlClient.SqlParameter("@CourseId", courseId)
        };

                int result = db.Database.SqlQuery<int>(sql, parameters).FirstOrDefault();

                if (result == 1)
                {
                    MessageBox.Show("Course assigned successfully!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Student already enrolled in this course.", "Warning",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                string errorMsg = $"Error assigning course: {ex.Message}";
                if (ex.InnerException != null)
                    errorMsg += $"\n\nDetails: {ex.InnerException.Message}";

                MessageBox.Show(errorMsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void SetCourseId(int courseId)
        {
            // Find and select the course in combobox
            for (int i = 0; i < cmbCourse.Items.Count; i++)
            {
                dynamic item = cmbCourse.Items[i];
                if (item.Id == courseId)
                {
                    cmbCourse.SelectedIndex = i;
                    cmbCourse.Enabled = false; // Disable selection
                    break;
                }
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
