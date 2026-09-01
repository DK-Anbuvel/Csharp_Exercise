
/* https://www.geeksforgeeks.org/sql/sql-query-interview-questions/ */


create table Student (
 STUDENT_ID INT primary key,
 FIRST_NAME VARCHAR(30),
 LAST_NAME VARCHAR(30),
 GPA INT,
 ENROLLMENT_DATE DATETIME,
 MAJOR VARCHAR(30)
)

CREATE table Program(
STUDENT_REF_ID INT ,
 PROGRAM_NAMES VARCHAR(30),
 PROGRAM_START_DATE DATETIME,
)

CREATE table Scholarship(
STUDENT_REF_ID INT ,
 SCHOLARSHIP_AMOUNT VARCHAR(30),
 SCHOLARSHIP_DATE DATETIME,
)


/* 1. Write a SQL query to fetch "FIRST_NAME" from the Student table in upper case and use ALIAS name as STUDENT_NAME. */

select upper(FIRST_NAME) as STUDENT_NAME from Student


/* 2. Write a SQL query to fetch unique values of MAJOR Subjects from Student table. */

select distinct MAJOR from Student
select MAJOR from Student group by MAJOR

