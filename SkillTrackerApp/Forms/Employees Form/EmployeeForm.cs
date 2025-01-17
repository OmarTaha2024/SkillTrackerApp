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
    public partial class EmployeeForm : Form
    {
        private readonly string connectionString = "Data Source=.\\SQLEXPRESS01;Initial Catalog=SkillTrackerDB;Integrated Security=true";
        private readonly int EmployeeId;
        private readonly int UserID;

        public EmployeeForm(int departmentId, int UserId)
        {
            InitializeComponent();
            EmployeeId = departmentId;
            UserID = UserId;
        }
        private void LoadUserSkills()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"SELECT us.UserSkillID, u.Name AS UserName, s.SkillName, us.ProficiencyLevel 
                                     FROM UserSkills us
                                     INNER JOIN Users u ON us.UserID = u.UserID
                                     INNER JOIN Skills s ON us.SkillID = s.SkillID
                                     WHERE u.DepartmentID = @DepartmentID";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    adapter.SelectCommand.Parameters.AddWithValue("@DepartmentID", EmployeeId);

                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dgvViewMembersData.DataSource = null;
                    dgvViewMembersData.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading user skills: {ex.Message}");
            }
        }

        private void LoadUserData()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"SELECT 
    s.SkillName,
    us.ProficiencyLevel
FROM 
    Users u
LEFT JOIN 
    UserSkills us ON u.UserID = us.UserID
LEFT JOIN 
    Skills s ON us.SkillID = s.SkillID
WHERE 
    u.Role = 'Employee' AND u.UserID = @UserID;";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    adapter.SelectCommand.Parameters.AddWithValue("@UserID", UserID);

                    MessageBox.Show($" UserID: {UserID}");
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dgvViewMemberData.DataSource = null;
                    dgvViewMemberData.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading user skills: {ex.Message}");
            }

        }
        private void LoadDepartmentName()
        {
            string query = "SELECT d.DepartmentName FROM Users u LEFT JOIN Departments d ON u.DepartmentID = d.DepartmentID WHERE u.UserID = @UserID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@UserID", UserID);

                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();

                    if (result != null)
                    {
                        string departmentName = result.ToString();
                        departmentLabel.Text = departmentName;
                        departmentLabel.Font = new Font(departmentLabel.Font.FontFamily, 18, FontStyle.Bold);
                    }
                    else
                    {
                        departmentLabel.Text = "No Department Assigned";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
            }
        }

        private void btnMembersData_Click(object sender, EventArgs e)
        {
            LoadUserSkills();
        }



        private void btnMemberData_Click(object sender, EventArgs e)
        {
            LoadUserData();
        }

        private void EmployeeForm_Load(object sender, EventArgs e)
        {
            LoadDepartmentName();
        }
    }
}
