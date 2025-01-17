using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SkillTrackerApp
{
    public partial class GeneralManagerForm : Form
    {
        public GeneralManagerForm()
        {
            InitializeComponent();
        }

        private void btnModifyData_Click(object sender, EventArgs e)
        {
            frmModifyData modifyDataForm = new frmModifyData();
            modifyDataForm.Show();
            this.Hide();
        }

        private void btnViewDepartments_Click(object sender, EventArgs e)
        {
            var data = GetDepartmentsWithManagers();
            DGV_Departments.DataSource = data;
        }

    
        public DataTable GetBestEmployeeInEachDepartment()
        {
            DataTable dataTable = new DataTable();
            string query = @"
        SELECT D.DepartmentName, U.Name AS EmployeeName, MAX(US.ProficiencyLevel) AS SkillProficiency
        FROM Departments D
        JOIN Users U ON D.DepartmentID = U.DepartmentID
        JOIN UserSkills US ON U.UserID = US.UserID
        GROUP BY D.DepartmentName, U.Name;
        ";

            using (SqlConnection conn = new SqlConnection("Data Source=.\\SQLEXPRESS01;Initial catalog=SkillTrackerDB;Integrated Security=true"))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dataTable);
                }
            }
            return dataTable;
        }
        public DataTable GetDepartmentsWithManagers()
        {
            DataTable dataTable = new DataTable();
            string query = @"
        SELECT D.DepartmentName, U.Name AS ManagerName
        FROM Departments D
        LEFT JOIN Users U ON D.DepartmentID = U.DepartmentID
        WHERE U.Role = 'Department Manager';
        ";

            using (SqlConnection conn = new SqlConnection("Data Source=.\\SQLEXPRESS01;Initial catalog=SkillTrackerDB;Integrated Security=true"))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dataTable);
                }
            }
            return dataTable;
        }

        private void btnViewBestEmployees_Click(object sender, EventArgs e)
        {
            var data = GetBestEmployeeInEachDepartment();
            DGV_BestEmployees.DataSource = data;
        }
    }
}
