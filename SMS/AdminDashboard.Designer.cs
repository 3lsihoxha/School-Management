using SMS.Services;
using SMS.Data;
using SMS.Data.Entities;
using SMS.Session;

namespace SMS
{
    partial class AdminDashboard
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TabPage tabCourses;
        private System.Windows.Forms.DataGridView dataGridViewCourses;
        private System.Windows.Forms.Button btnDeleteCourse;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            tabTeachers = new TabPage();
            dataGridViewTeachers = new DataGridView();
            btnDeleteTeacher = new Button();
            tabStudents = new TabPage();
            dataGridViewStudents = new DataGridView();
            btnDeleteStudent = new Button();
            tabUsers = new TabPage();
            btnEditUser = new Button();
            btnDeleteUser = new Button();
            dataGridViewUsers = new DataGridView();
            groupBox1 = new GroupBox();
            txtEmail = new TextBox();
            txtPassword = new TextBox();
            comboBoxRole = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            btnAddUser = new Button();
            tabControl1 = new TabControl();
            tabTeachers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewTeachers).BeginInit();
            tabStudents.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewStudents).BeginInit();
            tabUsers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewUsers).BeginInit();
            groupBox1.SuspendLayout();
            tabControl1.SuspendLayout();
            SuspendLayout();
            // 
            // tabTeachers
            // 
            tabTeachers.Controls.Add(btnDeleteTeacher);
            tabTeachers.Controls.Add(dataGridViewTeachers);
            tabTeachers.Location = new Point(4, 29);
            tabTeachers.Margin = new Padding(4, 5, 4, 5);
            tabTeachers.Name = "tabTeachers";
            tabTeachers.Size = new Size(1139, 582);
            tabTeachers.TabIndex = 2;
            tabTeachers.Text = "Teachers";
            tabTeachers.UseVisualStyleBackColor = true;
            // 
            // dataGridViewTeachers
            // 
            dataGridViewTeachers.AllowUserToAddRows = false;
            dataGridViewTeachers.AllowUserToDeleteRows = false;
            dataGridViewTeachers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewTeachers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewTeachers.Location = new Point(8, 65);
            dataGridViewTeachers.Margin = new Padding(4, 5, 4, 5);
            dataGridViewTeachers.Name = "dataGridViewTeachers";
            dataGridViewTeachers.ReadOnly = true;
            dataGridViewTeachers.RowHeadersWidth = 51;
            dataGridViewTeachers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewTeachers.Size = new Size(1120, 502);
            dataGridViewTeachers.TabIndex = 4;
            // 
            // btnDeleteTeacher
            // 
            btnDeleteTeacher.Location = new Point(995, 9);
            btnDeleteTeacher.Margin = new Padding(4, 5, 4, 5);
            btnDeleteTeacher.Name = "btnDeleteTeacher";
            btnDeleteTeacher.Size = new Size(133, 46);
            btnDeleteTeacher.TabIndex = 5;
            btnDeleteTeacher.Text = "Delete Teacher";
            btnDeleteTeacher.UseVisualStyleBackColor = true;
            // 
            // tabStudents
            // 
            tabStudents.Controls.Add(btnDeleteStudent);
            tabStudents.Controls.Add(dataGridViewStudents);
            tabStudents.Location = new Point(4, 29);
            tabStudents.Margin = new Padding(4, 5, 4, 5);
            tabStudents.Name = "tabStudents";
            tabStudents.Padding = new Padding(4, 5, 4, 5);
            tabStudents.Size = new Size(1139, 582);
            tabStudents.TabIndex = 1;
            tabStudents.Text = "Students";
            tabStudents.UseVisualStyleBackColor = true;
            // 
            // dataGridViewStudents
            // 
            dataGridViewStudents.AllowUserToAddRows = false;
            dataGridViewStudents.AllowUserToDeleteRows = false;
            dataGridViewStudents.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewStudents.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewStudents.Location = new Point(8, 65);
            dataGridViewStudents.Margin = new Padding(4, 5, 4, 5);
            dataGridViewStudents.Name = "dataGridViewStudents";
            dataGridViewStudents.ReadOnly = true;
            dataGridViewStudents.RowHeadersWidth = 51;
            dataGridViewStudents.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewStudents.Size = new Size(1120, 502);
            dataGridViewStudents.TabIndex = 4;
            // 
            // btnDeleteStudent
            // 
            btnDeleteStudent.Location = new Point(995, 9);
            btnDeleteStudent.Margin = new Padding(4, 5, 4, 5);
            btnDeleteStudent.Name = "btnDeleteStudent";
            btnDeleteStudent.Size = new Size(133, 46);
            btnDeleteStudent.TabIndex = 5;
            btnDeleteStudent.Text = "Delete Student";
            btnDeleteStudent.UseVisualStyleBackColor = true;
            // 
            // tabUsers
            // 
            tabUsers.Controls.Add(groupBox1);
            tabUsers.Controls.Add(dataGridViewUsers);
            tabUsers.Controls.Add(btnDeleteUser);
            tabUsers.Controls.Add(btnEditUser);
            tabUsers.Location = new Point(4, 29);
            tabUsers.Margin = new Padding(4, 5, 4, 5);
            tabUsers.Name = "tabUsers";
            tabUsers.Padding = new Padding(4, 5, 4, 5);
            tabUsers.Size = new Size(1139, 582);
            tabUsers.TabIndex = 0;
            tabUsers.Text = "Users";
            tabUsers.UseVisualStyleBackColor = true;
            // 
            // btnEditUser
            // 
            btnEditUser.Location = new Point(854, 9);
            btnEditUser.Margin = new Padding(4, 5, 4, 5);
            btnEditUser.Name = "btnEditUser";
            btnEditUser.Size = new Size(133, 46);
            btnEditUser.TabIndex = 4;
            btnEditUser.Text = "Edit User";
            btnEditUser.UseVisualStyleBackColor = true;
            btnEditUser.Click += btnEditUser_Click;
            // 
            // btnDeleteUser
            // 
            btnDeleteUser.Location = new Point(995, 9);
            btnDeleteUser.Margin = new Padding(4, 5, 4, 5);
            btnDeleteUser.Name = "btnDeleteUser";
            btnDeleteUser.Size = new Size(133, 46);
            btnDeleteUser.TabIndex = 3;
            btnDeleteUser.Text = "Delete User";
            btnDeleteUser.UseVisualStyleBackColor = true;
            btnDeleteUser.Click += btnDeleteUser_Click;
            // 
            // dataGridViewUsers
            // 
            dataGridViewUsers.AllowUserToAddRows = false;
            dataGridViewUsers.AllowUserToDeleteRows = false;
            dataGridViewUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewUsers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewUsers.Location = new Point(8, 249);
            dataGridViewUsers.Margin = new Padding(4, 5, 4, 5);
            dataGridViewUsers.MultiSelect = false;
            dataGridViewUsers.Name = "dataGridViewUsers";
            dataGridViewUsers.ReadOnly = true;
            dataGridViewUsers.RowHeadersWidth = 51;
            dataGridViewUsers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewUsers.Size = new Size(1120, 317);
            dataGridViewUsers.TabIndex = 1;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnAddUser);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(comboBoxRole);
            groupBox1.Controls.Add(txtPassword);
            groupBox1.Controls.Add(txtEmail);
            groupBox1.Location = new Point(8, 9);
            groupBox1.Margin = new Padding(4, 5, 4, 5);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(4, 5, 4, 5);
            groupBox1.Size = new Size(536, 231);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "Add New User";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(133, 26);
            txtEmail.Margin = new Padding(4, 5, 4, 5);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(265, 27);
            txtEmail.TabIndex = 0;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(133, 72);
            txtPassword.Margin = new Padding(4, 5, 4, 5);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(265, 27);
            txtPassword.TabIndex = 1;
            // 
            // comboBoxRole
            // 
            comboBoxRole.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxRole.FormattingEnabled = true;
            comboBoxRole.Items.AddRange(new object[] { "Admin", "Teacher", "Student" });
            comboBoxRole.Location = new Point(133, 118);
            comboBoxRole.Margin = new Padding(4, 5, 4, 5);
            comboBoxRole.Name = "comboBoxRole";
            comboBoxRole.Size = new Size(265, 28);
            comboBoxRole.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(27, 31);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(49, 20);
            label1.TabIndex = 3;
            label1.Text = "Email:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(27, 77);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(73, 20);
            label2.TabIndex = 4;
            label2.Text = "Password:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(27, 123);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(42, 20);
            label3.TabIndex = 5;
            label3.Text = "Role:";
            // 
            // btnAddUser
            // 
            btnAddUser.Location = new Point(160, 169);
            btnAddUser.Margin = new Padding(4, 5, 4, 5);
            btnAddUser.Name = "btnAddUser";
            btnAddUser.Size = new Size(133, 46);
            btnAddUser.TabIndex = 6;
            btnAddUser.Text = "Add User";
            btnAddUser.UseVisualStyleBackColor = true;
            btnAddUser.Click += btnAddUser_Click;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabUsers);
            tabControl1.Controls.Add(tabStudents);
            tabControl1.Controls.Add(tabTeachers);
            tabControl1.Location = new Point(16, 18);
            tabControl1.Margin = new Padding(4, 5, 4, 5);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1147, 615);
            tabControl1.TabIndex = 0;
            // 
            // AdminDashboard
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1177, 667);
            Controls.Add(tabControl1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(4, 5, 4, 5);
            MaximizeBox = false;
            Name = "AdminDashboard";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Admin Dashboard";
            FormClosing += AdminDashboard_FormClosing;
            FormClosed += AdminDashboard_FormClosed;
            tabTeachers.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewTeachers).EndInit();
            tabStudents.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewStudents).EndInit();
            tabUsers.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewUsers).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            tabControl1.ResumeLayout(false);
            ResumeLayout(false);
        }

        private TabPage tabTeachers;
        private Button btnDeleteTeacher;
        private DataGridView dataGridViewTeachers;
        private TabPage tabStudents;
        private Button btnDeleteStudent;
        private DataGridView dataGridViewStudents;
        private TabPage tabUsers;
        private GroupBox groupBox1;
        private Button btnAddUser;
        private Label label3;
        private Label label2;
        private Label label1;
        private ComboBox comboBoxRole;
        private TextBox txtPassword;
        private TextBox txtEmail;
        private DataGridView dataGridViewUsers;
        private Button btnDeleteUser;
        private Button btnEditUser;
        private TabControl tabControl1;
    }
}
