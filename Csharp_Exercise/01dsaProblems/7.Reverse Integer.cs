namespace Csharp_Exercise
{
    public partial class Leecodes
    {
        public int Reverse(int x)
        {
            // use try catch / try to convert 32-bit integer catch return 0.
            // 32-bit always be in 32-bit even if we reverse the int 32-bit
            // so first try to convert 

            int reverse = 0;
            int temp = 0;
            try
            {
                temp = Math.Abs(x); // case 1: 1,534,236,469  // case 2: -2147483648 (overflow)
            }
            catch (Exception ex)
            {
                return 0;
            }
            while (temp > 0)
            {
                int rem = temp % 10;
                if (x < 0)
                    if (-reverse <= -214748364.8) // Decreasing 10 tense in min 32 bit integer
                        return 0;
                if (x > 0)
                    if (reverse >= 214748364.7)  // Decreasing 10 tense in max 32 bit integer
                        return 0;
                //if (((reverse * 10) + rem) <= Int32.MinValue || ((reverse * 10) + rem) >= Int32.MaxValue) return 0; //failed
                reverse = (reverse * 10) + rem; // 964,632,435 * 10 =9,646,324,350 + 5  overflow happened
                temp /= 10;
            }
            if (x < 0) reverse = reverse * -1;
            //Int32.MaxValue (2,147,483,647) and Int32.MinValue (-2147483648).
            return reverse;
        }
        public int Reverse1(int x) // best tricky case
        {
            var result = 0;

            while (x != 0)  // case: 1534236469
            {
                var remainder = x % 10;
                var temp = result * 10 + remainder;

                // in case of overflow, the current value will not be equal to the previous one
                if ((temp - remainder) / 10 != result)  //while reverse = 1056389759
                {
                    return 0;
                }

                result = temp;
                x /= 10;
            }

            return result;
        }
        public int Reverse2(int x) // best case(time)
        {

            // check overflow or not
            if (x > int.MaxValue || x < int.MinValue)
                return 0;

            string xStr = x.ToString();

            // check whether is negative number or not
            bool isLowerThanZero = x < 0;

            // remove '-'
            if (isLowerThanZero)
                xStr = xStr.Substring(1);

            // reverse
            xStr = new string(xStr.Reverse().ToArray());

            // add whether lower than zero
            xStr = isLowerThanZero ? '-' + xStr : xStr;

            // incase out of value
            if (!int.TryParse(xStr, out int value))
                return 0;

            // can convert, return value
            return value;
        }

        public int Reverse3(int x) //best case (memory)
        {
            long rev = 0; // long is illegal.
            while (x != 0)
            {
                rev = rev * 10 + (x % 10);
                x /= 10;

                if (rev > int.MaxValue || rev < int.MinValue)
                    return 0;
            }

            return (int)rev;
        }
    }
}
