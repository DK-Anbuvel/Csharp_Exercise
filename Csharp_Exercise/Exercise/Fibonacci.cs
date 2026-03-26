namespace Csharp_Exercise
{
    public partial class Exercise
    {
       private Dictionary<int, int> memo = new Dictionary<int, int>();
       public int FibonacciMemo(int n) // 0, 1, 1, 2, 3, 5, 8, 13, 21, 34
       {
           if (n <= 1) return n;

           if (!memo.ContainsKey(n))
           {
               memo[n] = FibonacciMemo(n - 1) + FibonacciMemo(n - 2);
           }
           return memo[n];
       }
       public int FibonacciTab(int n)
       {
            if (n <= 1) return n;

            int[] dp = new int[n + 1];
            dp[0] = 0;
            dp[1] = 1;

            for (int i = 2; i <= n; i++)
            {
               dp[i] = dp[i - 1] + dp[i - 2];
            }
            return dp[n];
       }
        public int Fibonacci(int n) // 0, 1, 1, 2, 3, 5, 8, 13, 21, 34
        {
            if (n <= 1) return n;
            memo[n] = Fibonacci(n - 1) + Fibonacci(n - 2);
            return memo[n];
        }
    }

}
