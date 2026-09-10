using Csharp_Exercise;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Csharp_Exercise
{
    public partial class Leecodes
    {
        public partial class arrayProblem
        {
            public void MoveZeroes(int[] nums)// O(N) time O(1) space
            {// fixed left pointer for non zero.
             // Movable right pointer for skip zero's and move forward.
                nums = [0, 1];
                if (nums.Length < 2) return;

                int left = 0;
                int right = 0;

                while (right < nums.Length)
                {
                    if (nums[right] != 0)
                    {
                        int temp = nums[left];
                        nums[left] = nums[right];
                        nums[right] = temp;
                        left++;
                    }
                    right++;
                }
            }
            public void MoveZeroes1(int[] nums)
            {// move read, scan, swap no.
                var writePointer = 0;
                for (var readPointer = 0; readPointer < nums.Length; readPointer++)
                {
                    if (nums[readPointer] != 0)
                    {
                        (nums[writePointer], nums[readPointer]) = (nums[readPointer], nums[writePointer]);
                        writePointer++;
                    }
                }
            }
            public void MoveZeroes2(int[] nums) // best case (time)
            { // Two co-pointers 
                int i = 0, j = i + 1;
                while (j < nums.Length)
                {
                    if (nums[i] != 0)
                    {
                        i++;
                        j++;
                    }
                    else
                    {
                        if (nums[j] == 0)
                            j++;
                        else
                        {
                            nums[i] = nums[j];
                            nums[j] = 0;
                            i++;
                            j++;
                        }
                    }
                }
            }
            public void MoveZeroes3(int[] input) // worst case (time)
            {
                if (input.Length == 1) return;

                var pointer = 0;
                var zerosFound = 0;
                while (pointer < input.Length - zerosFound)
                {
                    if (input[pointer] != 0)
                    {
                        pointer++;
                        continue;
                    }

                    zerosFound++;

                    for (var j = pointer; j < input.Length - zerosFound; j++)
                    {
                        (input[j], input[j + 1]) = (input[j + 1], input[j]);
                    }
                }
            }
            public void MoveZeroes4(int[] num) // best case (space) O(log^2) (time)
            {
                for (int i = 1; i < num.Length; i++)
                {
                    for (int j = 0; j < i; j++)
                    {
                        if (num[j] == 0)
                        {
                            int a = num[j];
                            num[j] = num[i];
                            num[i] = a;
                        }
                    }

                }
            }
            public void MoveZeroes5(int[] nums) //worst case (space)
            {
                int slow = 0;

                for (int fast = 0; fast < nums.Length; fast++)
                {
                    if (nums[fast] != 0)
                    {
                        int tmp = nums[slow];
                        nums[slow] = nums[fast];
                        nums[fast] = tmp;
                        slow++;
                    }


                }
            }
            public void MoveZeroes6(int[] nums) // time: 32.09m
            {

                /*
                 about this problem:-
                     move all zero to right with maintaining the relative order.
                     in-memory operation only

                  my approach:-
                     attempt 1:-
                        Two pointer pattern
                         p_pointer for position the non-zero element
                         c_pointer for scan and track array length.

                     if c_pointer found zero value element, value swapped and one place pointer move forward both.
                     if p_pointer found zero value element, if will not moved
                */
                if (nums.Length == 1) return;

                int p_pointer = 0, c_pointer = 1; //[0,1,0,3,12] 1 0 0 3 12

                while (c_pointer < nums.Length)
                {

                    if (nums[c_pointer] == 0 && nums[p_pointer] != 0)
                    {

                        nums[c_pointer] = nums[p_pointer];
                        nums[p_pointer] = 0;
                        p_pointer++;
                    }
                    c_pointer++;
                }

            }
        }
    }
}