using LINQ.MockData;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace LINQ.Exercises
{
    public class Exe_1
    {
        /* 
        1.  Employee Salary Filtering

          You have a list of employees, each with a Name, Department, and Salary. Write a LINQ query to 
         find the employees in the "Engineering" department who have a salary greater than ₹50,000.
         */
        public List<Employee> Emp = new List<Employee>();
        public  ArrayData obj = new ArrayData();
         
        public List<Employee> Emp_Salary_Filtering()
        {
            var res = Emp.Where(s => s.Department == "Engineering" && s.Salary > 50000).ToList();

            var res1 = from emp in Emp
                      where emp.Department == "Engineering" && emp.Salary > 50000
                      select emp;

            return res;
        }

        /* 2. Sales Report Aggregation

          You are building a system that tracks sales. Each sale contains ProductName, QuantitySold, and 
        SaleAmount. Write a LINQ query to group the sales by ProductName and calculate the total SaleAmount 
        for each product.
        */
        List<Sale> sale = new List<Sale>();
        public void Sales_Report_Aggregation()
        {
            var res = sale.GroupBy(x => x.ProductName)
                          .Select(x => new
                          {
                              product = x.Key,
                              TotalAmount = x.Sum(g => g.SaleAmount),
                          }).ToList();


            var res1 = from s in sale
                       group s by s.ProductName into g
                       select new
                       {
                           Product = g.Key,
                           TotalAmount = g.Sum(g => g.SaleAmount)
                       };

                     
        }
        /* 3. Top 3 Students by Score

         You are creating a student grading system. Each student has a Name, Score, and ClassName. 
        Write a LINQ query to find the top 3 students with the highest Score, ordered by their score in
        descending order.
         */
        List<Student> student = new List<Student>();

        public void Top_3_StudentsByScore()
        {
            var res = student.OrderByDescending(x => x.Score).Take(3).ToList();

            var res1 = (from s in student
                       orderby s.Score descending
                        select s).Take(3);
                       
        }

        /*
         4. Write a program in C# Sharp to show how the three parts of a query operation execute.
           Expected Output:
           The numbers which produce the remainder 0 after divided by 2 are :
           0 2 4 6 8
         */

        public void IsReturnZero()
        {
            var result = from s in obj.inputX
                         where s % 2 == 0
                         select s;
            var result1 = obj.inputX.Where(x => x % 2 == 0).ToList();
        }
        /*
         5. Write a program in C# Sharp to find the +ve numbers from a list of 
          numbers using two where conditions in LINQ Query.
         */

        public void IsPossiveNuber()
        {

            var result = from s in obj.inputX
                         where s > 0 && 0 < s
                         select s;
            var result1 = obj.inputX.Where(s => s > 0 && 0 < s).ToList();

        }
        /*
         6. Write a program in C# Sharp to find the number of an array and the square of each number.
         */

        public void ReturnSquareNum()
        {

            var result = from s in obj.inputX
                         select new { Number= s, SqrNo =  s * s };

            var result2 = from s in obj.inputX
                          let SqrNo = s * s
                          where SqrNo > 20
                          select new { s, SqrNo };

            var result1 = obj.inputX.Select(e => new { Number = e, SqrNo = e * e });
        }
        /*
        7. Write a program in C# Sharp to display the number and frequency of a given number from an array.
        */
        public dynamic disPlayNumberFrequency()
        {
            var result = from s in obj.inputX
                         group s by s into groupedNumber
                         select new
                         {
                             Number = groupedNumber,
                             Apperance = groupedNumber.Count()
                         };
            var result1 = obj.inputX.GroupBy(s => s)
                           .Select(e => new
                           {
                               Number = e.Key,
                               Apperance =e.Count()
                           });
            return result;
        }
        /*
         8. Write a program in C# Sharp to display the characters and frequency of each character in a given
         */

        public dynamic disPlayCharacterFrequency(string inString)
        {
             char[] obj = inString.ToCharArray();
            var result = from s in obj
                         group s by s into groupedCharacter
                         select new
                         {
                             Character = groupedCharacter,
                             Times = groupedCharacter.Count()
                         };
            var result1 = from s in inString
                          group s by s into groupedCharacter
                         select new
                         {
                             Character = groupedCharacter,
                             Times = groupedCharacter.Count()
                         };
            return result;
        }
    }
}
