using System;
using System.Windows.Forms;

using SMS.Services;

using SMS.Data;
using SMS.Data.Repositories;
using SMS.Session;

namespace SMS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Convenience defaults (matches your restored database)
            txtEmail.Text = "admin@school.com";
            txtPassword.Text = "1234";
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text;

            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please enter email and password.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var db = SchoolContextFactory.Create())
                {
                    AuthManager auth = new AuthManager(db);

                    var user = auth.Login(email, password);

                    if (user == null)
                    {
                        MessageBox.Show("Invalid credentials.", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    SessionManager.CurrentUser = user;
                    Hide();

                    Form dashboard = user.Role switch
                    {
                        "Admin" => new AdminDashboard(),
                        "Teacher" => new TeacherDashboard(),
                        "Student" => new StudentDashboard(),
                        _ => throw new InvalidOperationException("Unknown role")
                    };

                    dashboard.FormClosed += (_, __) =>
                    {
                        SessionManager.CurrentUser = null;
                        Show();
                    };

                    dashboard.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void linkLabelHelp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show(
                "Enter your email and password to log in.\n\nDefault admin: admin@school.com / 1234",
                "Help", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
