namespace Csharp_Exercise
{
    public partial class Leecodes
    {
        public bool IsUgly(int n) // time O(1) space O(1) 
        {
            /*
              ugly number seens it is possitive number, retun !n < 0.
              for finding prime factor, I am using short division(ladder method)
            
              Simulation/Prime Factorization
             */
            if (n <= 0) return false;
            if (n == 1) return true;
            while (n > 1)
            {
                if (n % 2 == 0) // check odd or even
                {
                    n /= 2;
                }
                else if (n % 3 == 0)
                {
                    n /= 3;
                }
                else if (n % 5 == 0)
                {
                    n /= 5;
                }
                else
                {
                    return false; // no. divided by other than 2, 3, 5 factor, so it is  
                                  // considered as non-ugly no.
                }
            }
            return true;
        }
        int[] factors = { 2, 3, 5 };

        public bool IsUgly1(int n)
        {
            if (n <= 0)
            {
                return false;
            }

            if (n == 1 || n == 2 || n == 3 || n == 5)
            {
                return true;
            }

            for (int i = 0; i < factors.Length; i++)
            {
                if (n % factors[i] == 0)
                {
                    return IsUgly(n / factors[i]);
                }
            }
            return false;
        }
        public bool IsUgly2(int n)
        {
            if (n <= 0) return false;

            int[] fatores = { 2, 3, 5 };

            foreach (int fator in fatores)
            {
                while (n % fator == 0)
                {
                    n /= fator;
                }
            }

            return n == 1;
        }
    }
}
