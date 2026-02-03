using System;
using System.Drawing;
using System.Windows.Forms;

namespace SMS
{
    /// <summary>
    /// Single, user-friendly form to create Admin/Student/Teacher.
    /// Default role is Student. Switching to Teacher shows Department.
    /// Switching to Admin hides First/Last/Department (email + password only).
    /// </summary>
    public class AddUserForm : Form
    {
        public string Role { get; private set; } = "Student";
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public string Department { get; private set; }

        private ComboBox cmbRole;
        private TextBox txtFirstName;
        private TextBox txtLastName;
        private TextBox txtEmail;
        private TextBox txtPassword;
        private Label lblDepartment;
        private TextBox txtDepartment;

        // Prevent ApplyRoleUi from running before UI controls are created.
        private bool _uiBuilt = false;

        public AddUserForm()
        {
            Text = "Add User";
            FormBorderStyle = FormBorderStyle.FixedDialog;
            StartPosition = FormStartPosition.CenterParent;
            MaximizeBox = false;
            MinimizeBox = false;
            ShowInTaskbar = false;

            Width = 430;
            Height = 360;

            BuildUi();
            ApplyRoleUi();
        }

        private void BuildUi()
        {
            var padding = 16;
            var labelW = 110;
            var inputW = 250;
            var rowH = 30;
            var top = 20;

            Label MakeLabel(string text, int y)
            {
                return new Label
                {
                    Text = text,
                    Left = padding,
                    Top = y + 5,
                    Width = labelW,
                    Height = rowH,
                };
            }

            Control Place(Control c, int y)
            {
                c.Left = padding + labelW;
                c.Top = y;
                c.Width = inputW;
                c.Height = rowH;
                return c;
            }

            // Role
            Controls.Add(MakeLabel("Role:", top));
            cmbRole = new ComboBox
            {
                DropDownStyle = ComboBoxStyle.DropDownList,
            };
            cmbRole.Items.AddRange(new object[] { "Student", "Teacher", "Admin" });
            cmbRole.SelectedIndexChanged += (_, __) =>
            {
                Role = cmbRole.SelectedItem?.ToString() ?? "Student";
                ApplyRoleUi();
            };
            Controls.Add(Place(cmbRole, top));
            top += 40;

            // First name
            Controls.Add(MakeLabel("First name:", top));
            txtFirstName = new TextBox();
            Controls.Add(Place(txtFirstName, top));
            top += 40;

            // Last name
            Controls.Add(MakeLabel("Last name:", top));
            txtLastName = new TextBox();
            Controls.Add(Place(txtLastName, top));
            top += 40;

            // Email
            Controls.Add(MakeLabel("Email:", top));
            txtEmail = new TextBox();
            Controls.Add(Place(txtEmail, top));
            top += 40;

            // Password
            Controls.Add(MakeLabel("Password:", top));
            txtPassword = new TextBox { PasswordChar = '*' };
            Controls.Add(Place(txtPassword, top));
            top += 40;

            // Department (only for Teacher)
            lblDepartment = MakeLabel("Department:", top);
            txtDepartment = new TextBox();
            Controls.Add(lblDepartment);
            Controls.Add(Place(txtDepartment, top));
            top += 50;

            // Buttons
            var btnCreate = new Button
            {
                Text = "Create",
                Width = 110,
                Height = 34,
                Left = Width - padding - 110 - 120,
                Top = top,
                DialogResult = DialogResult.None
            };
            btnCreate.Click += (_, __) => CreateClicked();

            var btnCancel = new Button
            {
                Text = "Cancel",
                Width = 110,
                Height = 34,
                Left = Width - padding - 110,
                Top = top,
                DialogResult = DialogResult.Cancel
            };

            Controls.Add(btnCreate);
            Controls.Add(btnCancel);

            AcceptButton = btnCreate;
            CancelButton = btnCancel;

            // Now that every control exists, it is safe to set defaults and trigger UI updates.
            _uiBuilt = true;
            cmbRole.SelectedItem = "Student";
        }

        private void ApplyRoleUi()
        {
            // SelectedIndexChanged can fire while the UI is still being constructed.
            if (!_uiBuilt || lblDepartment == null || txtDepartment == null)
                return;

            var role = Role ?? "Student";

            bool isTeacher = role.Equals("Teacher", StringComparison.OrdinalIgnoreCase);
            bool isStudent = role.Equals("Student", StringComparison.OrdinalIgnoreCase);
            bool isAdmin = role.Equals("Admin", StringComparison.OrdinalIgnoreCase);

            // Department
            lblDepartment.Visible = isTeacher;
            txtDepartment.Visible = isTeacher;

            // For Admin: keep it simple (email/password only)
            txtFirstName.Visible = !isAdmin;
            txtLastName.Visible = !isAdmin;

            // The labels for First/Last are the controls right before each textbox.
            // We can find them by position (safe enough because this form is self-contained).
            foreach (Control c in Controls)
            {
                if (c is Label lbl)
                {
                    if (lbl.Text == "First name:") lbl.Visible = !isAdmin;
                    if (lbl.Text == "Last name:") lbl.Visible = !isAdmin;
                }
            }

            // Resize a bit depending on role to avoid empty space
            Height = isTeacher ? 410 : 360;

            // Basic defaults
            if (cmbRole.SelectedItem == null)
                cmbRole.SelectedItem = isStudent ? "Student" : (isTeacher ? "Teacher" : "Admin");
        }

        private void CreateClicked()
        {
            Role = cmbRole.SelectedItem?.ToString() ?? "Student";

            var email = (txtEmail.Text ?? "").Trim();
            var password = txtPassword.Text ?? "";

            bool isTeacher = Role.Equals("Teacher", StringComparison.OrdinalIgnoreCase);
            bool isStudent = Role.Equals("Student", StringComparison.OrdinalIgnoreCase);
            bool isAdmin = Role.Equals("Admin", StringComparison.OrdinalIgnoreCase);

            var firstName = (txtFirstName.Text ?? "").Trim();
            var lastName = (txtLastName.Text ?? "").Trim();
            var department = (txtDepartment.Text ?? "").Trim();

            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Email and Password are required.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if ((isStudent || isTeacher) && (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName)))
            {
                MessageBox.Show("First name and Last name are required.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (isTeacher && string.IsNullOrWhiteSpace(department))
            {
                MessageBox.Show("Department is required for Teachers.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Email = email;
            Password = password;
            FirstName = firstName;
            LastName = lastName;
            Department = department;

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
