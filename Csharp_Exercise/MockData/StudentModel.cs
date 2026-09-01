using Csharp.Exercise.MockData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp_Exercise
{
    public class StudentModel
    {
        public readonly List<Student> student;
        public  readonly List<Teacher> teacher;
        public  readonly List<Department> department;
        public  readonly List<Address> address;
        public StudentModel()
        {
            student = new List<Student>
            {
                new Student{ FirstName = "Bill",
                    LastName = "Smith",
                    TeacherID = 1,
                    Year = GradeLevel.FirstYear,
                    Scores = new List<int> { 90, 80, 70, 60 },
                    DepartmentID = 1,
                    AddressId =1
                },
                new Student{ FirstName = "anbu",
                    LastName = "vel",
                    TeacherID = 2,
                    Year = GradeLevel.SecondYear,
                    Scores = new List<int> { 90, 80, 70, 70 },
                    DepartmentID =0 ,
                     AddressId =0
                },
                new Student{ FirstName = "siva",
                    LastName = "sakthi",
                    TeacherID = 3,
                    Year = GradeLevel.ThirdYear,
                    Scores = new List<int> { 90, 80, 70, 100 },
                    DepartmentID = 0,
                     AddressId =0
                },
                 new Student{ FirstName = "valli",
                    LastName = "deivanai",
                    Year = GradeLevel.ThirdYear,
                    Scores = new List<int> { 90, 80, 70, 100 },
                     AddressId =0
                    }
            };
            teacher = new List<Teacher>
            {
                new Teacher{ First = "Sue",
                    Last = "Jones",
                    ID = 1,
                    City = "Seattle" },
                new Teacher{ First = "Bob",
                    Last = "Smith",
                    ID = 2,
                    City = "Tacoma" },
                new Teacher{ First = "Alice",
                    Last = "Johnson",
                    ID = 3,
                    City = "Kirkland" },
            };
            department = new List<Department>
            {
                new Department{ Name = "Computer Science",
                    ID = 1,
                    TeacherID = 1 },
                new Department{ Name = "Accounting",
                    ID = 2,
                    TeacherID = 2 },
                new Department{ Name = "Physics",
                    ID = 3,
                    TeacherID = 3 },
            };

            address = new List<Address>
            {
                new Address{ AddressId = 1,
                    City = "New York",
                    State = "NY" },
                new Address{ AddressId = 2,
                    City = "Los Angeles",
                    State = "CA" },
                new Address{ AddressId = 3,
                    City = "Chicago",
                    State = "IL" },
            };
        }
    }
}
