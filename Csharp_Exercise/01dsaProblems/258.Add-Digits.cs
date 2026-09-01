namespace Csharp_Exercise
{
    public partial class Leecodes
    {
        public int AddDigits(int num) // time (log n) space (log n)
        {
            /*
              This problem we can slove with loops/ Recursion
              loop run until the result < 10

            Calculating the digital root of a number using iterative summation or mathematical congruence
            */
            if (num < 10) return num;
            int result = 0;
            while (num != 0)
            {
                result = num % 10 + result;
                num /= 10;
            }
            return AddDigits(result);
        }
        public int AddDigits1(int num) // O(d × iterations) 38
        {
            while (num >= 10)
                num = num.ToString() // converted to string 
                    .Select((x, i) => x - '0').Sum(); // x is char, i is index ; x- '0' bcz of ASCII value  51 - 48 = 3 ; here i is not used

            return num;
        }
        public int AddDigits2(int num)
        {
            string numString;

            while (num > 9)
            {
                numString = num.ToString();
                num = 0;
                foreach (char c in numString)
                {
                    num += int.Parse(c.ToString());
                }
            }

            return num;
        }
        public int AddDigits3(int num) // time O(1) pure math //digital root
        {
            if (num == 0)
                return 0;
            /*
              our goal as to be find sum of digits less then 10 ,
              so first divides the numm with 9 the reminder as the result
             because here used mathematical concept called digital root.
             it is a numerical property obtained by repeatedly summing the digits of a
            number unitl only a single digit remains. 

            it represents the remainder of a no. modulo 9
            it is useful in modular arithmetic and divisibility tests such as "casting out nines".

            formula(base 10) : dr(n) = 1+((n-1) mode 9)  
            // why +1 and -1 ?  because as per formula digital root should be 1-9 , ex: n=9 then directly 9%9 = 0 then range become 0-9 so 
             then little modifiyes ; n= 9 then 1+((9-1)% 9) = 1+(8 % 9)= 9//

            Range: 1 – 9 for nonzero n; 0 for n = 0.
             */
            var rest = num % 9;
            return rest == 0 ? 9 : rest;
        }
        public int AddDigits4(int num)
        {
            return num == 0 ? 0 : 1 + (num - 1) % 9;  // we don't want be  +1 and -1 here because we return directly the reminder we don't want 
            /// consider the range 0 - 9 or 1 - 9 //
        }
    }
}
