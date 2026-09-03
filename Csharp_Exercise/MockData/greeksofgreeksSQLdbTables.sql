-- =========================
-- 1. STUDENT TABLE
-- =========================

CREATE TABLE Students
(
    StudentId INT PRIMARY KEY,
    FirstName VARCHAR(50) NOT NULL,
    LastName VARCHAR(50) NOT NULL,
    GPA DECIMAL(4,2),
    EnrollmentDate DATETIME NOT NULL,
    Major VARCHAR(100)
);


INSERT INTO Students
(
    StudentId,
    FirstName,
    LastName,
    GPA,
    EnrollmentDate,
    Major
)
VALUES
(201, 'Jack',  'Smith',  8.79, '2021-09-10 09:30:00', 'Computer Science'),
(202, 'Ryan',  'Brown',  8.44, '2021-09-10 08:30:00', 'Mathematics'),
(203, 'Ethan', 'Davis',  5.60, '2021-09-10 10:00:00', 'Biology'),
(204, 'Emma',  'Wilson', 9.20, '2021-09-12 12:45:00', 'Chemistry'),
(205, 'Noah',  'Miller', 7.85, '2021-09-10 08:30:00', 'Physics'),
(206, 'Liam',  'Taylor', 9.56, '2021-09-10 09:24:00', 'History'),
(207, 'Ava',   'Moore',  9.78, '2021-09-01 02:30:00', 'English'),
(208, 'Grace', 'Clark',  7.00, '2021-09-10 06:30:00', 'Mathematics');


-- =========================
-- 2. STUDENT PROGRAM TABLE
-- =========================

CREATE TABLE StudentPrograms
(
    StudentRefId INT PRIMARY KEY,
    ProgramName VARCHAR(100) NOT NULL,
    ProgramStartDate DATETIME NOT NULL,

    CONSTRAINT FK_StudentPrograms_Students FOREIGN KEY (StudentRefId)
        REFERENCES Students(StudentId)
);


INSERT INTO StudentPrograms
(
    StudentRefId,
    ProgramName,
    ProgramStartDate
)
VALUES
(201, 'Computer Science', '2021-09-01 00:00:00'),
(202, 'Mathematics',      '2021-09-01 00:00:00'),
(208, 'Mathematics',      '2021-09-01 00:00:00'),
(205, 'Physics',          '2021-09-01 00:00:00'),
(204, 'Chemistry',        '2021-09-01 00:00:00'),
(207, 'Psychology',       '2021-09-01 00:00:00'),
(206, 'History',          '2021-09-01 00:00:00'),
(203, 'Biology',          '2021-09-01 00:00:00');


-- =========================
-- 3. SCHOLARSHIP TABLE
-- =========================

CREATE TABLE Scholarships
(
    StudentRefId INT PRIMARY KEY,
    ScholarshipAmount DECIMAL(10,2) NOT NULL,
    ScholarshipDate DATETIME NOT NULL,

    CONSTRAINT FK_Scholarships_Students
        FOREIGN KEY (StudentRefId)
        REFERENCES Students(StudentId)
);


INSERT INTO Scholarships
(
    StudentRefId,
    ScholarshipAmount,
    ScholarshipDate
)
VALUES
(201, 5000, '2021-10-15 00:00:00'),
(202, 4500, '2022-08-18 00:00:00'),
(203, 3000, '2022-01-25 00:00:00'),
(204, 4000, '2021-10-15 00:00:00');

SELECT *
FROM Students;

SELECT *
FROM StudentPrograms;

SELECT *
FROM Scholarships;