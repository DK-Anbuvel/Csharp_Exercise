using Csharp_Exercise;

namespace LINQ
{
    public class Program
    {

        public void main()
        {
            // subscribe to the global unhandled exception event
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_Exception;
            Console.WriteLine("Enter which method to Excecute");
            //L1 services = new L1();            // Creates instance of L1
            //Program program = new Program(services); // Injects L1 into Program
            //program.runMeth();
            // Calls the method   

            //Dependency Injection (DI) in C#, particularly with ASP.NET Core, which has built-in DI support so we don't want to add 
            // configration mannually. 

            //joins
            //var excu = Console.ReadLine();
            //Joins joins = new Joins();
            //switch (excu)
            //{
            //    case "InnerJoin":
            //        joins.MethodSynInnerJoin();
            //        joins.QuerySyndInnerJoin();
            //        break;
            //    case "LeftJoin":
            //        joins.MethodLeftJoin();
            //        joins.QueryLeftJoin();
            //        break;
            //    case "RightJoin":
            //        joins.MethodRightJoin();
            //        break;
            //    case "FullOuterJoin":
            //         joins.QueryFullOuterJoin();
            //        break;
            //    case "CrossJoin":
            //        joins.QueryCrossJoin();
            //        joins.MethodCrossJoin();
            //        break;
            //    case "GroupJoin":
            //        joins.MethodGroupJoin();
            //        joins.QueryGroupJoin();
            //        break;
              
            //    default:
                    
            //        break;
            //}
            //joins

        }
        private static void CurrentDomain_Exception(object sender, UnhandledExceptionEventArgs e)
        {
            Exception ex = (Exception)e.ExceptionObject;
            Console.WriteLine($"Message: {ex.Message}");
            Console.WriteLine($"StackTrace: {ex.StackTrace}");

            // Optionally, check if the application is terminating
            if (e.IsTerminating)
            {
                Console.WriteLine("The application is terminating due to this unhandled exception.");
            }

        }
    }
}
