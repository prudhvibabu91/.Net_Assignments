-- Drop old objects if exist
IF OBJECT_ID('InsertOrUpdateEmployee', 'P') IS NOT NULL
    DROP PROCEDURE InsertOrUpdateEmployee;
GO

IF OBJECT_ID('Employee', 'U') IS NOT NULL
    DROP TABLE Employee;
GO

IF OBJECT_ID('Department', 'U') IS NOT NULL
    DROP TABLE Department;
GO

-- Create Department table
CREATE TABLE Department (
    departmentId INT PRIMARY KEY IDENTITY(1,1),
    deptName NVARCHAR(50)
);
GO

-- Create Employee table
CREATE TABLE Employee (
    employeeId INT PRIMARY KEY IDENTITY(1,1),
    name NVARCHAR(50),
    exp INT,
    salary INT,
    departmentId INT,
    managerId INT,
    age INT DEFAULT 26,
    FOREIGN KEY (departmentId) REFERENCES Department(departmentId),
    FOREIGN KEY (managerId) REFERENCES Employee(employeeId)
);
GO

-- Insert Departments
INSERT INTO Department (deptName)
VALUES ('HR'), ('Sales'), ('Accts'), ('IT');
GO

-- Create Procedure in separate batch
CREATE PROCEDURE InsertOrUpdateEmployee
    @name NVARCHAR(50),
    @exp INT,
    @salary INT,
    @departmentId INT,
    @managerId INT = NULL
AS
BEGIN
    SET NOCOUNT ON;

    IF @name IS NULL OR LTRIM(RTRIM(@name)) = ''
    BEGIN
        RAISERROR('Name is required.', 16, 1);
        RETURN;
    END

    IF NOT EXISTS (SELECT 1 FROM Employee WHERE name = @name)
    BEGIN
        INSERT INTO Employee (name, exp, salary, departmentId, managerId)
        VALUES (@name, @exp, @salary, @departmentId, @managerId);
    END
    ELSE
    BEGIN
        UPDATE Employee
        SET exp = @exp,
            salary = @salary,
            departmentId = @departmentId,
            managerId = @managerId
        WHERE name = @name;
    END
END;
GO

-- Insert Employees
EXEC InsertOrUpdateEmployee 'Alice', 6, 25000, 1, NULL;
EXEC InsertOrUpdateEmployee 'Bob', 3, 18000, 2, 1;
EXEC InsertOrUpdateEmployee 'Charlie', 7, 30000, 3, 1;
EXEC InsertOrUpdateEmployee 'David', 2, 15000, 1, 2;
EXEC InsertOrUpdateEmployee 'Eve', 6, 28000, 4, 3;
GO

-- Output Queries

-- 1. Employee with Manager and Department Name
SELECT e.employeeId, e.name, e.salary, d.deptName, m.name AS ManagerName
FROM Employee e
LEFT JOIN Department d ON e.departmentId = d.departmentId
LEFT JOIN Employee m ON e.managerId = m.employeeId;

-- 2. Employee name and experience
SELECT name, exp FROM Employee;

-- 3. Employee name and salary
SELECT name, salary FROM Employee;

-- 4. Employee name and age
SELECT name, age FROM Employee;

-- 5. Employees with their salary rank
SELECT employeeId, name, salary,
       RANK() OVER (ORDER BY salary DESC) AS SalaryRank
FROM Employee;

-- 6. Employees with sequence
SELECT employeeId, name,
       ROW_NUMBER() OVER (ORDER BY employeeId) AS Sequence
FROM Employee;

-- 7. Department-wise total salary
SELECT d.deptName, SUM(e.salary) AS TotalSalary
FROM Employee e
JOIN Department d ON e.departmentId = d.departmentId
GROUP BY d.deptName;

-- 8. Department-wise max salary
SELECT d.deptName, MAX(e.salary) AS MaxSalary
FROM Employee e
JOIN Department d ON e.departmentId = d.departmentId
GROUP BY d.deptName;

-- 9. Department-wise average salary
SELECT d.deptName, AVG(e.salary) AS AverageSalary
FROM Employee e
JOIN Department d ON e.departmentId = d.departmentId
GROUP BY d.deptName;

-- 10. Total number of departments
SELECT COUNT(*) AS [Total Departments] FROM Department;

-- 11. All employees sorted by age
SELECT employeeId, name, age FROM Employee ORDER BY age;