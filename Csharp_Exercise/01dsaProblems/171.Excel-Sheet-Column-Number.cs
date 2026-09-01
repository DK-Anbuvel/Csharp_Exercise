namespace Csharp_Exercise
{
    public partial class Leecodes
    {
        public int TitleToNumber(string columnTitle) // time O(n) space O(1)
        {
            /* do
                (alphaPlaceValue) 
               while
                 (alphaPlaceValue * (power(26 ,index))) 

               last place value (alphaPlaceValue *(26 * nth)) + take last char in the given string ao
             */
            if (columnTitle.Length < 0) return 0;
            int res = 0;
            int i = columnTitle.Length - 1;
            int PlaceValue = 0;
            do
            {
                if(PlaceValue ==0)
                res = ((int)(columnTitle[i]) - 64);
                else
                    res = res + (((int)(columnTitle[i]) - 64) * ((int)Math.Pow(26,PlaceValue)));
                i--;
                PlaceValue++;
            } while (i >= 0); 

            return res;
        }
        public int TitleToNumber1(string columnTitle)
        {
            int result = 0;

            foreach (char c in columnTitle)
            {
                result = result * 26 + (c - 'A' + 1);
            }

            return result;
        }
        public int TitleToNumber2(string columnTitle)
        {
            int digitNum = 0;
            int total = 0;
            char[] charArray = columnTitle.ToCharArray();
            Array.Reverse(charArray);
            foreach (char c in charArray)
            {
                int toAdd = (int)Math.Pow(26, digitNum) * CharToInt(c);
                total += toAdd;
                digitNum++;
            }
            return total;
        }


        private int CharToInt(char c)
        {
            int A = (int)'A';
            return (int)c - A + 1;
        }
        public int TitleToNumber3(string columnTitle)
        {
            int result = 0;
            int degree = 1;
            for (int i = columnTitle.Length - 1; i >= 0; i--)
            {
                char c = columnTitle[i];
                result += degree * (c - 64);
                degree *= 26;
            }
            return result;
        }
    }
}
