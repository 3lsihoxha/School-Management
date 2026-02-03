using SMS.Services;
using SMS.Data;
using SMS.Data.Entities;
using SMS.Session;

namespace SMS
{
    partial class TeacherDashboard
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblDepartment;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabCourses;
        private System.Windows.Forms.DataGridView dataGridViewCourses;
        private System.Windows.Forms.Button btnCreateCourse;
        private System.Windows.Forms.TabPage tabStudents;
        private System.Windows.Forms.DataGridView dataGridViewStudents;
        private System.Windows.Forms.Button btnAssignStudent;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnLogout;
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
            lblWelcome = new Label();
            lblEmail = new Label();
            lblDepartment = new Label();
            tabControl1 = new TabControl();
            tabCourses = new TabPage();
            btnDeleteCourse = new Button();
            dataGridViewCourses = new DataGridView();
            btnCreateCourse = new Button();
            tabStudents = new TabPage();
            dataGridViewStudents = new DataGridView();
            btnAssignStudent = new Button();
            btnRefresh = new Button();
            btnLogout = new Button();
            tabControl1.SuspendLayout();
            tabCourses.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewCourses).BeginInit();
            tabStudents.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewStudents).BeginInit();
            SuspendLayout();
            // 
            // lblWelcome
            // 
            lblWelcome.AutoSize = true;
            lblWelcome.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Point);
            lblWelcome.Location = new Point(27, 31);
            lblWelcome.Margin = new Padding(4, 0, 4, 0);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(129, 29);
            lblWelcome.TabIndex = 0;
            lblWelcome.Text = "Welcome,";
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(27, 92);
            lblEmail.Margin = new Padding(4, 0, 4, 0);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(53, 20);
            lblEmail.TabIndex = 1;
            lblEmail.Text = "Email: ";
            // 
            // lblDepartment
            // 
            lblDepartment.AutoSize = true;
            lblDepartment.Location = new Point(27, 123);
            lblDepartment.Margin = new Padding(4, 0, 4, 0);
            lblDepartment.Name = "lblDepartment";
            lblDepartment.Size = new Size(96, 20);
            lblDepartment.TabIndex = 2;
            lblDepartment.Text = "Department: ";
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabCourses);
            tabControl1.Controls.Add(tabStudents);
            tabControl1.Location = new Point(27, 169);
            tabControl1.Margin = new Padding(4, 5, 4, 5);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1120, 615);
            tabControl1.TabIndex = 3;
            // 
            // tabCourses
            // 
            tabCourses.Controls.Add(btnDeleteCourse);
            tabCourses.Controls.Add(dataGridViewCourses);
            tabCourses.Controls.Add(btnCreateCourse);
            tabCourses.Location = new Point(4, 29);
            tabCourses.Margin = new Padding(4, 5, 4, 5);
            tabCourses.Name = "tabCourses";
            tabCourses.Padding = new Padding(4, 5, 4, 5);
            tabCourses.Size = new Size(1112, 582);
            tabCourses.TabIndex = 0;
            tabCourses.Text = "My Courses";
            tabCourses.UseVisualStyleBackColor = true;
            // 
            // btnDeleteCourse
            // 
            btnDeleteCourse.Location = new Point(913, 10);
            btnDeleteCourse.Margin = new Padding(4, 5, 4, 5);
            btnDeleteCourse.Name = "btnDeleteCourse";
            btnDeleteCourse.Size = new Size(188, 54);
            btnDeleteCourse.TabIndex = 15;
            btnDeleteCourse.Text = "Delete Course";
            btnDeleteCourse.UseVisualStyleBackColor = true;
            btnDeleteCourse.Click += btnDeleteCourse_Click;
            // 
            // dataGridViewCourses
            // 
            dataGridViewCourses.AllowUserToAddRows = false;
            dataGridViewCourses.AllowUserToDeleteRows = false;
            dataGridViewCourses.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCourses.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCourses.Location = new Point(8, 77);
            dataGridViewCourses.Margin = new Padding(4, 5, 4, 5);
            dataGridViewCourses.Name = "dataGridViewCourses";
            dataGridViewCourses.ReadOnly = true;
            dataGridViewCourses.RowHeadersWidth = 51;
            dataGridViewCourses.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewCourses.Size = new Size(1093, 489);
            dataGridViewCourses.TabIndex = 1;
            // 
            // btnCreateCourse
            // 
            btnCreateCourse.Location = new Point(8, 9);
            btnCreateCourse.Margin = new Padding(4, 5, 4, 5);
            btnCreateCourse.Name = "btnCreateCourse";
            btnCreateCourse.Size = new Size(160, 54);
            btnCreateCourse.TabIndex = 0;
            btnCreateCourse.Text = "Create New Course";
            btnCreateCourse.UseVisualStyleBackColor = true;
            btnCreateCourse.Click += btnCreateCourse_Click;
            // 
            // tabStudents
            // 
            tabStudents.Controls.Add(dataGridViewStudents);
            tabStudents.Controls.Add(btnAssignStudent);
            tabStudents.Location = new Point(4, 29);
            tabStudents.Margin = new Padding(4, 5, 4, 5);
            tabStudents.Name = "tabStudents";
            tabStudents.Padding = new Padding(4, 5, 4, 5);
            tabStudents.Size = new Size(1112, 582);
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
            dataGridViewStudents.Location = new Point(8, 77);
            dataGridViewStudents.Margin = new Padding(4, 5, 4, 5);
            dataGridViewStudents.Name = "dataGridViewStudents";
            dataGridViewStudents.ReadOnly = true;
            dataGridViewStudents.RowHeadersWidth = 51;
            dataGridViewStudents.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewStudents.Size = new Size(1093, 489);
            dataGridViewStudents.TabIndex = 2;
            // 
            // btnAssignStudent
            // 
            btnAssignStudent.Location = new Point(8, 9);
            btnAssignStudent.Margin = new Padding(4, 5, 4, 5);
            btnAssignStudent.Name = "btnAssignStudent";
            btnAssignStudent.Size = new Size(200, 54);
            btnAssignStudent.TabIndex = 3;
            btnAssignStudent.Text = "Assign Student to Course";
            btnAssignStudent.UseVisualStyleBackColor = true;
            btnAssignStudent.Click += btnAssignStudent_Click;
            // 
            // btnRefresh
            // 
            btnRefresh.Location = new Point(27, 800);
            btnRefresh.Margin = new Padding(4, 5, 4, 5);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(133, 46);
            btnRefresh.TabIndex = 4;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // btnLogout
            // 
            btnLogout.Location = new Point(1013, 800);
            btnLogout.Margin = new Padding(4, 5, 4, 5);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(133, 46);
            btnLogout.TabIndex = 5;
            btnLogout.Text = "Logout";
            btnLogout.UseVisualStyleBackColor = true;
            btnLogout.Click += btnLogout_Click;
            // 
            // TeacherDashboard
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1179, 863);
            Controls.Add(btnLogout);
            Controls.Add(btnRefresh);
            Controls.Add(tabControl1);
            Controls.Add(lblDepartment);
            Controls.Add(lblEmail);
            Controls.Add(lblWelcome);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(4, 5, 4, 5);
            MaximizeBox = false;
            Name = "TeacherDashboard";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Teacher Dashboard";
            FormClosing += TeacherDashboard_FormClosing;
            FormClosed += TeacherDashboard_FormClosed;
            tabControl1.ResumeLayout(false);
            tabCourses.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewCourses).EndInit();
            tabStudents.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewStudents).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
