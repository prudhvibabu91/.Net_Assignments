-- Drop if exists
IF OBJECT_ID('dbo.Employee', 'U') IS NOT NULL
    DROP TABLE dbo.Employee;
GO

-- Create table
CREATE TABLE dbo.Employee (
    EmpID INT PRIMARY KEY IDENTITY(101,1),
    Name VARCHAR(50) NOT NULL,
    Exp INT CHECK (Exp >= 2),
    Salary INT CHECK (Salary BETWEEN 12000 AND 30000),
    Department VARCHAR(20) CHECK (Department IN ('HR', 'Sales', 'Accts', 'IT')),
    ManagerName VARCHAR(50),
    Age INT DEFAULT 26 CHECK (Age BETWEEN 26 AND 60)
);
GO

-- Insert data
INSERT INTO dbo.Employee (Name, Exp, Salary, Department, ManagerName)
VALUES 
('Aman', 3, 15000, 'HR', 'Suresh'),
('Bala', 4, 18000, 'Sales', 'Raj'),
('Cathy', 2, 22000, 'Accts', 'Rita'),
('David', 5, 25000, 'IT', 'John'),
('Elan', 6, 16000, 'HR', 'Suresh'),
('Fiza', 3, 28000, 'Sales', 'Raj'),
('Gowri', 7, 30000, 'Accts', 'Rita');
GO

-- Ensure all Age values are set to default
UPDATE dbo.Employee SET Age = 26 WHERE Age IS NULL;
GO

-- Performing required operations:
SELECT EmpID, Name, Salary FROM dbo.Employee;
SELECT EmpID AS [Employee ID], Name AS [Name of Employee], Salary AS [Salary of Employee] FROM dbo.Employee;
SELECT Name, Salary, Salary * 1.10 AS [Incremented Salary] FROM dbo.Employee;
SELECT Department, SUM(Salary) AS [Total Salary] FROM dbo.Employee GROUP BY Department;
SELECT Department, SUM(Salary) AS [Total], MAX(Salary) AS [Max], AVG(Salary) AS [Average] FROM dbo.Employee GROUP BY Department;
SELECT * FROM dbo.Employee ORDER BY Salary;
SELECT ROW_NUMBER() OVER (ORDER BY EmpID) AS [Seq], * FROM dbo.Employee;
SELECT RANK() OVER (ORDER BY Salary DESC) AS [Rank], * FROM dbo.Employee;
SELECT COUNT(DISTINCT Department) AS [Department Count] FROM dbo.Employee;
SELECT UPPER(Name) AS [Upper Name] FROM dbo.Employee;
SELECT LEFT(Name, 4) AS [First 4 Letters] FROM dbo.Employee;
SELECT Name, CHARINDEX('a', Name) AS [Position of a] FROM dbo.Employee;
SELECT Department, COUNT(*) AS [Emp Count] FROM dbo.Employee GROUP BY Department;
SELECT ManagerName, COUNT(*) AS [Emp Count] FROM dbo.Employee GROUP BY ManagerName;
SELECT * FROM dbo.Employee WHERE EmpID IN (101, 102, 110);
SELECT * FROM dbo.Employee WHERE EmpID BETWEEN 100 AND 110;
SELECT * FROM dbo.Employee WHERE Department = 'HR';
SELECT * FROM dbo.Employee WHERE Department IN ('HR', 'Accts');
SELECT * FROM dbo.Employee WHERE Name LIKE 'A%';
SELECT * FROM dbo.Employee WHERE Name LIKE '%a%';
SELECT Department, AVG(Salary) AS [Avg Salary] FROM dbo.Employee GROUP BY Department HAVING AVG(Salary) < 12000;
SELECT * FROM dbo.Employee WHERE Department != 'Accts' AND Salary NOT BETWEEN 10000 AND 20000;
