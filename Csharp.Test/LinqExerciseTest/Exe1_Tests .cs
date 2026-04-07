using LINQ.Exercises;
using LINQ.MockData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_Exercises.Test.Exercises
{
    public class Ex1_Tests
    {
        [Fact]
        public void Emp_Salary_Filtering_ShouldReturnCorrectEmployees()
        {
            // Arrange
            var exe = new Exe_1();
            exe.Emp = new List<Employee>
            {
                new Employee { Name = "John", Department = "Engineering", Salary = 60000 },
                new Employee { Name = "Jane", Department = "HR", Salary = 40000 },
                new Employee { Name = "Doe", Department = "Engineering", Salary = 50000 }
            };

            // Act
            var result=  exe.Emp_Salary_Filtering();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(1, result.Count); // Only 2 employees meet the criteria
            Assert.Contains(result, e => e.Name == "John");
            Assert.Contains(result, e => e.Name != "Smith");

        }
    }
}
