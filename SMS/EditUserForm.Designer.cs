namespace SMS
{
    partial class EditUserForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;

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
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            txtEmail = new System.Windows.Forms.TextBox();
            txtFirstName = new System.Windows.Forms.TextBox();
            txtLastName = new System.Windows.Forms.TextBox();
            btnSave = new System.Windows.Forms.Button();
            btnCancel = new System.Windows.Forms.Button();
            SuspendLayout();
            // 
            // label1 (Email)
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(30, 30);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(46, 20);
            label1.Text = "Email";
            // 
            // txtEmail
            // 
            txtEmail.Location = new System.Drawing.Point(140, 27);
            txtEmail.Size = new System.Drawing.Size(260, 27);
            // 
            // label2 (First Name)
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(30, 75);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(80, 20);
            label2.Text = "First Name";
            // 
            // txtFirstName
            // 
            txtFirstName.Location = new System.Drawing.Point(140, 72);
            txtFirstName.Size = new System.Drawing.Size(260, 27);
            // 
            // label3 (Last Name)
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(30, 120);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(79, 20);
            label3.Text = "Last Name";
            // 
            // txtLastName
            // 
            txtLastName.Location = new System.Drawing.Point(140, 117);
            txtLastName.Size = new System.Drawing.Size(260, 27);
            // 
            // btnSave
            // 
            btnSave.Location = new System.Drawing.Point(140, 170);
            btnSave.Size = new System.Drawing.Size(120, 35);
            btnSave.Text = "Save";
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new System.Drawing.Point(280, 170);
            btnCancel.Size = new System.Drawing.Size(120, 35);
            btnCancel.Text = "Cancel";
            btnCancel.Click += btnCancel_Click;
            // 
            // EditUserForm
            // 
            ClientSize = new System.Drawing.Size(450, 240);
            Controls.Add(label1);
            Controls.Add(txtEmail);
            Controls.Add(label2);
            Controls.Add(txtFirstName);
            Controls.Add(label3);
            Controls.Add(txtLastName);
            Controls.Add(btnSave);
            Controls.Add(btnCancel);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text = "Edit User";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
