using Csharp_Exercise;
using LINQ.MockData;
using System.Data;

namespace LINQ_Exercises.Exercises
{
    public class Exe_3 : StudentModel
    {
        /* 21.Write a program in C# Sharp to create a list of
           numbers and display numbers greater than 80.
         */

        public List<int> DisplayGreaterThen(List<int> list)
        {
            var result = from s in list
                         where s > 80
                         select s;
            var result1 = list.Where(e => e > 80).ToList();

            return result.ToList();
        }
        /*
         * 22. Write a program in C# Sharp to find the strings for a specific minimum length.
         */
        public int ReturnMinimumLengthOfStringArray(string[] str)
        {
            var result = str.OrderByDescending(s => s.Length).Take(1).Select(s => s.Length)
                .FirstOrDefault(); // to convert IEnumerable to int
            var i = str.Min(s => s.Length);
            var y = str.Max(s => s.Length);
            var x = str.MaxBy(s => s.Length);

            var result1 = (from s in str
                           orderby s.Length descending
                           select s.Length).First();

            return result;
        }
        /*
         * 23. Write a program in C# Sharp to generate a cartesian product of two sets.
         */
        public List<(string, string)> DisplayCartesianProduct(List<char> characterList, List<int> NumberList)
        {
            var result = from c in characterList
                         from n in NumberList
                         select (Character: c.ToString(), Number: n.ToString());
            //           select new
            //             {
            //                 Charcter = c.ToString(),
            //                 Number = n.ToString()
            //             };
            //($"Charcter: {c}", $"Number: {n}");

            var result1 = characterList.SelectMany(n => NumberList,
                (characterList, n) => new
                {
                    Chacter = characterList,
                    NumberList = n
                });

            //(List<(string, string)>)result;
            return result.ToList();
        }
        /*
         * 24. Write a program in C# Sharp to generate a cartesian product of three sets.
         */
        public List<(string, string, string)> DisplayCartesianProduct(List<char> characterList, List<int> NumberList, List<string> colour)
        {
            var result = from c in characterList
                         from n in NumberList
                         from col in colour
                         select (Character: c.ToString(), Number: n.ToString(), col.ToString());

            var result1 = characterList.SelectMany(c => NumberList, (c, n) => new { c, n })
                                       .SelectMany(cn => colour, (cn, c) => new
                                       {
                                           Character = cn.c.ToString(),
                                           NumberList = cn.n.ToString(),
                                           Colour = c.ToString()
                                       });

            return result.ToList();
        }

        /* 25. Write a program in C# Sharp to generate an Inner Join between two data sets.
         */
        public dynamic DisplayInnerJoinedDataSet()
        {
            var result = from s in student
                         join d in department on s.DepartmentID equals d.ID
                         select new
                         {
                             Name = $"{s.FirstName} {s.LastName}",
                             DepartmentName = d.Name
                         };

            var result1 = student.Join(department, s => s.DepartmentID, d => d.ID, (s, d) => new
            { Name = $"{s.FirstName} {s.LastName}", Department = $"{d.Name}" })
                      .ToList();

            return result;
        }
        /*26. Write a program in C# Sharp to generate a Left Join between two data sets.
         */
        public dynamic DisplayLeftJoinedDataSet()
        {
            var result = from s in student
                         join d in department on s.DepartmentID equals d.ID into groupedData
                         from c in groupedData.DefaultIfEmpty() // this is the important line for left
                         // join, it preserve all student(left) data if no matching department found, department value assign to null
                         select new
                         {
                             Name = $"{s.FirstName} {s.LastName}",
                             DepartmentName = c == null ? "NA" : c.Name
                         };
            foreach (var std in result)
            {
                Console.WriteLine($"   {std.Name} {std.DepartmentName}");
            }

            var result1 = student.GroupJoin(department, s => s.DepartmentID, d => d.ID,
                (std, depart) => new { std, depart })
                .SelectMany(c => c.depart.DefaultIfEmpty(), (s, c) => new
                {
                    Name = $"{s.std.FirstName} {s.std.LastName}",
                    DepartmentName = c == null ? "NA" : c.Name
                });

            return result;
        }

        /*27. Write a program in C# Sharp to generate a Right Outer Join between two data sets.
         */

        public dynamic DisplayRightJoinedDataSet()
        {
            var result = from d in department
                         join s in student on d.ID equals s.DepartmentID into groupedData
                         from c in groupedData.DefaultIfEmpty()
                         select new
                         {
                             Name = c == null ? "NA" : $"{c.FirstName} {c.LastName}",
                             DepartmentName = d.Name,
                            
                         };

            foreach (var std in result)
            {
                Console.WriteLine($"   {std.Name} {std.DepartmentName}");
            }

            var result1 = department.GroupJoin(student, d =>d.ID , s => s.DepartmentID,
                ( depart, std) => new {  depart , std })
                .SelectMany(c => c.std.DefaultIfEmpty(), (c, s) => new 
                {
                    Name = s == null ? "NA" : $"{s.FirstName} {s.LastName}",
                    DepartmentName = c.depart.Name
                });

            return result;
        }

        /*28. Write a program in C# Sharp to display the list of items in the array according to
         * the length of the string then by name in ascending order.
         */
        public dynamic DisplayBasedOnLength(string[] items)
        {
            var result = from s in items
                         orderby s.Length ascending
                         select s;

            IEnumerable<string> cityOrder = items.OrderBy(str => str.Length) 
                                           .ThenBy(str => str);

            return result;
        }
        /*29. Write a program in C# Sharp to split a collection of strings into some groups.
         */
        public dynamic GroupTheString(string[] items)
        {
            var result = from i in Enumerable.Range(0, items.Length) // this generate sequence of integer 0 to item.length -1 (totalcount)
                         group items[i] by i / 3;

            var result1 = Enumerable.Range(0, items.Length).GroupBy(s => s / 3, i => items[i]);


            foreach (var group in result)
            {
                Console.WriteLine($"Group {group.Key}: {string.Join(", ", group)}");
            }
            return result;
        }

        /*30. Write a program in C# Sharp to arrange the distinct elements in the list in ascending order.
         */

        public dynamic DistinctElementInAscending(string[] items)
        {
            var result = (from s in items
                         select  s)
                         .Distinct()
                         .OrderBy(s =>s.Length)
                         .ToList();

            var result1 = items
                   .Distinct()
                   .OrderBy(s => s.Length)
                   .ToList();
            return result1;
        }
    }
}
