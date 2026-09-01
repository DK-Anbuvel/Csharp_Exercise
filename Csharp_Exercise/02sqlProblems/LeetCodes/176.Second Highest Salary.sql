/*
Table: Employee

+-------------+------+
| Column Name | Type |
+-------------+------+
| id          | int  |
| salary      | int  |
+-------------+------+
id is the primary key (column with unique values) for this table.
Each row of this table contains information about the salary of an employee.
 

Write a solution to find the second highest distinct salary from the Employee table. 
If there is no second highest salary, return null (return None in Pandas).
*/


/* 1. Traditional subquery method,
        make condition less then max() value, it automattically return secound value
        and if second max value not exit, it will return NULL.
*/
select Max(salary) as SecondHighestSalary from Employee
where salary < (select Max(salary) from Employee);


/* 2. Using Window function DENSE_RANK()

*/

select (
select distinct salary from (
 select 
   salary, Dense_Rank() over(order by salary desc) as ork
   from Employee
   ) as secoundRank
   where ork = 2
) as SecondHighestSalary

/* 3.
*/

 with cte as(
select
DENSE_RANK() over (order by Salary desc) as "r",
salary
from employee)

select
max(case when r=2 then Salary else null end) as "SecondHighestSalary"
from cte


select
max(Salary) as "SecondHighestSalary"
from cte where r=2


/* 4. Second, Third value print 
*/
select name, ranks from (
 select name, Dense_Rank() over (order by name) as ranks from EMPLOYEE
) as RankEmp  where ranks=3; 

with cts as (
select name,Dense_Rank() over (order by name) as ranks from EMPLOYEE
)

select name, ranks from cts where ranks =4;