using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SkillManagementForm
{
    public partial class UserSkillTrackingForm : Form
    {
        private readonly string connectionString = "Data Source=.\\SQLEXPRESS01;Initial Catalog=SkillTrackerDB;Integrated Security=true";
        private readonly int managerDepartmentId;

        public UserSkillTrackingForm(int departmentId)
        {
            InitializeComponent();
            managerDepartmentId = departmentId;
        }

        private void LoadUsers()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT UserID, Name FROM Users WHERE DepartmentID = @DepartmentID And Role ='Employee'";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    adapter.SelectCommand.Parameters.AddWithValue("@DepartmentID", managerDepartmentId);

                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    cmbAssignUser.DataSource = null;
                    cmbAssignUser.DataSource = dt;
                    cmbAssignUser.DisplayMember = "Name";
                    cmbAssignUser.ValueMember = "UserID";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading users: {ex.Message}");
            }
        }

        private void LoadSkills()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT SkillID, SkillName FROM Skills WHERE DepartmentID = @DepartmentID";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    adapter.SelectCommand.Parameters.AddWithValue("@DepartmentID", managerDepartmentId);

                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    cmbAssignSkill.DataSource = null;
                    cmbAssignSkill.DataSource = dt;
                    cmbAssignSkill.DisplayMember = "SkillName";
                    cmbAssignSkill.ValueMember = "SkillID";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading skills: {ex.Message}");
            }
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
                    adapter.SelectCommand.Parameters.AddWithValue("@DepartmentID", managerDepartmentId);

                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dataGridUserSkills.DataSource = null;
                    dataGridUserSkills.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading user skills: {ex.Message}");
            }
        }



        private void LoadDepartmentName()
        {
            string query = "Select DepartmentName from Departments where DepartmentID =@departmentID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@departmentID", managerDepartmentId);

                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();

                    if (result != null)
                    {
                        string departmentName = result.ToString();
                        departmentLabel.Text = departmentName;
                        departmentLabel.Font = new Font(departmentLabel.Font.FontFamily, 22, FontStyle.Bold);
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
        private void UserSkillTrackingForm_Load(object sender, EventArgs e)
        {
            LoadUsers();
            LoadSkills();
            LoadUserSkills();
            LoadDepartmentName();
        }

        private void btnAddUserSkill_Click(object sender, EventArgs e)
        {
            AddSkillAndAssignToDepartment(txtSkillName.Text);
            LoadUsers();
            LoadSkills();
            LoadUserSkills();
        }

        private void btnAssignSkill_Click(object sender, EventArgs e)
        {
            if (cmbAssignUser.SelectedValue != null && cmbAssignSkill.SelectedValue != null)
            {
                AssignSkillToUser(
                    userId: Convert.ToInt32(cmbAssignUser.SelectedValue),
                    skillId: Convert.ToInt32(cmbAssignSkill.SelectedValue),
                    proficiencyLevel: txtProficiency.Text
                );
            }
            else
            {
                MessageBox.Show("Please select valid user and skill.");
            }
        }

        private void AssignSkillToUser(int userId, int skillId, string proficiencyLevel)
        {
            if (userId <= 0 || skillId <= 0 || string.IsNullOrWhiteSpace(proficiencyLevel))
            {
                MessageBox.Show("All fields are required for skill assignment.");
                return;
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "INSERT INTO UserSkills (UserID, SkillID, ProficiencyLevel) VALUES (@UserID, @SkillID, @ProficiencyLevel)";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserID", userId);
                        command.Parameters.AddWithValue("@SkillID", skillId);
                        command.Parameters.AddWithValue("@ProficiencyLevel", proficiencyLevel);

                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Skill assigned to user successfully!");
                LoadUserSkills(); // Refresh the DataGridView dynamically
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error assigning skill: {ex.Message}");
            }
        }
        private void btnUpdateUserSkill_Click(object sender, EventArgs e)
        {
            if (dataGridUserSkills.SelectedRows.Count > 0)
            {
                int userSkillID = Convert.ToInt32(dataGridUserSkills.SelectedRows[0].Cells["UserSkillID"].Value);
                

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "UPDATE UserSkills SET ProficiencyLevel = @ProficiencyLevel WHERE UserSkillID = @UserSkillID";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@ProficiencyLevel", txtProficiency.Text);
                        cmd.Parameters.AddWithValue("@UserSkillID", userSkillID);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("User skill updated!");
                        LoadUserSkills();
                    }
                }
            }
            else
            {
                MessageBox.Show("Select a skill to update!");
            }
        }

        private void btnDeleteUserSkill_Click(object sender, EventArgs e)
        {
            DeleteSkillAndUnassignFromDepartment(txtSkillName.Text);
            LoadUsers();
            LoadSkills();
            LoadUserSkills();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            AddUserAndAssignSkills(txtName.Text, txtEmail.Text, txtPassword.Text);
            LoadUsers();
            LoadSkills();
            LoadUserSkills();
        }

        private void btnUpdateUser_Click(object sender, EventArgs e)
        {
            if (cmbAssignUser.SelectedValue != null)
            {
                UpdateUser(
                    userId: Convert.ToInt32(cmbAssignUser.SelectedValue),
                    name: txtName.Text,
                    email: txtEmail.Text,
                    password: txtPassword.Text
                );
            }
            else
            {
                MessageBox.Show("Please select a valid user to update.");
            }
        }

        private void btnDeleteUser_Click(object sender, EventArgs e)
        {
            RemoveUserAndUnassignSkills(txtName.Text);
            LoadUsers();
            LoadSkills();
            LoadUserSkills();
        }

        private void UpdateUser(int userId, string name, string email, string password)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Update query for the user
                    string query = @"
                UPDATE Users 
                SET Name = @Name, Email = @Email, Password = @password 
                WHERE UserID = @UserID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Name", name);
                        command.Parameters.AddWithValue("@Email", email);
                        command.Parameters.AddWithValue("@password", password);
                        command.Parameters.AddWithValue("@UserID", userId);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("User updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadUserSkills(); // Reload the user list after updating
                        }
                        else
                        {
                            MessageBox.Show("Failed to update user. Please check the inputs.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }



        private void AddSkillAndAssignToDepartment(string skillName)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();


                    MessageBox.Show($"Skill name is {skillName}");

                    // Begin a transaction to ensure data integrity
                    SqlTransaction transaction = connection.BeginTransaction();

                    try
                    {
                        // Step 1: Add the new skill to the Skills table
                        string addSkillQuery = "INSERT INTO Skills (SkillName, DepartmentID) OUTPUT INSERTED.SkillID VALUES (@SkillName, @DepartmentID)";
                        SqlCommand addSkillCommand = new SqlCommand(addSkillQuery, connection, transaction);
                        addSkillCommand.Parameters.AddWithValue("@SkillName", skillName);
                        addSkillCommand.Parameters.AddWithValue("@DepartmentID", managerDepartmentId);

                        int skillId = (int)addSkillCommand.ExecuteScalar();

                        // Step 2: Check if there are employees in the department
                        string getEmployeesQuery = "SELECT UserID FROM Users WHERE DepartmentID = @DepartmentID AND Role = 'Employee'";
                        SqlCommand getEmployeesCommand = new SqlCommand(getEmployeesQuery, connection, transaction);
                        getEmployeesCommand.Parameters.AddWithValue("@DepartmentID", managerDepartmentId);

                        List<int> employeeIds = new List<int>();
                        using (SqlDataReader reader = getEmployeesCommand.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                employeeIds.Add(reader.GetInt32(0));
                            }
                        }

                        // Step 3: If employees exist, assign the skill to them
                        if (employeeIds.Count > 0)
                        {
                            string assignSkillQuery = @"
                        INSERT INTO UserSkills (UserID, SkillID, ProficiencyLevel)
                        VALUES (@UserID, @SkillID, @Proficiency)";

                            foreach (int employeeId in employeeIds)
                            {
                                SqlCommand assignSkillCommand = new SqlCommand(assignSkillQuery, connection, transaction);
                                assignSkillCommand.Parameters.AddWithValue("@UserID", employeeId);
                                assignSkillCommand.Parameters.AddWithValue("@SkillID", skillId);
                                assignSkillCommand.Parameters.AddWithValue("@Proficiency", "Beginner");
                                assignSkillCommand.ExecuteNonQuery();
                            }

                            MessageBox.Show("Skill added and assigned to all employees in the department successfully.",
                                            "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("No employees found in this department. Skill added to the department only.",
                                            "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                        // Commit the transaction
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        // Rollback transaction in case of an error
                        transaction.Rollback();
                        MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void DeleteSkillAndUnassignFromDepartment(string skillName)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    SqlTransaction transaction = connection.BeginTransaction();

                    try
                    {
                        // Step 1: Retrieve the SkillID by SkillName
                        string getSkillIdQuery = "SELECT SkillID FROM Skills WHERE SkillName = @SkillName";
                        SqlCommand getSkillIdCommand = new SqlCommand(getSkillIdQuery, connection, transaction);
                        getSkillIdCommand.Parameters.AddWithValue("@SkillName", skillName);

                        object skillIdObj = getSkillIdCommand.ExecuteScalar();
                        if (skillIdObj == null)
                        {
                            MessageBox.Show("Skill not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        int skillId = (int)skillIdObj;

                        // Step 2: Check if the skill is assigned to any users
                        string checkUserSkillsQuery = "SELECT COUNT(*) FROM UserSkills WHERE SkillID = @SkillID";
                        SqlCommand checkUserSkillsCommand = new SqlCommand(checkUserSkillsQuery, connection, transaction);
                        checkUserSkillsCommand.Parameters.AddWithValue("@SkillID", skillId);

                        int assignedUsersCount = (int)checkUserSkillsCommand.ExecuteScalar();

                        if (assignedUsersCount == 0)
                        {
                            // The skill is not assigned to any user
                            MessageBox.Show("No employees are assigned this skill. It will be removed from the system.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Step 3: Delete the skill from the Skills table
                            string deleteSkillQuery = "DELETE FROM Skills WHERE SkillID = @SkillID";
                            SqlCommand deleteSkillCommand = new SqlCommand(deleteSkillQuery, connection, transaction);
                            deleteSkillCommand.Parameters.AddWithValue("@SkillID", skillId);
                            deleteSkillCommand.ExecuteNonQuery();
                        }
                        else
                        {
                            // The skill is assigned to users; delete UserSkills and then the skill
                            string deleteUserSkillsQuery = "DELETE FROM UserSkills WHERE SkillID = @SkillID";
                            SqlCommand deleteUserSkillsCommand = new SqlCommand(deleteUserSkillsQuery, connection, transaction);
                            deleteUserSkillsCommand.Parameters.AddWithValue("@SkillID", skillId);
                            deleteUserSkillsCommand.ExecuteNonQuery();

                            string deleteSkillQuery = "DELETE FROM Skills WHERE SkillID = @SkillID";
                            SqlCommand deleteSkillCommand = new SqlCommand(deleteSkillQuery, connection, transaction);
                            deleteSkillCommand.Parameters.AddWithValue("@SkillID", skillId);
                            deleteSkillCommand.ExecuteNonQuery();

                            MessageBox.Show("Skill deleted and unassigned from all employees successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                        // Commit the transaction
                        transaction.Commit();

                        // Remove the skill from the combobox
                        RemoveSkillFromComboBox(skillName);
                    }
                    catch (Exception ex)
                    {
                        // Rollback transaction in case of an error
                        transaction.Rollback();
                        MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void RemoveSkillFromComboBox(string skillName)
        {

            var itemsToRemove = cmbAssignSkill.Items.Cast<object>()
                                    .Where(item => item.ToString().Equals(skillName, StringComparison.OrdinalIgnoreCase))
                                    .ToList();

            foreach (var item in itemsToRemove)
            {
                cmbAssignSkill.Items.Remove(item);
            }
        }


        private void AddUserAndAssignSkills(string userName, string UserName, string password)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();


                    SqlTransaction transaction = connection.BeginTransaction();

                    try
                    {

                        string addUserQuery = @"
                    INSERT INTO Users (Name, Email,Password, Role, DepartmentID) 
                    OUTPUT INSERTED.UserID 
                    VALUES (@Name, @Email,@Password, 'Employee', @DepartmentID)";
                        SqlCommand addUserCommand = new SqlCommand(addUserQuery, connection, transaction);
                        addUserCommand.Parameters.AddWithValue("@Name", userName);
                        addUserCommand.Parameters.AddWithValue("@Email", UserName);
                        addUserCommand.Parameters.AddWithValue("@Password", password);
                        addUserCommand.Parameters.AddWithValue("@DepartmentID", managerDepartmentId);

                        int userId = (int)addUserCommand.ExecuteScalar();

                        // Step 2: Retrieve all skills associated with the user's department
                        string getSkillsQuery = "SELECT SkillID FROM Skills WHERE DepartmentID = @DepartmentID";
                        SqlCommand getSkillsCommand = new SqlCommand(getSkillsQuery, connection, transaction);
                        getSkillsCommand.Parameters.AddWithValue("@DepartmentID", managerDepartmentId);

                        List<int> skillIds = new List<int>();
                        using (SqlDataReader reader = getSkillsCommand.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                skillIds.Add(reader.GetInt32(0));
                            }
                        }

                        // Step 3: Assign each skill to the new user with proficiency "Beginner"
                        string assignSkillQuery = @"
                    INSERT INTO UserSkills (UserID, SkillID, ProficiencyLevel) 
                    VALUES (@UserID, @SkillID, @Proficiency)";
                        foreach (int skillId in skillIds)
                        {
                            SqlCommand assignSkillCommand = new SqlCommand(assignSkillQuery, connection, transaction);
                            assignSkillCommand.Parameters.AddWithValue("@UserID", userId);
                            assignSkillCommand.Parameters.AddWithValue("@SkillID", skillId);
                            assignSkillCommand.Parameters.AddWithValue("@Proficiency", "Beginner");
                            assignSkillCommand.ExecuteNonQuery();
                        }

                        // Commit the transaction
                        transaction.Commit();

                        MessageBox.Show("User added and assigned all department skills successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        // Rollback transaction in case of an error
                        transaction.Rollback();
                        MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void RemoveUserAndUnassignSkills(string UserName)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Begin a transaction to ensure data integrity
                    SqlTransaction transaction = connection.BeginTransaction();

                    try
                    {
                        // Step 1: Retrieve the UserID of the user to be deleted
                        string getUserIdQuery = "SELECT UserID FROM Users WHERE Name = @Name";
                        SqlCommand getUserIdCommand = new SqlCommand(getUserIdQuery, connection, transaction);
                        getUserIdCommand.Parameters.AddWithValue("@Name", UserName);

                        object userIdObj = getUserIdCommand.ExecuteScalar();
                        if (userIdObj == null)
                        {
                            MessageBox.Show("User not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        int userId = (int)userIdObj;

                        // Step 2: Remove all skills assigned to the user from the UserSkills table
                        string removeSkillsQuery = "DELETE FROM UserSkills WHERE UserID = @UserID";
                        SqlCommand removeSkillsCommand = new SqlCommand(removeSkillsQuery, connection, transaction);
                        removeSkillsCommand.Parameters.AddWithValue("@UserID", userId);
                        removeSkillsCommand.ExecuteNonQuery();

                        // Step 3: Delete the user from the Users table
                        string deleteUserQuery = "DELETE FROM Users WHERE UserID = @UserID";
                        SqlCommand deleteUserCommand = new SqlCommand(deleteUserQuery, connection, transaction);
                        deleteUserCommand.Parameters.AddWithValue("@UserID", userId);
                        deleteUserCommand.ExecuteNonQuery();

                        // Commit the transaction
                        transaction.Commit();

                        MessageBox.Show("User and their assigned skills removed successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        // Rollback transaction in case of an error
                        transaction.Rollback();
                        MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnDeleteSkill_Click(object sender, EventArgs e)
        {
            if (dataGridUserSkills.SelectedRows.Count > 0)
            {
                // Get the selected row
                DataGridViewRow selectedRow = dataGridUserSkills.SelectedRows[0];
                int userSkillId = Convert.ToInt32(selectedRow.Cells["UserSkillID"].Value);

                // Confirm deletion
                DialogResult result = MessageBox.Show(
                    "Are you sure you want to delete this skill assignment?",
                    "Confirm Delete",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (result == DialogResult.Yes)
                {
                    // Delete from database
                    DeleteUserSkill(userSkillId);

                    // Refresh the data grid
                    LoadUserSkills();
                }
            }
            else
            {
                MessageBox.Show("Please select a row to delete.");
            }
        }

        private void DeleteUserSkill(int userSkillId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "DELETE FROM UserSkills WHERE UserSkillID = @UserSkillID";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@UserSkillID", userSkillId);
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Skill assignment deleted successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting skill assignment: {ex.Message}");
            }
        }

    }
}
