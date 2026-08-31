namespace Csharp_Exercise
{
    public partial class Leecodes
    {
        public partial class arrayProblem
        {
            public int MaxProfit(int[] prices) // time O(n) space O(1)
            { // [5,2,3,4,5]
                /*
                 about this problem:-
                    return max profit,
                    buy and sell not happend in backward.

                 My approach:-
                    greedy algorithm:-
                     profit += hight no. - smallest no.
                */
                int profit = 0;

                for (int i = 1; i < prices.Length; i++)
                {

                    if (prices[i] > prices[i - 1])
                        profit += prices[i] - prices[i - 1];

                }

                return profit;
            }
        }
    }
}
