namespace Csharp_Exercise
{
    public partial class Leecodes
    {
        public int Fib(int n) // time O(n) space O(n)
        {

            /* about this problem:-
                   classical Fibonacci number series problem, Here need to return
                   the last two digits sums in the n term for fibonacci series.

              My approach:-
                   Recursion pattern, Create dictionary<nth term,sum> 
                   store values till n > 1. 0 <= n <= 30 so we can use int value is enough.
             */
            if (n <= 1) return n;

            int[] map = new int[n + 1];

            map[0] = 0;
            map[1] = 1;

            for(int i=2;i<=n; i++)
            {
                map[i] = map[i - 1] + map[i - 2];
            }
            return map[n];
        }
        public int Fib1(int n) // O(n) O(1)
        {
            if (n <= 1)
                return n;

            int first = 0;
            int second = 1;
            int next;
            for (int i = 2; i <= n; i++)
            {
                next = first + second;
                first = second;
                second = next;
            }
            return second;
        }
        private readonly int[] _alreadyComputedValues = new int[31];

        public int Fib2(int n) //time O(1) space O(31)
        {
            if (n is 0)
                return 0;

            if (n is 1)
                return 1;

            if (_alreadyComputedValues[n] is not 0) // if exist return else recursion 
                return _alreadyComputedValues[n];

            return _alreadyComputedValues[n] = Fib(n - 1) + Fib(n - 2);
        }
        public int Fib3(int n)
        {
            if (n == 0)
                return 0;
            if (n == 1)
                return 1;
            return Fib3(n - 1) + Fib3(n - 2);
        }
    }
}
