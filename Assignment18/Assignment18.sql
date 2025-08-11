-- Drop tables if they already exist (optional, for reruns)
DROP TABLE IF EXISTS Fees;
DROP TABLE IF EXISTS Student;
DROP TABLE IF EXISTS Batch;
DROP TABLE IF EXISTS Trainer;

-- Create Trainer Table
CREATE TABLE Trainer (
    Trainer_ID INT PRIMARY KEY,
    Trainer_Name VARCHAR(50),
    Address VARCHAR(100),
    Qualification VARCHAR(50),
    Experience INT,
    Domain VARCHAR(50)
);

-- Create Batch Table
CREATE TABLE Batch (
    Batch_Code VARCHAR(10) PRIMARY KEY,
    Name VARCHAR(50),
    Duration VARCHAR(30),
    Description TEXT,
    Trainer_ID INT,
    FOREIGN KEY (Trainer_ID) REFERENCES Trainer(Trainer_ID)
);

-- Create Student Table
CREATE TABLE Student (
    Rn INT PRIMARY KEY,
    Name VARCHAR(50),
    Address VARCHAR(100),
    Marks INT,
    DOB DATE,
    Batch_Code VARCHAR(10),
    FOREIGN KEY (Batch_Code) REFERENCES Batch(Batch_Code)
);

-- Create Fees Table
CREATE TABLE Fees (
    Rn INT,
    Fees_Paid DECIMAL(10,2),
    Date_Paid DATE,
    FOREIGN KEY (Rn) REFERENCES Student(Rn)
);

-- Insert into Trainer
INSERT INTO Trainer VALUES (101, 'Mr. Ravi Kumar', 'Chennai', 'M.Tech', 10, 'Data Science');
INSERT INTO Trainer VALUES (102, 'Ms. Anjali Mehta', 'Bangalore', 'MCA', 8, 'Web Development');

-- Insert into Batch
INSERT INTO Batch VALUES ('B101', 'AI Batch', '3 Months', 'Advanced AI concepts', 101);
INSERT INTO Batch VALUES ('B102', 'Full Stack', '4 Months', 'Web development course', 102);

-- Insert into Student
INSERT INTO Student VALUES (1, 'Arjun', 'Chennai', 85, '2002-05-10', 'B101');
INSERT INTO Student VALUES (2, 'Priya', 'Coimbatore', 90, '2001-12-15', 'B102');
INSERT INTO Student VALUES (3, 'Rahul', 'Madurai', 78, '2002-08-01', 'B101');

-- Insert into Fees
INSERT INTO Fees VALUES (1, 15000.00, '2025-08-01');
INSERT INTO Fees VALUES (2, 18000.00, '2025-08-03');
INSERT INTO Fees VALUES (3, 15000.00, '2025-08-02');

-- Query 1: Student name, address, batch code, batch name, faculty name, duration
SELECT 
    S.Name AS Student_Name,
    S.Address AS Student_Address,
    B.Batch_Code,
    B.Name AS Batch_Name,
    T.Trainer_Name AS Faculty_Name,
    B.Duration
FROM 
    Student S
JOIN 
    Batch B ON S.Batch_Code = B.Batch_Code
JOIN 
    Trainer T ON B.Trainer_ID = T.Trainer_ID;

-- Query 2: Student name, fees paid, and date paid
SELECT 
    S.Name AS Student_Name,
    F.Fees_Paid,
    F.Date_Paid
FROM 
    Student S
JOIN 
    Fees F ON S.Rn = F.Rn;

-- Query 3: Batch code, batch name, and trainer details
SELECT 
    B.Batch_Code,
    B.Name AS Batch_Name,
    T.Trainer_ID,
    T.Trainer_Name,
    T.Address,
    T.Qualification,
    T.Experience,
    T.Domain
FROM 
    Batch B
JOIN 
    Trainer T ON B.Trainer_ID = T.Trainer_ID;
