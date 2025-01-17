namespace SkillTrackerApp
{
    partial class frmModifyData
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
            cmbManagers = new ComboBox();
            cmbDepartments = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            btnAddDepartment = new Button();
            btnAssign = new Button();
            label3 = new Label();
            txtDepartmentName = new TextBox();
            txtManagerEmail = new TextBox();
            txtManagerName = new TextBox();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            btnSaveManager = new Button();
            btnUpdateManager = new Button();
            btnDeleteRow = new Button();
            txtManagerPassword = new TextBox();
            BtnDeleteDept = new Button();
            btnBack = new Button();
            dgvDepartments = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvDepartments).BeginInit();
            SuspendLayout();
            // 
            // cmbManagers
            // 
            cmbManagers.FormattingEnabled = true;
            cmbManagers.Location = new Point(125, 336);
            cmbManagers.Name = "cmbManagers";
            cmbManagers.Size = new Size(178, 28);
            cmbManagers.TabIndex = 7;
            // 
            // cmbDepartments
            // 
            cmbDepartments.FormattingEnabled = true;
            cmbDepartments.Location = new Point(125, 398);
            cmbDepartments.Name = "cmbDepartments";
            cmbDepartments.Size = new Size(178, 28);
            cmbDepartments.TabIndex = 8;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 339);
            label1.Name = "label1";
            label1.Size = new Size(68, 20);
            label1.TabIndex = 3;
            label1.Text = "Manager";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 398);
            label2.Name = "label2";
            label2.Size = new Size(89, 20);
            label2.TabIndex = 4;
            label2.Text = "Department";
            // 
            // btnAddDepartment
            // 
            btnAddDepartment.Location = new Point(789, 490);
            btnAddDepartment.Name = "btnAddDepartment";
            btnAddDepartment.Size = new Size(148, 29);
            btnAddDepartment.TabIndex = 6;
            btnAddDepartment.Text = "Add Department ";
            btnAddDepartment.UseVisualStyleBackColor = true;
            btnAddDepartment.Click += btnAddDepartment_Click;
            // 
            // btnAssign
            // 
            btnAssign.Location = new Point(161, 443);
            btnAssign.Name = "btnAssign";
            btnAssign.Size = new Size(102, 29);
            btnAssign.TabIndex = 9;
            btnAssign.Text = "Assign ";
            btnAssign.UseVisualStyleBackColor = true;
            btnAssign.Click += btnAssign_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(628, 434);
            label3.Name = "label3";
            label3.Size = new Size(123, 20);
            label3.TabIndex = 9;
            label3.Text = "New Department";
            // 
            // txtDepartmentName
            // 
            txtDepartmentName.Location = new Point(771, 427);
            txtDepartmentName.Name = "txtDepartmentName";
            txtDepartmentName.Size = new Size(176, 27);
            txtDepartmentName.TabIndex = 5;
            // 
            // txtManagerEmail
            // 
            txtManagerEmail.Location = new Point(766, 105);
            txtManagerEmail.Name = "txtManagerEmail";
            txtManagerEmail.Size = new Size(210, 27);
            txtManagerEmail.TabIndex = 2;
            // 
            // txtManagerName
            // 
            txtManagerName.Location = new Point(766, 38);
            txtManagerName.Name = "txtManagerName";
            txtManagerName.Size = new Size(210, 27);
            txtManagerName.TabIndex = 1;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(602, 38);
            label4.Name = "label4";
            label4.Size = new Size(112, 20);
            label4.TabIndex = 13;
            label4.Text = "Manager Name";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(602, 105);
            label5.Name = "label5";
            label5.Size = new Size(109, 20);
            label5.TabIndex = 14;
            label5.Text = "Manager Email";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(602, 175);
            label6.Name = "label6";
            label6.Size = new Size(133, 20);
            label6.TabIndex = 15;
            label6.Text = "Manager Password";
            // 
            // btnSaveManager
            // 
            btnSaveManager.Location = new Point(873, 291);
            btnSaveManager.Name = "btnSaveManager";
            btnSaveManager.Size = new Size(94, 29);
            btnSaveManager.TabIndex = 4;
            btnSaveManager.Text = "Save";
            btnSaveManager.UseVisualStyleBackColor = true;
            btnSaveManager.Click += btnSaveManager_Click;
            // 
            // btnUpdateManager
            // 
            btnUpdateManager.Location = new Point(710, 291);
            btnUpdateManager.Name = "btnUpdateManager";
            btnUpdateManager.Size = new Size(94, 29);
            btnUpdateManager.TabIndex = 17;
            btnUpdateManager.Text = "Update";
            btnUpdateManager.UseVisualStyleBackColor = true;
            btnUpdateManager.Click += btnUpdateManager_Click;
            // 
            // btnDeleteRow
            // 
            btnDeleteRow.Location = new Point(341, 339);
            btnDeleteRow.Name = "btnDeleteRow";
            btnDeleteRow.Size = new Size(148, 29);
            btnDeleteRow.TabIndex = 10;
            btnDeleteRow.Text = "Delete Manager";
            btnDeleteRow.UseVisualStyleBackColor = true;
            btnDeleteRow.Click += btnDeleteRow_Click;
            // 
            // txtManagerPassword
            // 
            txtManagerPassword.Location = new Point(766, 175);
            txtManagerPassword.Name = "txtManagerPassword";
            txtManagerPassword.Size = new Size(215, 27);
            txtManagerPassword.TabIndex = 3;
            // 
            // BtnDeleteDept
            // 
            BtnDeleteDept.Location = new Point(341, 398);
            BtnDeleteDept.Name = "BtnDeleteDept";
            BtnDeleteDept.Size = new Size(148, 29);
            BtnDeleteDept.TabIndex = 11;
            BtnDeleteDept.Text = "Delete Department";
            BtnDeleteDept.UseVisualStyleBackColor = true;
            BtnDeleteDept.Click += BtnDeleteDept_Click;
            // 
            // btnBack
            // 
            btnBack.Location = new Point(448, 560);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(94, 29);
            btnBack.TabIndex = 21;
            btnBack.Text = "Back";
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += btnBack_Click;
            // 
            // dgvDepartments
            // 
            dgvDepartments.BackgroundColor = Color.White;
            dgvDepartments.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDepartments.Location = new Point(0, 0);
            dgvDepartments.Name = "dgvDepartments";
            dgvDepartments.RowHeadersWidth = 51;
            dgvDepartments.Size = new Size(303, 320);
            dgvDepartments.TabIndex = 22;
            // 
            // frmModifyData
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Info;
            BackgroundImage = Properties.Resources.pexels_nikitapishchugin_29282323;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1004, 601);
            Controls.Add(dgvDepartments);
            Controls.Add(btnBack);
            Controls.Add(BtnDeleteDept);
            Controls.Add(txtManagerPassword);
            Controls.Add(btnDeleteRow);
            Controls.Add(btnUpdateManager);
            Controls.Add(btnSaveManager);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(txtManagerName);
            Controls.Add(txtManagerEmail);
            Controls.Add(txtDepartmentName);
            Controls.Add(label3);
            Controls.Add(btnAssign);
            Controls.Add(btnAddDepartment);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(cmbDepartments);
            Controls.Add(cmbManagers);
            Name = "frmModifyData";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ModifyData";
            Load += frmModifyData_Load;
            ((System.ComponentModel.ISupportInitialize)dgvDepartments).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private ComboBox cmbManagers;
        private ComboBox cmbDepartments;
        private Label label1;
        private Label label2;
        private Button btnAddDepartment;
        private Button btnAssign;
        private Button btnUpdateDept;
        private Button btnDelete;
        private Label label3;
        private TextBox txtDepartmentName;
        private TextBox txtManagerEmail;
        private TextBox txtManagerName;
        private Label label4;
        private Label label5;
        private Label label6;
        private Button btnSaveManager;
        private Button btnUpdateManager;
        private Button btnDeleteRow;
        private TextBox txtManagerPassword;
        private Button BtnDeleteDept;
        private Button btnBack;
        private DataGridView dgvDepartments;
    }
}