using System.Numerics;

namespace Csharp_Exercise
{
    public partial class Leecodes
    {/*
        Let take step[3] = total ways to climb in step[2]  + total ways to climb in step[1].

        step[1] = step[0] to one step ---> total ways to climb step[1] is 1.
        step[2] = step[1] to one step and step[0] to two steps ---> total ways to climb step[2] is 2.
        then step[3] = 1+2 = 3 ways. 
        simple.
      */
        public int ClimbStairs(int n) //dynamic programming / Memorization O(n) O(n) // step[n] = step[n-1] + step[n-2]
        {
            int[] dp = new int[n + 1];
            Array.Fill(dp, -1);
            int k = ClimbStairsHelper(n, dp);
            return k;
        }
        public int ClimbStairsHelper(int n, int[] dp)
        {
            if (n <= 1) return 1;
            if (dp[n] != -1) return dp[n];
            dp[n] = ClimbStairsHelper(n - 1, dp) + ClimbStairsHelper(n - 2, dp);
            return dp[n];
        }
        public int ClimbStairs1(int n)  //Tabulation O(n) O(n)
        {
            int[] tab = new int[n + 1];
            if (tab.Length > 0) tab[0] = 1;
            if (tab.Length > 1) tab[1] = 1;
            for (int i = 2; i < tab.Length; i++)
                tab[i] = tab[i - 1] + tab[i - 2];
            return tab[n];
        }
        public int ClimbStairs2(int n) //Space Optimization  O(n) O(1)
        {
            if (n <= 1) return 1;
            int firstNum = 1, secondNum = 1, thirdNum = 0;
            for (int i = 2; i < n + 1; i++)
            {
                thirdNum = firstNum + secondNum;
                firstNum = secondNum;
                secondNum = thirdNum;
            }
            return thirdNum;
        }
        public int ClimbStairs3(int n) // 
        {
            if (n > 3)
            {
                int totalsteps = n;
                int r = 1;
                int step2 = 1;
                int step1 = totalsteps - step2 * 2;
                n = n - 2;
                while (n >= 0)
                {
                    r = r + combination(step2 + step1, step1, step2);
                    ++step2;
                    step1 = totalsteps - step2 * 2;
                    n = n - 2;
                }
                return r;
            }
            else
            {
                return n;
            }
        }
        int combination(int total, int step1, int step2)
        {
            BigInteger totalfact = 1;
            if (step1 == 0)
            {
                step1 = 1;
            }
            if (step2 == 0)
            {
                step2 = 1;
            }
            int big = step2;
            int small = step1;
            if (step1 > step2)
            {
                big = step1;
                small = step2;
            }

            for (int i = total; i > big; i--)
            {
                totalfact = totalfact * i;
            }

            for (int i = 2; i <= small; i++)
            {
                totalfact = totalfact / i;
            }
            return (int)(totalfact);
        } 
        //space-optimized approach
        public int ClimbStairs4(int n)
        {
            if (n == 0 || n == 1) return 1;
            int prev1 = 1;
            int prev2 = 1;

            for (int i = 2; i <= n; i++)
            {
                int curr = prev1 + prev2;
                prev2 = prev1;
                prev1 = curr;
            }
            return prev1;
        }
        Dictionary<int, int> memo = new();
        public int ClimbStairs5(int n)
        {
            if (n == 0)
            {
                return 0;
            }
            if (n == 1)
            {
                return 1;
            }
            if (n == 2)
            {
                return 2;
            }
            if (memo.ContainsKey(n))
            {
                return memo[n];
            }
            ;
            int res = ClimbStairs(n - 1) + ClimbStairs(n - 2);
            if (!memo.ContainsKey(n))
            {
                memo.Add(n, res);
            }
            return res;
        }

    }
}
