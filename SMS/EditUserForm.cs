using System;
using System.Linq;
using System.Windows.Forms;
using SMS.Data;
using SMS.Data.Entities;

namespace SMS
{
    public partial class EditUserForm : Form
    {
        private readonly SMSDbContext _db;
        private readonly int _userId;
        private User _user;

        public EditUserForm(SMSDbContext db, int userId)
        {
            InitializeComponent();
            _db = db;
            _userId = userId;

            LoadUser();
        }

        private void LoadUser()
        {
            _user = _db.Users.FirstOrDefault(u => u.Id == _userId);

            if (_user == null)
            {
                MessageBox.Show("User not found.");
                Close();
                return;
            }

            txtEmail.Text = _user.Email;

            // Load FirstName / LastName from related entity
            if (_user.Role == "Teacher")
            {
                var teacher = _db.Teachers.FirstOrDefault(t => t.UserId == _userId);
                if (teacher != null)
                {
                    txtFirstName.Text = teacher.FirstName;
                    txtLastName.Text = teacher.LastName;
                }
            }
            else if (_user.Role == "Student")
            {
                var student = _db.Students.FirstOrDefault(s => s.UserId == _userId);
                if (student != null)
                {
                    txtFirstName.Text = student.FirstName;
                    txtLastName.Text = student.LastName;
                }
            }
            else
            {
                // Admin → no student/teacher record
                txtFirstName.Enabled = false;
                txtLastName.Enabled = false;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Email is required.");
                return;
            }

            _user.Email = txtEmail.Text.Trim();

            // Save First/Last name to related entity
            if (_user.Role == "Teacher")
            {
                var teacher = _db.Teachers.FirstOrDefault(t => t.UserId == _userId);
                if (teacher != null)
                {
                    teacher.FirstName = txtFirstName.Text.Trim();
                    teacher.LastName = txtLastName.Text.Trim();
                }
            }
            else if (_user.Role == "Student")
            {
                var student = _db.Students.FirstOrDefault(s => s.UserId == _userId);
                if (student != null)
                {
                    student.FirstName = txtFirstName.Text.Trim();
                    student.LastName = txtLastName.Text.Trim();
                }
            }

            _db.SaveChanges();

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
