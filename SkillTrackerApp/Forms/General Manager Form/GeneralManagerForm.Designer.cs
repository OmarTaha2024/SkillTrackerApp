namespace SkillTrackerApp
{
    partial class GeneralManagerForm
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
            DGV_Departments = new DataGridView();
            DGV_BestEmployees = new DataGridView();
            btnModifyData = new Button();
            btnViewDepartments = new Button();
            btnViewBestEmployees = new Button();
            ((System.ComponentModel.ISupportInitialize)DGV_Departments).BeginInit();
            ((System.ComponentModel.ISupportInitialize)DGV_BestEmployees).BeginInit();
            SuspendLayout();
            // 
            // DGV_Departments
            // 
            DGV_Departments.BackgroundColor = Color.White;
            DGV_Departments.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DGV_Departments.Location = new Point(71, 12);
            DGV_Departments.Name = "DGV_Departments";
            DGV_Departments.RowHeadersWidth = 51;
            DGV_Departments.Size = new Size(306, 265);
            DGV_Departments.TabIndex = 3;
            // 
            // DGV_BestEmployees
            // 
            DGV_BestEmployees.BackgroundColor = Color.White;
            DGV_BestEmployees.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DGV_BestEmployees.Location = new Point(655, 12);
            DGV_BestEmployees.Name = "DGV_BestEmployees";
            DGV_BestEmployees.RowHeadersWidth = 51;
            DGV_BestEmployees.Size = new Size(429, 255);
            DGV_BestEmployees.TabIndex = 4;
            // 
            // btnModifyData
            // 
            btnModifyData.Location = new Point(498, 474);
            btnModifyData.Name = "btnModifyData";
            btnModifyData.Size = new Size(100, 29);
            btnModifyData.TabIndex = 2;
            btnModifyData.Text = "ModifyData ";
            btnModifyData.UseVisualStyleBackColor = true;
            btnModifyData.Click += btnModifyData_Click;
            // 
            // btnViewDepartments
            // 
            btnViewDepartments.Location = new Point(123, 301);
            btnViewDepartments.Name = "btnViewDepartments";
            btnViewDepartments.Size = new Size(176, 29);
            btnViewDepartments.TabIndex = 0;
            btnViewDepartments.Text = "ViewDepartments";
            btnViewDepartments.UseVisualStyleBackColor = true;
            btnViewDepartments.Click += btnViewDepartments_Click;
            // 
            // btnViewBestEmployees
            // 
            btnViewBestEmployees.Location = new Point(820, 301);
            btnViewBestEmployees.Name = "btnViewBestEmployees";
            btnViewBestEmployees.Size = new Size(178, 29);
            btnViewBestEmployees.TabIndex = 1;
            btnViewBestEmployees.Text = "ViewBestEmployees";
            btnViewBestEmployees.UseVisualStyleBackColor = true;
            btnViewBestEmployees.Click += btnViewBestEmployees_Click;
            // 
            // GeneralManagerForm
            // 
            AcceptButton = btnModifyData;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonFace;
            BackgroundImage = Properties.Resources.pngtree_a_huge_glassy_building_image_12996927;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1123, 539);
            Controls.Add(btnViewBestEmployees);
            Controls.Add(btnViewDepartments);
            Controls.Add(btnModifyData);
            Controls.Add(DGV_BestEmployees);
            Controls.Add(DGV_Departments);
            Name = "GeneralManagerForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "GeneralManagerForm";
            ((System.ComponentModel.ISupportInitialize)DGV_Departments).EndInit();
            ((System.ComponentModel.ISupportInitialize)DGV_BestEmployees).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView DGV_Departments;
        private DataGridView DGV_BestEmployees;
        private Button btnModifyData;
        private Button btnViewDepartments;
        private Button btnViewBestEmployees;
    }
}