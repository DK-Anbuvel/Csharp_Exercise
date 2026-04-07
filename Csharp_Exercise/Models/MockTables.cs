using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ.MockData
{
    public enum GradeLevel
    {
        FirstYear = 1,
        SecondYear,
        ThirdYear,
        FourthYear
    };

    public class Student
    {
        public required string FirstName { get; set; }
        public required string LastName { get; init; }
        public  int TeacherID { get; init; }

        public required GradeLevel Year { get; init; }
        public required List<int> Scores { get; init; }
        public  int DepartmentID { get; init; }
        public int AddressId  { get; set; }
        public int Score { get; set; }

} 

        public class Teacher
        {
            public required string First { get; init; }
            public required string Last { get; init; }
            public required int ID { get; init; }
            public required string City { get; init; }
        }

        public class Department
        {
            public required string Name { get; init; }
            public int ID { get; init; }

            public required int TeacherID { get; init; }
        }

       public class Address
       {
        public required int AddressId { get; init; }
        public required string City { get; init; }
        public required string State { get; init; }

      }

    public class Employee
    {
        public string Name { get; set; }
        public string Department { get; set; }
        public long Salary { get; set; }
    }

    public class Sale
    {
        public string ProductName { get; set; }
        public int SaleQuantity { get; set; }
        public int SaleAmount { get; set; }
    }
  }

