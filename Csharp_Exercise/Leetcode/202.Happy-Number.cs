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
    }
}
