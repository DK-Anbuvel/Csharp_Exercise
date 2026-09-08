namespace Csharp_Exercise
{
    public partial class Leecodes
    {
        public partial class arrayProblem
        {
            public int[] PlusOne(int[] digits)
            {
                /* 1 2 3 
                  how to add 1 element in existing array ?
                    1)create new List, copy the existing array, covert array -> O(n)+1, O(N), Log(logn)
                    2)
                // 1. Create a new array that is 1 slot bigger
                   int[] newArray = new int[originalArray.Length + 1];
                // 2. Put the new element at index 0
                   newArray[0] = newElement;
                // 3. Copy the old array values into the remaining slots
                   Array.Copy(originalArray, 0, newArray, 1, originalArray.Length);
                 */
                if ((digits[digits.Length - 1]) != 9)
                {
                    digits[digits.Length - 1] = digits[digits.Length - 1] + 1; // some how digits[digits.Length - 1]++ it not pass the test case
                    return digits;
                }
                // int bal = 0;
                for (int i = digits.Length - 1; i >= 0; i--)
                {
                    if (digits[i] != 9)
                    {
                        digits[i]++;
                        return digits;
                    }
                    digits[i] = 0;
                    //   bal = 1;
                }

                int[] newArray = [1, .. digits];
                return newArray;

            }
            public int[] PlusOne1(int[] digits)
            {
                int tailingNineCnt = 0;
                for (int i = digits.Length - 1; i >= 0; i--)
                {
                    if (digits[i] == 9)
                    {
                        tailingNineCnt++;
                        continue;
                    }
                    break;
                }

                if (tailingNineCnt == 0)
                {
                    digits[digits.Length - 1] += 1;
                    return digits;
                }
                else if (tailingNineCnt == digits.Length)
                {
                    int[] result = new int[digits.Length + 1];
                    result[0] = 1;
                    return result;
                }
                else
                {
                    digits[digits.Length - 1 - tailingNineCnt] += 1;
                    for (int j = digits.Length - tailingNineCnt; j < digits.Length; j++)
                    {
                        digits[j] = 0;
                    }
                    return digits;
                }
            }
        }
    }
}
