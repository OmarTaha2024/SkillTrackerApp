Skill Tracker Application

Overview

The Skill Tracker Application is a Windows Forms-based solution designed to manage and track skills within an organization. It provides features for general managers, department managers, and employees to interact with the system, enabling efficient skill assignment, tracking, and reporting.

Features

General Manager Module

View Departments and Managers: Displays all departments and their assigned managers.

Best Employee Reporting: Identifies the top-performing employee in each department based on skill proficiency.

Department Manager Module

User and Skill Management:

View, add, update, or delete employees in their department.

Assign skills to employees.

Update or delete assigned skills.

Reporting: Displays skill proficiency levels for all employees in the department.

Employee Module

Skill Overview:

View assigned skills and proficiency levels.

Access department-specific skill data.

Technology Stack

Frontend: Windows Forms (WinForms)

Backend: Microsoft SQL Server

Programming Language: C#

Database Access: ADO.NET

Project Structure

UserSkillTrackingForm.cs: Handles functionalities for department managers, including user and skill management within a department.

GeneralManagerForm.cs: Provides tools for general managers to view department performance and employee data.

EmployeeForm.cs: Enables employees to view their skills and proficiency levels.

Setup Instructions

Prerequisites:

Install Microsoft Visual Studio (2019 or later).

Install SQL Server and set up the SkillTrackerDB database.

Database Configuration:

Ensure the SkillTrackerDB database is created with the required schema:

Tables: Users, Departments, Skills, UserSkills.

Update the connection string in the C# files to match your SQL Server instance.

Example connection string:

private readonly string connectionString = "Data Source=.\\SQLEXPRESS01;Initial Catalog=SkillTrackerDB;Integrated Security=true";

Run the Application:

Open the solution in Visual Studio.

Build and run the project.

Usage

General Manager

Launch the GeneralManagerForm.

Use the View Departments button to display all departments and their managers.

Use the View Best Employees button to identify top-performing employees.

Department Manager

Launch the UserSkillTrackingForm.

Use the provided controls to add/update/delete users and skills within the department.

Assign skills to employees and monitor their progress.

Employee

Launch the EmployeeForm.

View assigned skills and proficiency levels using the provided interface.