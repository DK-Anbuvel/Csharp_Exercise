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
        public bool IsPowerOfTwo(int n) // Timeout Exception
        {
            int i = 2;
            if (n == 1) return true;
            if (n == 0) return false;
            while (n >= i)
            {
                if (n == i) return true;
                else
                    i *= 2;

            }
            return false;
        }
        public bool IsPowerOfTwo1(int n)
        {
            /*Time complexity:
                    O(log n)
             Space complexity:
                    O(1)
             */
            if (n<1) return false; // 2 power numbers not less then zero.

           while(n >= 2)
            {
                if(n %2 !=0) // power number should be even 
                    return false;
                n /= 2;
            }
            return true;
        }
        public bool IsPowerOfTwo2(int n) // recursion
        {
            // Base cases
            if (n == 1) return true;      // 2^0
            if (n < 1 || n % 2 != 0) return false;

            return IsPowerOfTwo2(n / 2);
        }
        public bool IsPowerOfTwo3(int n) //bitwise operation
        {
            // 2 power as constist exactly one 1 bit and all other bits are 0 eg. 2^2 =0100
            return n > 0 && (n & (n - 1)) == 0; // if n-1 turns the single 1 into 0 and turns all bits to the right into 1
            // eg.(4-1) = 3 0011 
            // 0100
            // 0011
            //------
            // 0000      // & operator both operands are 1 then result will be 1 otherwise 0.
            //------
        }
        public bool IsPowerOfTwo4(int n) // worse case (time)
        {
            // round up to check more case
            int sqrtN = (int)Math.Ceiling(Math.Sqrt(n));
            int start = 0;
            int end = sqrtN;

            if (sqrtN < 0)
            {
                start = sqrtN;
                end = 0;
            }

            for (int i = start; i <= end; i++)
            {
                if (Math.Pow(2, i) == n)
                    return true;
            }

            return false;
        }
        public bool IsPowerOfTwo5(int n) // worse case (space)
        {
            if (n == 0)
                return false;
            if (n == 1)
                return true;

            if (n % 2 == 0)
                return IsPowerOfTwo5(n / 2);

            return false;
        }

    }
}
