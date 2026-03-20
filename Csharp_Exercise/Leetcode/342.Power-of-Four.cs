namespace Csharp_Exercise
{
    public partial class Leecodes
    {
        public bool IsPowerOfFour(int n) // time O(logN) space O(1) // bit manipulation method O(1)
        {
            /*
              We can solve this problem with recursion
              by n%4==0 ; n/4 == 4 
            */
            if (n == 1) return true;
            if (n == 4) return true; // below logic not work with n = 4
            if (n < 4) return false;
            while (n > 3)
            {
                if (n % 4 != 0) return false;
                n /= 4;
                if (n == 4) return true; // 4 square numbers always like 4 * 4 * 4 * n then while divided by 4 it must end with 4  
            }
            return false;
        }
        public bool IsPowerOfFour1(int n)
        {
            double x = Math.Log(n, 4);
            return x == (int)x;
        }
        public bool IsPowerOfFour2(int n)
        {

            if (n <= 0)
                return false;
            if (n == 1)
                return true;

            if (n % 4 != 0)
                return false;
            return IsPowerOfFour2(n / 4);

        }
        public bool IsPowerOfFour3(int n)
        {
            for (int i = 0; i <= 31; i++)
            {
                if (Math.Pow(4, i) == n)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
