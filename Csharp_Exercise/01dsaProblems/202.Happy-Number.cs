using Csharp_Exercise;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp_Exercise
{
    public partial class Leecodes
    {
        public static HashSet<int?> seen = new HashSet<int?>();
        public bool IsHappy(int n)// Recursion method Time :O(LogN)
        {
            seen.Add(n);

            if (n == 0) return false;

            int tempSum = 0;
            while (n != 0)
            {
                int rem = n % 10;
                tempSum += (int)Math.Pow(rem, 2);
                n = n / 10;
            }
            if (tempSum == 0) return false;
            if (tempSum == 1) return true;
            if (seen.Contains(tempSum)) return false;
            return IsHappy(tempSum);
        }
        public bool IsHappy1(int n)
        {
            // the fact that the solution may loop forever is a hint that we need 
            // to use a slow and fast pointer solution

            // both "pointers" start at same "index"
            int fastSum = n;
            int slowSum = n;

            do
            {
                slowSum = ComputeSumOfSquares(slowSum);
                // we emulate the "fast pointer" idea by having the fastSum
                // be calculated as the result of "2 steps" vs the "slow pointers"
                // 1 step above (i.e., we invoke our logic twice instead of once
                // for the slow pointer)
                fastSum = ComputeSumOfSquares(ComputeSumOfSquares(fastSum));
            } while (fastSum != slowSum);

            return slowSum == 1;
        }

        public int ComputeSumOfSquares(int n)
        {
            // loop through all the digits of this number n 
            // and computer running sum of the squares of each digit
            int sum = 0;
            int curDigit = 0;
            for (int value = n; value > 0; value = value / 10)
            {
                // each iteration of the loop we divide the value (which
                // is also the loop variable) by 10 
                // (effectively shifting it right by one digit).

                // collect the value of the rightmost digit (int the ones place)
                // and compute its square and add to sum and go to next iteration
                curDigit = value % 10;
                sum += (curDigit * curDigit);
            }

            return sum;
        }

    }
}
