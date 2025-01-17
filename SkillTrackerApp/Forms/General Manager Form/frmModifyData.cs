using Microsoft.VisualBasic.ApplicationServices;
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
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SkillTrackerApp
{
    public partial class frmModifyData : Form
    {
        public frmModifyData()
        {
            InitializeComponent();
        }
        public DataTable GetAllManagers()
        {
            string query = "SELECT UserID, Name FROM Users WHERE Role = 'Department Manager'";
            DataTable managers = new DataTable();
            using (SqlConnection conn = new SqlConnection("Data Source=.\\SQLEXPRESS01;Initial catalog=SkillTrackerDB;Integrated Security=true"))
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter(query, conn))
                {
                    adapter.Fill(managers);
                }
            }
            return managers;
        }

        public DataTable GetAllDepartments()
        {
            string query = "SELECT DepartmentID, DepartmentName FROM Departments";
            DataTable departments = new DataTable();
            using (SqlConnection conn = new SqlConnection("Data Source=.\\SQLEXPRESS01;Initial catalog=SkillTrackerDB;Integrated Security=true"))
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter(query, conn))
                {
                    adapter.Fill(departments);
                }
            }
            return departments;
        }

        public void AssignManagerToDepartment(int departmentID, int managerID)
        {
            string query = "UPDATE Users SET DepartmentID = @DepartmentID WHERE UserID = @ManagerID";
            using (SqlConnection conn = new SqlConnection("Data Source=.\\SQLEXPRESS01;Initial catalog=SkillTrackerDB;Integrated Security=true"))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ManagerID", managerID);
                    cmd.Parameters.AddWithValue("@DepartmentID", departmentID);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void AddDepartment(string departmentName)
        {
            string query = "INSERT INTO Departments (DepartmentName) VALUES (@DepartmentName)";
            using (SqlConnection conn = new SqlConnection("Data Source=.\\SQLEXPRESS01;Initial catalog=SkillTrackerDB;Integrated Security=true"))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@DepartmentName", departmentName);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void AddManager(string name, string email, string password)
        {
            string query = "INSERT INTO Users (Name, Email, Password, Role) VALUES (@Name, @Email, @Password, 'Department Manager')";
            using (SqlConnection conn = new SqlConnection("Data Source=.\\SQLEXPRESS01;Initial catalog=SkillTrackerDB;Integrated Security=true"))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Name", name);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Password", password);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void DeleteManager(int managerID)
        {
            string query = "DELETE FROM Users WHERE UserID = @ManagerID";
            using (SqlConnection conn = new SqlConnection("Data Source=.\\SQLEXPRESS01;Initial catalog=SkillTrackerDB;Integrated Security=true"))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ManagerID", managerID);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    RefreshData();
                }
            }
        }
        public void DeleteDepartment(int departmentID)
        {
            string query = "DELETE FROM Departments WHERE DepartmentID = @departmentID";
            using (SqlConnection conn = new SqlConnection("Data Source=.\\SQLEXPRESS01;Initial catalog=SkillTrackerDB;Integrated Security=true"))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@departmentID", departmentID);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    RefreshData();
                }
            }
        }
        public void UpdateManager(int managerID, string name, string email, string password)
        {
            string query = "UPDATE Users SET Name = @Name, Email = @Email, [Password] = @password WHERE UserID = @ManagerID";

            using (SqlConnection conn = new SqlConnection("Data Source=.\\SQLEXPRESS01;Initial Catalog=SkillTrackerDB;Integrated Security=true"))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    try
                    {
                        cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = name;
                        cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = email;
                        cmd.Parameters.Add("@password", SqlDbType.NVarChar).Value = password;
                        cmd.Parameters.Add("@ManagerID", SqlDbType.Int).Value = managerID;

                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        // Log or handle the exception
                        throw new Exception("An error occurred while updating the manager.", ex);
                    }
                }
            }
        }



        private void LoadUsers()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection("Data Source=.\\SQLEXPRESS01;Initial catalog=SkillTrackerDB;Integrated Security=true"))
                {
                    conn.Open();
                    string query = "SELECT UserID, Name FROM Users where Role = 'Department Manager'";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    cmbManagers.DataSource = null;
                    cmbManagers.DataSource = dt;
                    cmbManagers.DisplayMember = "Name";
                    cmbManagers.ValueMember = "UserID";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading users: {ex.Message}");
            }
        }

        private void LoadDepartments()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection("Data Source=.\\SQLEXPRESS01;Initial catalog=SkillTrackerDB;Integrated Security=true"))
                {
                    conn.Open();
                    string query = "SELECT DepartmentID, DepartmentName FROM Departments";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    cmbDepartments.DataSource = null;
                    cmbDepartments.DataSource = dt;
                    cmbDepartments.DisplayMember = "DepartmentName";
                    cmbDepartments.ValueMember = "DepartmentID";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading skills: {ex.Message}");
            }
        }

        private void btnAssign_Click(object sender, EventArgs e)
        {
            int departmentID = Convert.ToInt32(cmbDepartments.SelectedValue);
            int managerID = Convert.ToInt32(cmbManagers.SelectedValue);

            AssignManagerToDepartment(departmentID, managerID);
            MessageBox.Show("Manager assigned to department.");
            RefreshData();
        }

        private void btnAddDepartment_Click(object sender, EventArgs e)
        {
            string departmentName = txtDepartmentName.Text;

            if (!string.IsNullOrEmpty(departmentName))
            {
                AddDepartment(departmentName);
                MessageBox.Show("Department added.");
                RefreshData(); // Reload ComboBoxes and DataGridView
            }
            else
            {
                MessageBox.Show("Please enter a department name.");
            }
        }

        private void RefreshData()
        {
            cmbDepartments.DataSource = GetAllDepartments();
            cmbDepartments.DisplayMember = "DepartmentName";
            cmbDepartments.ValueMember = "DepartmentID";

            cmbManagers.DataSource = GetAllManagers();
            cmbManagers.DisplayMember = "Name";
            cmbManagers.ValueMember = "UserID";

             GetDepartmentsWithManagers();
        }
        private void GetDepartmentsWithManagers()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection("Data Source=.\\SQLEXPRESS01;Initial Catalog=SkillTrackerDB;Integrated Security=true"))
                {
                    connection.Open();
                    string query = @"
                SELECT D.DepartmentName, U.Name AS ManagerName
                FROM Departments D
                LEFT JOIN Users U ON D.DepartmentID = U.DepartmentID
                WHERE U.Role = 'Department Manager'";

                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable departmentsTable = new DataTable();
                    adapter.Fill(departmentsTable);
                    dgvDepartments.DataSource = null;
                    dgvDepartments.DataSource = departmentsTable;
           


                }
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show($"Database error: {sqlEx.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }


        private void btnSaveManager_Click(object sender, EventArgs e)
        {
            string name = txtManagerName.Text;
            string email = txtManagerEmail.Text;
            string password = txtManagerPassword.Text;

            if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(password))
            {
                AddManager(name, email, password);
                MessageBox.Show("Manager added.");
                RefreshData(); 
            }
            else
            {
                MessageBox.Show("Please fill all manager details.");
            }
        }
      
        private void frmModifyData_Load(object sender, EventArgs e)
        {
            GetDepartmentsWithManagers();

            LoadUsers();
            LoadDepartments();
        }

        private void btnDeleteRow_Click(object sender, EventArgs e)
        {
            DeleteManager(Convert.ToInt32(cmbManagers.SelectedValue));
        }

        private void BtnDeleteDept_Click(object sender, EventArgs e)
        {
            DeleteDepartment(Convert.ToInt32(cmbDepartments.SelectedValue));
        }
        private int selectManagerId(string managerName)
        {
            try
            {
                int managerId = -1; 
                string connectionString = "Data Source=.\\SQLEXPRESS01;Initial Catalog=SkillTrackerDB;Integrated Security=true";

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string query = "SELECT UserID FROM Users WHERE Role = 'Department Manager' AND Name = @Name";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Name", managerName); // Use parameters to prevent SQL injection

                        object result = cmd.ExecuteScalar();

                        if (result != null && int.TryParse(result.ToString(), out int id))
                        {
                            managerId = id; 
                        }
                    }
                }

                return managerId; 
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading users: {ex.Message}");
                return -1; 
            }
        }

        private void btnUpdateManager_Click(object sender, EventArgs e)
        {
            int managerid = selectManagerId(txtManagerName.Text);
            string name = txtManagerName.Text;
            string email = txtManagerEmail.Text;
            string password = txtManagerPassword.Text;

            UpdateManager(managerid, name,email, password);
            MessageBox.Show("All Manager Data updated ");

            RefreshData();

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Form formToOpen;
            formToOpen = new GeneralManagerForm();
            formToOpen.Show();
            this.Hide();
        }
    }
}
