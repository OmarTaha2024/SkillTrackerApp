namespace SkillTrackerApp
{
    partial class EmployeeForm
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
            dgvViewMemberData = new DataGridView();
            dgvViewMembersData = new DataGridView();
            btnMemberData = new Button();
            btnMembersData = new Button();
            departmentLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvViewMemberData).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvViewMembersData).BeginInit();
            SuspendLayout();
            // 
            // dgvViewMemberData
            // 
            dgvViewMemberData.BackgroundColor = Color.White;
            dgvViewMemberData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvViewMemberData.Location = new Point(0, -3);
            dgvViewMemberData.Name = "dgvViewMemberData";
            dgvViewMemberData.RowHeadersWidth = 51;
            dgvViewMemberData.Size = new Size(322, 261);
            dgvViewMemberData.TabIndex = 0;
            // 
            // dgvViewMembersData
            // 
            dgvViewMembersData.BackgroundColor = Color.White;
            dgvViewMembersData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvViewMembersData.Location = new Point(501, -3);
            dgvViewMembersData.Name = "dgvViewMembersData";
            dgvViewMembersData.RowHeadersWidth = 51;
            dgvViewMembersData.Size = new Size(592, 261);
            dgvViewMembersData.TabIndex = 1;
            // 
            // btnMemberData
            // 
            btnMemberData.Location = new Point(83, 299);
            btnMemberData.Name = "btnMemberData";
            btnMemberData.Size = new Size(151, 29);
            btnMemberData.TabIndex = 2;
            btnMemberData.Text = "Employee Data ";
            btnMemberData.UseVisualStyleBackColor = true;
            btnMemberData.Click += btnMemberData_Click;
            // 
            // btnMembersData
            // 
            btnMembersData.Location = new Point(807, 299);
            btnMembersData.Name = "btnMembersData";
            btnMembersData.Size = new Size(153, 29);
            btnMembersData.TabIndex = 3;
            btnMembersData.Text = "Department Data";
            btnMembersData.UseVisualStyleBackColor = true;
            btnMembersData.Click += btnMembersData_Click;
            // 
            // departmentLabel
            // 
            departmentLabel.AutoSize = true;
            departmentLabel.Location = new Point(353, 20);
            departmentLabel.Name = "departmentLabel";
            departmentLabel.Size = new Size(50, 20);
            departmentLabel.TabIndex = 5;
            departmentLabel.Text = "label1";
            // 
            // EmployeeForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoValidate = AutoValidate.EnableAllowFocusChange;
            BackColor = Color.DarkSlateBlue;
            BackgroundImage = Properties.Resources.pngtree_a_huge_glassy_building_image_129969271;
            ClientSize = new Size(1087, 426);
            Controls.Add(departmentLabel);
            Controls.Add(btnMembersData);
            Controls.Add(btnMemberData);
            Controls.Add(dgvViewMembersData);
            Controls.Add(dgvViewMemberData);
            Name = "EmployeeForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "EmployeeForm";
            Load += EmployeeForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvViewMemberData).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvViewMembersData).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvViewMemberData;
        private DataGridView dgvViewMembersData;
        private Button btnMemberData;
        private Button btnMembersData;
        private Label departmentLabel;
    }
}