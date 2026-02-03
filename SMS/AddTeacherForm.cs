using System;
using System.Windows.Forms;

using SMS.Services;
using SMS.Data;
using SMS.Data.Entities;
using SMS.Session;

namespace SMS
{
    public partial class AddTeacherForm : Form
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }
        public string Department { get; private set; }
        public string Password { get; private set; }

        public AddTeacherForm()
        {
            InitializeComponent(); // This calls the designer file
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtFirstName.Text) ||
                string.IsNullOrEmpty(txtLastName.Text) ||
                string.IsNullOrEmpty(txtEmail.Text) ||
                string.IsNullOrEmpty(txtDepartment.Text) ||
                string.IsNullOrEmpty(txtPassword.Text))
            {
                MessageBox.Show("All fields are required!", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Keep the password in memory only; the form never displays stored passwords.
            Password = txtPassword.Text;
            FirstName = txtFirstName.Text;
            LastName = txtLastName.Text;
            Email = txtEmail.Text;
            Department = txtDepartment.Text;

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
