using Microsoft.VisualBasic.ApplicationServices;
using SkillManagementForm;
using System.Data.SqlClient;

namespace SkillTrackerApp
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=.\\SQLEXPRESS01;Initial catalog=SkillTrackerDB;Integrated Security=true";
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Updated query to fetch Role and DepartmentID
                    string query = "SELECT UserID,Role, DepartmentID FROM Users WHERE Email = @Username AND Password = @Password";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Username", username);
                    command.Parameters.AddWithValue("@Password", password);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string role = reader["Role"].ToString();
                            int? departmentId = reader["DepartmentID"] as int?;
                            int? UserId = reader["UserID"] as int?;
                       

                            OpenFormBasedOnRole(role, departmentId, UserId);
                        }
                        else
                        {
                            MessageBox.Show("Invalid username or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void OpenFormBasedOnRole(string role, int? departmentId , int? UserId)
        {
            Form formToOpen;

            switch (role)
            {
                case "General Manager":
                    formToOpen = new GeneralManagerForm(); 
                    break;
                case "Department Manager":
                    if (departmentId.HasValue)
                    {
                        formToOpen = new UserSkillTrackingForm(departmentId.Value);
                    }
                    else
                    {
                        MessageBox.Show("No department assigned to this manager.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    break;
                case "Employee":
                    if (departmentId.HasValue)
                        formToOpen = new EmployeeForm(departmentId.Value, UserId.Value);
            
                    else
                    {
                MessageBox.Show("No department assigned to this Employee.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
                    }
            break;
                default:
                    MessageBox.Show("Unknown role.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
            }

            formToOpen.Show();
            this.Hide();
        }
    }
}
