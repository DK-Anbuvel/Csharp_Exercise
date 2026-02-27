namespace Csharp_Exercise
{
    public partial class Leecodes
    {
        public int ClimbStairs(int n) //Memoization O(n) O(n)
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
            dp[n] = ClimbStairsHelper(n - 1, dp) +
                    ClimbStairsHelper(n - 2, dp);
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
    }
}
