

namespace SkillManagementForm
{
    partial class UserSkillTrackingForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            cmbAssignSkill = new ComboBox();
            cmbAssignUser = new ComboBox();
            txtProficiency = new TextBox();
            dataGridUserSkills = new DataGridView();
            btnAddUserSkill = new Button();
            btnAssignSkill = new Button();
            btnDeleteUserSkill = new Button();
            txtName = new TextBox();
            txtEmail = new TextBox();
            btnSave = new Button();
            txtSkillName = new TextBox();
            btnUpdateUserSkill = new Button();
            btnDeleteUser = new Button();
            btnUpdateUser = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            txtPassword = new TextBox();
            label6 = new Label();
            label7 = new Label();
            btnDeleteSkill = new Button();
            departmentLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridUserSkills).BeginInit();
            SuspendLayout();
            // 
            // cmbAssignSkill
            // 
            cmbAssignSkill.FormattingEnabled = true;
            cmbAssignSkill.Location = new Point(119, 443);
            cmbAssignSkill.Name = "cmbAssignSkill";
            cmbAssignSkill.Size = new Size(151, 28);
            cmbAssignSkill.TabIndex = 10;
            // 
            // cmbAssignUser
            // 
            cmbAssignUser.FormattingEnabled = true;
            cmbAssignUser.Location = new Point(119, 360);
            cmbAssignUser.Name = "cmbAssignUser";
            cmbAssignUser.Size = new Size(151, 28);
            cmbAssignUser.TabIndex = 9;
            // 
            // txtProficiency
            // 
            txtProficiency.Location = new Point(378, 404);
            txtProficiency.Name = "txtProficiency";
            txtProficiency.Size = new Size(151, 27);
            txtProficiency.TabIndex = 11;
            // 
            // dataGridUserSkills
            // 
            dataGridUserSkills.BackgroundColor = Color.White;
            dataGridUserSkills.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridUserSkills.Location = new Point(-2, -2);
            dataGridUserSkills.Name = "dataGridUserSkills";
            dataGridUserSkills.RowHeadersWidth = 51;
            dataGridUserSkills.Size = new Size(562, 319);
            dataGridUserSkills.TabIndex = 3;
            // 
            // btnAddUserSkill
            // 
            btnAddUserSkill.Location = new Point(827, 461);
            btnAddUserSkill.Name = "btnAddUserSkill";
            btnAddUserSkill.Size = new Size(94, 29);
            btnAddUserSkill.TabIndex = 7;
            btnAddUserSkill.Text = "Add Skill ";
            btnAddUserSkill.UseVisualStyleBackColor = true;
            btnAddUserSkill.Click += btnAddUserSkill_Click;
            // 
            // btnAssignSkill
            // 
            btnAssignSkill.Location = new Point(20, 515);
            btnAssignSkill.Name = "btnAssignSkill";
            btnAssignSkill.Size = new Size(101, 29);
            btnAssignSkill.TabIndex = 12;
            btnAssignSkill.Text = "Assign";
            btnAssignSkill.UseVisualStyleBackColor = true;
            btnAssignSkill.Click += btnAssignSkill_Click;
            // 
            // btnDeleteUserSkill
            // 
            btnDeleteUserSkill.Location = new Point(827, 505);
            btnDeleteUserSkill.Name = "btnDeleteUserSkill";
            btnDeleteUserSkill.Size = new Size(94, 29);
            btnDeleteUserSkill.TabIndex = 8;
            btnDeleteUserSkill.Text = "Delete Skill";
            btnDeleteUserSkill.UseVisualStyleBackColor = true;
            btnDeleteUserSkill.Click += btnDeleteUserSkill_Click;
            // 
            // txtName
            // 
            txtName.Location = new Point(799, 42);
            txtName.Name = "txtName";
            txtName.Size = new Size(230, 27);
            txtName.TabIndex = 0;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(799, 119);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(230, 27);
            txtEmail.TabIndex = 1;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(942, 302);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(92, 34);
            btnSave.TabIndex = 3;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // txtSkillName
            // 
            txtSkillName.Location = new Point(776, 418);
            txtSkillName.Name = "txtSkillName";
            txtSkillName.Size = new Size(185, 27);
            txtSkillName.TabIndex = 6;
            // 
            // btnUpdateUserSkill
            // 
            btnUpdateUserSkill.Location = new Point(468, 515);
            btnUpdateUserSkill.Name = "btnUpdateUserSkill";
            btnUpdateUserSkill.Size = new Size(107, 29);
            btnUpdateUserSkill.TabIndex = 13;
            btnUpdateUserSkill.Text = "Update ";
            btnUpdateUserSkill.UseVisualStyleBackColor = true;
            btnUpdateUserSkill.Click += btnUpdateUserSkill_Click;
            // 
            // btnDeleteUser
            // 
            btnDeleteUser.Location = new Point(778, 302);
            btnDeleteUser.Name = "btnDeleteUser";
            btnDeleteUser.Size = new Size(100, 29);
            btnDeleteUser.TabIndex = 5;
            btnDeleteUser.Text = "DeleteUser";
            btnDeleteUser.UseVisualStyleBackColor = true;
            btnDeleteUser.Click += btnDeleteUser_Click;
            // 
            // btnUpdateUser
            // 
            btnUpdateUser.Location = new Point(620, 305);
            btnUpdateUser.Name = "btnUpdateUser";
            btnUpdateUser.Size = new Size(105, 29);
            btnUpdateUser.TabIndex = 4;
            btnUpdateUser.Text = "UpdateUser";
            btnUpdateUser.UseVisualStyleBackColor = true;
            btnUpdateUser.Click += btnUpdateUser_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(776, 383);
            label1.Name = "label1";
            label1.Size = new Size(102, 20);
            label1.TabIndex = 15;
            label1.Text = "Add New Skill";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(25, 363);
            label2.Name = "label2";
            label2.Size = new Size(38, 20);
            label2.TabIndex = 16;
            label2.Text = "User";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(20, 446);
            label3.Name = "label3";
            label3.Size = new Size(36, 20);
            label3.TabIndex = 17;
            label3.Text = "Skill";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(378, 368);
            label4.Name = "label4";
            label4.Size = new Size(81, 20);
            label4.TabIndex = 18;
            label4.Text = "Proficiency";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(799, 161);
            label5.Name = "label5";
            label5.Size = new Size(70, 20);
            label5.TabIndex = 19;
            label5.Text = "Password";
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(799, 184);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(230, 27);
            txtPassword.TabIndex = 2;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(799, 86);
            label6.Name = "label6";
            label6.Size = new Size(46, 20);
            label6.TabIndex = 21;
            label6.Text = "Email";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(799, 9);
            label7.Name = "label7";
            label7.Size = new Size(49, 20);
            label7.TabIndex = 22;
            label7.Text = "Name";
            // 
            // btnDeleteSkill
            // 
            btnDeleteSkill.Location = new Point(240, 515);
            btnDeleteSkill.Name = "btnDeleteSkill";
            btnDeleteSkill.Size = new Size(94, 29);
            btnDeleteSkill.TabIndex = 14;
            btnDeleteSkill.Text = "Delete";
            btnDeleteSkill.UseVisualStyleBackColor = true;
            btnDeleteSkill.Click += btnDeleteSkill_Click;
            // 
            // departmentLabel
            // 
            departmentLabel.AutoSize = true;
            departmentLabel.Location = new Point(596, 27);
            departmentLabel.Name = "departmentLabel";
            departmentLabel.Size = new Size(50, 20);
            departmentLabel.TabIndex = 24;
            departmentLabel.Text = "label8";
            // 
            // UserSkillTrackingForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.BlueViolet;
            BackgroundImage = SkillTrackerApp.Properties.Resources._360_F_641621701_e5JZgtGovFl7uD3UNaTEOrSYAUdAyUIJ;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1059, 556);
            Controls.Add(departmentLabel);
            Controls.Add(btnDeleteSkill);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(txtPassword);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnUpdateUser);
            Controls.Add(btnDeleteUser);
            Controls.Add(btnUpdateUserSkill);
            Controls.Add(txtSkillName);
            Controls.Add(btnSave);
            Controls.Add(txtEmail);
            Controls.Add(txtName);
            Controls.Add(btnDeleteUserSkill);
            Controls.Add(btnAssignSkill);
            Controls.Add(btnAddUserSkill);
            Controls.Add(dataGridUserSkills);
            Controls.Add(txtProficiency);
            Controls.Add(cmbAssignUser);
            Controls.Add(cmbAssignSkill);
            Name = "UserSkillTrackingForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Manager Page";
            Load += UserSkillTrackingForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridUserSkills).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }






        #endregion

        private ComboBox cmbAssignSkill;
        private ComboBox cmbAssignUser;
        private TextBox txtProficiency;
        private DataGridView dataGridUserSkills;
        private Button btnAddUserSkill;
        private Button btnAssignSkill;
        private Button btnDeleteUserSkill;
        private TextBox txtName;
        private TextBox txtEmail;
        private Button btnSave;
        private TextBox txtSkillName;
        private Button btnUpdateUserSkill;
        private Button btnDeleteUser;
        private Button btnUpdateUser;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private TextBox txtPassword;
        private Label label6;
        private Label label7;
        private Button btnDeleteSkill;
        private Label departmentLabel;
    }
}