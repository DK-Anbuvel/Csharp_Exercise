using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp_Exercise
{
	public class Leetcode
	{
        public long MaxProfit(int[] prices, int[] strategy, int k) //Time Limit Exceeded (TLE) O(n^2) // O(n) --> prefix sum/Side window
        {
            prices = [4, 2, 8]; strategy = [-1, 0, 1]; k = 2;
            /*  p-1 -2   
             constrient:-
Origina [1, 1, 0]           (1 × 5) + (1 × 4) + (0 × 3) = 5 + 4 + 0	9
Modify [0, 1]	[0, 1, 0]	(0 × 5) + (1 × 4) + (0 × 3) = 0 + 4 + 0	4
Modify  [1, 2]	[1, 0, 1]	(1 × 5) + (0 × 4) + (1 × 3) = 5 + 0 + 3	8

            2 <= prices.length == strategy.length <= 105
            1 <= prices[i] <= 105
            -1 <= strategy[i] <= 1
            2 <= k <= prices.length
            k is even
            goal : to find hight profit value 
            consider :-
                    can change k/2 element as 0 or 1.
            think to do :-
                  profit value = p[i] * s[i]
                  no. of possible value =  
                      loop p.length and i <

            Input: prices = [5,4,3], strategy = [1,1,0], k = 2 ,n=3

Gain = 2 - (-4) = +6 
Final Profit = Base Profit + Max Gain
              = 4 + 6
              = 10
             */
            long highProfit = 0;
            for (int i = 0; i < prices.Length; i++)
                highProfit += strategy[i] * prices[i];

            //[5, 4, 3]
            // problem : [0,1,3] easly can loop this via below program
            // but when comes in [5,0,1] how to modify the strategy that need to start with 1 index.
            for (int i = 0; i <= prices.Length - k; i++)
            {
                int Current_sum = default;
                for (int j = 0; j < prices.Length; j++)
                {
                    if(j < i)
                        Current_sum += (prices[j] * strategy[j]);
                    else if (j-i < k / 2 )
                        Current_sum += (prices[j] * 0);
                    else if (j-i < k )
                        Current_sum += (prices[j] * 1);
                    else
                        Current_sum += (prices[j] * strategy[j]);
                }
                highProfit = Math.Max(highProfit, Current_sum);
            }
            return highProfit;
        }

        public long MaxProfit1(int[] prices, int[] strategy, int k) // GPT 
		{
			prices = [4, 2, 8]; strategy = [-1, 0, 1]; k = 2;
            int n = prices.Length;

            // Base profit
            long baseProfit = 0;
            for (int i = 0; i < n; i++)
                baseProfit += (long)strategy[i] * prices[i];

            // Prefix sum of original contribution
            long[] pref = new long[n + 1];
            for (int i = 0; i < n; i++)
                pref[i + 1] = pref[i] + (long)strategy[i] * prices[i];

            // Prefix sum of prices
            long[] pricePref = new long[n + 1];
            for (int i = 0; i < n; i++)
                pricePref[i + 1] = pricePref[i] + prices[i];

            long maxProfit = baseProfit;

            for (int i = 0; i + k <= n; i++)
            {
                // old contribution in window
                long oldSum = pref[i + k] - pref[i];

                // new contribution (only last k/2 are sells)
                long newSum = pricePref[i + k] - pricePref[i + k / 2];

                long candidate = baseProfit - oldSum + newSum;
                maxProfit = Math.Max(maxProfit, candidate);
            }

            return maxProfit;
        }

        public long MaxProfit2(int[] prices, int[] strategy, int k) // best case (time)
        {
            long maxProfit = 0;
            long windowProfit = 0;
            long modificateProfit = 0;
            long maxModificateProfit = 0;
            var halfK = k >> 1;
            Span<int> profits = stackalloc int[prices.Length];

            for (var i = 0; i < prices.Length; i++)
            {
                var price = prices[i];
                profits[i] = price * strategy[i];
                maxProfit += profits[i];

                if (i < k)
                {
                    if (i >= halfK)
                    {
                        modificateProfit += price;
                        if (i == k - 1)
                        {
                            windowProfit = maxProfit;
                            maxModificateProfit = modificateProfit - windowProfit;
                        }
                    }
                    continue;
                }

                windowProfit += profits[i];
                windowProfit -= profits[i - k];

                modificateProfit += price;
                modificateProfit -= prices[i - halfK];

                var temp = modificateProfit - windowProfit;
                if (temp > maxModificateProfit)
                {
                    maxModificateProfit = temp;
                }
            }

            if (maxModificateProfit > 0)
            {
                maxProfit += maxModificateProfit;
            }

            return maxProfit;
        }
        public long MaxProfit3(int[] prices, int[] strategy, int k) // best case (space)
        {
            long totalProfit = 0;

            //total profit without actions
            for (int i = 0; i < prices.Length; i++)
                totalProfit += prices[i] * strategy[i];

            //calculate max total profit with redefining a strategy in the begining 

            long insideProfit = 0, outsideProfit = 0;
            for (int i = 0; i < prices.Length; i++)
            {
                if (i >= k / 2 && i < k) insideProfit += prices[i] * 1;
                else if (i < k) continue;
                else outsideProfit += prices[i] * strategy[i];
            }

            totalProfit = Math.Max(totalProfit, insideProfit + outsideProfit);

            //calculate max total profit with redefining a strategy
            for (int left = 1, right = k + 1; right <= prices.Length; left++, right++)
            {
                outsideProfit -= prices[right - 1] * strategy[right - 1];
                outsideProfit += prices[left - 1] * strategy[left - 1];

                insideProfit += prices[right - 1];
                insideProfit -= prices[left + (k / 2) - 1];

                totalProfit = Math.Max(totalProfit, outsideProfit + insideProfit);
            }

            return totalProfit;
        }
    }

}