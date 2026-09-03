
/* https://www.geeksforgeeks.org/sql/sql-query-interview-questions/ */


/* 1. Write a SQL query to fetch "FIRST_NAME" from the Student table in upper case and use ALIAS name as STUDENT_NAME. */

select upper(FIRSTNAME) as STUDENT_NAME from Students


/* 2. Write a SQL query to fetch unique values of MAJOR Subjects from Student table. */

select distinct MAJOR from Students
select MAJOR from Students group by MAJOR

/* 3. Write a SQL query to print the first 3 characters of FIRST_NAME from Student table. */

/* extracting the first 3 character from firstname used by SUBSTRING() function */
select	SUBSTRING(Firstname,1,3),FirstName from students

/*4. Write a SQL query to find the position of alphabet ('a') int the first name column 'Grace' from Student table. */

select charIndex('a',lower(firstName)),FirstName from Students where FirstName = 'Grace';

/* 5. Write a SQL query that fetches the unique values of MAJOR Subjects from Student table and print its length.*/

select distinct MAJOR, LEN(Major) from Students
select MAJOR ,  LEN(Major)from Students group by MAJOR

/* 6. Write a SQL query to print FIRST_NAME from the Student table after replacing 'a' with 'A'.*/

  /*STUFF() function is used to delete a sepecific lenght of characters from string
   and insert a new substring at that exact position
   STUFF(original_string, start_position, length_to_delete, replacement_string)

   REPLACE() function is used to replace an instance of a character anywhere it appears in a string,

*/
select Stuff(firstname,charIndex('a',firstName),1,'A'),FirstName from students
select REPLACE(firstname,'a','A'),firstname from students 

/*7. Write a SQL query to print the FIRST_NAME and LAST_NAME from Student table into single column COMPLETE_NAME. */

select FirstName+' '+LastName as COMPLETE_NAME,firstname,LastName from Students
select CONCAT(FirstName,' ',lastName) as COMPLETE_NAME,firstname,LastName from Students

/*8. Write a SQL query to print all Student details from Student table order by FIRST_NAME Ascending and MAJOR Subject descending . */

select * from Students order by FirstName, major desc

/*9. Write a SQL query to print details of the Students with the FIRST_NAME as 'Noah' and 'Ava' from Student table */

select * from Students where FirstName in ('Noah','Ava')

/*10. Write a SQL query to print details of the Students excluding FIRST_NAME as 'Jack' and 'Liam' from Student table */

select * from Students where FirstName not in ('Jack','Liam')

