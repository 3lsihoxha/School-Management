using System;
using System.Linq;
using System.Windows.Forms;

using SMS.Services;
using SMS.Data;
using SMS.Data.Entities;
using SMS.Session;

namespace SMS
{
    public partial class AddCourseForm : Form
    {
        private SMSDbContext db = SchoolContextFactory.Create();

        public string CourseName { get; private set; }
        public string CourseCode { get; private set; }
        public string Description { get; private set; }
        public int TeacherId { get; private set; }

        public AddCourseForm()
        {
            InitializeComponent(); // This calls the designer file
            LoadTeachers();
        }

        private void LoadTeachers()
        {
            var teachers = db.Teachers.Select(t => new
            {
                t.Id,
                Name = t.FirstName + " " + t.LastName
            }).ToList();

            cmbTeacher.DataSource = teachers;
            cmbTeacher.DisplayMember = "Name";
            cmbTeacher.ValueMember = "Id";

            if (cmbTeacher.Items.Count > 0)
                cmbTeacher.SelectedIndex = 0;
        }
        public void SetTeacherId(int teacherId)
        {
            // Find and select the teacher in combobox
            for (int i = 0; i < cmbTeacher.Items.Count; i++)
            {
                dynamic item = cmbTeacher.Items[i];
                if (item.Id == teacherId)
                {
                    cmbTeacher.SelectedIndex = i;
                    cmbTeacher.Enabled = false; // Disable selection for teachers
                    break;
                }
            }
        }
        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCourseName.Text) ||
                string.IsNullOrEmpty(txtCourseCode.Text))
            {
                MessageBox.Show("Course Name and Code are required!", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbTeacher.SelectedItem == null)
            {
                MessageBox.Show("Please select a teacher!", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            CourseName = txtCourseName.Text;
            CourseCode = txtCourseCode.Text;
            Description = txtDescription.Text;
            TeacherId = (int)cmbTeacher.SelectedValue;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
