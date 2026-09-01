namespace Csharp_Exercise
{
    public partial class Leecodes
    {
        public partial class arrayProblem
        {
            public int DistributeCandies(int[] candyType) // 25ms
            {

                /*
                  about the problem:-
                     candyType can contain duplicate. n is even.
                     alice can eat candyType.Length/2  only.
                     need the return unique candytype no. is always less then or equal to n/2.

                  my approach:-
                     attempt 1:-
                       candyType.Distinct().Count();
                */
                int a = candyType.Distinct().Count();
                return a > (candyType.Length / 2) ? (candyType.Length / 2) : a;
            }
        }
    }
}
