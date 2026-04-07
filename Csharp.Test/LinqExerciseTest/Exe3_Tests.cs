using LINQ_Exercises.Exercises;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_Exercise_Test.Test.Exercises
{
    public class Exe3_Tests
    {
        Exe_3 sut = new Exe_3();
        [Fact]
        public void DisplayGreaterThen_ReturnsNumbersGreaterThan80()
        {
            // Arrange
            
            var input = new List<int> { 50, 81, 90, 80, 100, 79 };
            var expected = new List<int> { 81, 90, 100 };
            var input2 = new List<int> { 10, 20, 80 };
            var input3 = new List<int>(); ;
            // Act
            var result = sut.DisplayGreaterThen(input);
            var result1 = sut.DisplayGreaterThen(input2);
            var result2 = sut.DisplayGreaterThen(input3);

            // Assert - preserves input order for filtered items
            Assert.Equal(expected, result);
            Assert.Empty(result1);
            Assert.Empty(result2);
        }
        [Fact]
        public void ReturnMinimumLengthOfStringArrayTest()
        {
            //Arrange
            
            string[] test1 = { "this", "me", "String" };
            string[] test2 = { "this", "me", "" };
            string[] test3 = { "My", "Name", "is","Anbuvel" };
            //Act
            var result = sut.ReturnMinimumLengthOfStringArray(test1);
            var result2 = sut.ReturnMinimumLengthOfStringArray(test2);
            var result3 = sut.ReturnMinimumLengthOfStringArray(test3);
            //Assert
            Assert.Equal(6, result);
            Assert.Equal(4, result2);
            Assert.Equal(7, result3);
        }
        [Fact]
        public void DisplayCartesianProductTest()
        {
            //Arrange
           List<char> characterList = ['a', 'b', 'c', 'd' ];
            List<int> numberList = [ 1, 2, 3, 4 ];
            //Act
            var result = sut.DisplayCartesianProduct(characterList, numberList);
        }
        [Fact]
        public void DisplayCartesianProductTest2()
        {
            //Arrange
           List<char> characterList = ['a', 'b', 'c', 'd' ];
            List<int> numberList = [ 1, 2, 3, 4 ];
            List<string> color = ["green", "orange", "red"];
            //Act
            var result = sut.DisplayCartesianProduct(characterList, numberList, color);
        }
        [Fact]
        public void DisplayInnerJoinedDataSetTest()
        {
            var result = sut.DisplayInnerJoinedDataSet();
        }
        [Fact]
        public void DisplayRightJoinedDataSetTest()
        {
            var result = sut.DisplayRightJoinedDataSet();
        }
        [Fact]
        public void DisplayLeftJoinedDataSetTest()
        {
            var result = sut.DisplayLeftJoinedDataSet();
        }
        [Fact]
        public void DisplayBasedOnLengthTest()
        {
            var result = sut.DisplayBasedOnLength(["green", "orange", "red"]);
        }
        [Fact]
        public void GroupTheStringTest()
        {
            var result = sut.GroupTheString(["green","green","green","green", "orange", "red"]);
        }
        [Fact]
        public void DistinctElementInAscendingTest()
        {
            var result = sut.DistinctElementInAscending(["green","green", "orange", "red"]);
        }
    }
}
