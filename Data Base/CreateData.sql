
CREATE DATABASE SkillTrackerDB;
GO
USE SkillTrackerDB;
GO

-- Departments Table
CREATE TABLE Departments (
    DepartmentID INT IDENTITY(1,1) PRIMARY KEY,
    DepartmentName NVARCHAR(255) NOT NULL
);
GO

-- Users Table
CREATE TABLE Users (
    UserID INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(255) NOT NULL,
    Email NVARCHAR(255) UNIQUE NOT NULL,
    Password NVARCHAR(255) NOT NULL,
    Role NVARCHAR(50) CHECK (Role IN ('General Manager', 'Department Manager', 'Employee')) NOT NULL,
    DepartmentID INT NULL,
    FOREIGN KEY (DepartmentID) REFERENCES Departments(DepartmentID) ON DELETE SET NULL
);
GO

-- Skills Table
CREATE TABLE Skills (
    SkillID INT IDENTITY(1,1) PRIMARY KEY,
    SkillName NVARCHAR(255) NOT NULL,
    DepartmentID INT NOT NULL,
    FOREIGN KEY (DepartmentID) REFERENCES Departments(DepartmentID) ON DELETE CASCADE
);
GO

-- UserSkills Table
CREATE TABLE UserSkills (
    UserSkillID INT IDENTITY(1,1) PRIMARY KEY,
    UserID INT NOT NULL,
    SkillID INT NOT NULL,
    ProficiencyLevel NVARCHAR(50) CHECK (ProficiencyLevel IN ('Beginner', 'Intermediate', 'Advanced')) NOT NULL,
    FOREIGN KEY (UserID) REFERENCES Users(UserID) ON DELETE CASCADE,
    FOREIGN KEY (SkillID) REFERENCES Skills(SkillID) ON DELETE CASCADE
);
GO

-- SkillAdvice Table
CREATE TABLE SkillAdvice (
    AdviceID INT IDENTITY(1,1) PRIMARY KEY,
    SkillID INT NOT NULL,
    ProficiencyLevel NVARCHAR(50) CHECK (ProficiencyLevel IN ('Beginner', 'Intermediate', 'Advanced')) NOT NULL,
    Advice NVARCHAR(MAX) NOT NULL,
    FOREIGN KEY (SkillID) REFERENCES Skills(SkillID) ON DELETE CASCADE
);
GO

-- PerformanceTable
CREATE TABLE PerformanceTable (
    PerformanceID INT IDENTITY(1,1) PRIMARY KEY,
    UserID INT NOT NULL,
    DepartmentID INT NOT NULL,
    Score DECIMAL(10, 2) NOT NULL,
    FOREIGN KEY (UserID) REFERENCES Users(UserID) ON DELETE CASCADE,
    FOREIGN KEY (DepartmentID) REFERENCES Departments(DepartmentID) ON DELETE CASCADE
);
GO
