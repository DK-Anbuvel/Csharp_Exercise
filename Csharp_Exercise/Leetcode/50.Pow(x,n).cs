
namespace Csharp_Exercise
{
    public partial class Leecodes
    {
        public double MyPow(double x, int n)
        {
            return Math.Pow(x, n);
        }
        /*
          Traditional Method
             x muplited by n times
          
         */
        public double MyPow2(double x, int n) // TLE n= 2147483647
        {
            double ans = 1.0;
            int expo = n;
            if (expo < 0) expo = -(expo); //if negative value into positive
            while(expo > 0)
            {
                ans = ans * x;

                expo --;
            }

            if (n < 0)
            {
                ans = 1 / ans;
            }
            return ans;
        }
        /*
          Binary Exponentiation(Exponentiation by squaring)
            
           It repeatedly squares the base and halves the exponent.
              eg: 2^16  4^8  16^4 256^2  6589^1 
           if the current exponents is odd. eg: 2^3
              it multiplies the current answer by base.
           if the Negative exponents x^-n. eg: 2^-2
              convert into (1/x)^n.
          
           Since the exponenet is halved in each iteration, the time complexity is O(log n).

         * */
        public double MyPow1(double x, int n)
        {

            long power = n;
            double ans = 1.0;

            if (power < 0)
            {
                x = 1 / x;
                power = -power;
            }

            while (power > 0)
            {
                if ((power & 1) == 1)
                {
                    ans *= x;
                }

                x *= x;
                //power /= 2;
                power >>= 1;
            }

            return ans;
        }
        public double MyPow3(double x, int n)
        {
            bool isReciprocal = true;
            switch (n)
            {
                case > 1:
                    // Negate as negative integers
                    // have a higher range than
                    // positive integers.
                    n *= -1;
                    isReciprocal = false;
                    break;
                // Exponent identity.
                case 1:
                    return x;
                // Exponent absorption. x is guaranteed
                // to not be 0 here.
                case 0:
                    return 1;
            }

            // Keep track of the squares computed.
            double squaredBase = x;
            Stack<double> squares = [];

            // Ensure that the currentBase
            // will be raised to the maximum
            // power of two whose result is
            // less than the actual value of
            // x^n.
            int powerOfSquare = -2;
            while (n <= powerOfSquare && powerOfSquare < 0)
            {
                // Square the squaredBase.
                squares.Push(squaredBase);
                squaredBase *= squaredBase;
                powerOfSquare <<= 1;
            }

            if (powerOfSquare >= 0)
            {
                // Doubling -2^31 will underflow
                // to 0, so remain under that
                // threshold.
                powerOfSquare = -2_147_483_648;
            }
            else
            {
                powerOfSquare >>= 1;
            }

            double result = squaredBase;

            // Square root the squaredBase
            // by using the precomputed
            // squares stack and multiply
            // by result to finally make
            // it x^|n|.
            int complement = n - powerOfSquare;
            while (complement < 0)
            {
                while (powerOfSquare < complement)
                {
                    squaredBase = squares.Pop();
                    powerOfSquare >>= 1;
                }

                result *= squaredBase;
                complement -= powerOfSquare;
            }

            // If n was negative to begin
            // with, take the reciprocal.
            return isReciprocal ? 1 / result : result;
        }
        Dictionary<(double, uint), double> _memo = new();

        public double MyPow4(double x, int n)
        {
            uint posN;
            if (n < 0) { posN = (uint)(-(long)n); x = 1 / x; }
            else posN = (uint)n;
            return MyPow(x, posN);
        }
        //This version only works on positive exponents
        double MyPow(double x, uint n)
        {
            //  n= 0 1 2 3 4  5
            //2^n= 1 2 4 8 16 32

            //x^n = x * x * x ... n times
            //x^n = x^(n-1) * x
            //x^n =? x^(n/2) * x^(n/2) ?
            if (n == 0) return 1;
            if (n == 1) return x;
            if (_memo.ContainsKey((x, n))) { return _memo[(x, n)]; }
            uint halfN = n / 2;
            uint r = n % 2;
            return _memo[(x, n)]
                = MyPow(x * x, halfN)
                    //* MyPow(x, halfN) 
                    * (r == 0 ? 1 : x);
        }
        public double MyPow5(double x, int n)
        {
            double ret = 1.0;
            double mult;

            if (n == 0)
                return 1;

            if (x == 1)
                return 1;

            if (x == -1)
            {
                return n % 2 == 0 ? 1 : -1;
            }

            if (n > 0)
            {
                mult = x;
            }
            else
            {
                mult = 1.0 / x;
            }

            for (long i = 0; i < Math.Abs((long)n); i++)
            {
                ret = ret * mult;
                if (ret == double.MinValue || ret == 0)
                    return ret;
            }

            return ret;
        }
        private double FastPow(double x, long n)
        {
            if (n == 0)
                return (double)1;

            double half = FastPow(x, n / 2);

            if (n % 2 == 0)
                return half * half;
            else
                return half * half * x;
        }

        public double MyPow6(double x, int n)
        {
            if (n == 0)
                return 1;

            if (x == 0)
                return 0;

            if (x == 1)
                return 1;
            var nlong = n;

            if (n < 0)
            {
                x = 1 / x;
                nlong = -1 * n;
            }

            return FastPow(x, nlong);
        }
        public double MyPow7(double x, int n)
        {
            //if(n==0 && x!=0) return 1;
            if (x == 1 || (x == -1 && n % 2 == 0)) return 1;
            else if (x == -1 && n % 2 != 0) return -1;
            if (n == int.MinValue) return 0;
            double res = 1;
            bool neg = n < 0 ? true : false;
            if (neg) n *= -1;
            for (int i = 0; i < n; i++)
            {
                bool dem = res == double.NegativeInfinity || res == double.PositiveInfinity;
                if (dem && neg) return 0;
                else if (dem) return res;
                res *= x;
            }
            return neg ? 1.0 / res : res;
        }
    }
}
