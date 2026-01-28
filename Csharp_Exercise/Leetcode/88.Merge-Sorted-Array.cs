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
        public void Merge1(int[] nums1, int m, int[] nums2, int n)
        {
            // Here we can use two-pointer for left(num1) and right(num2)
            // merge and sort  or sort via new arrary and store to nums1.
            // here constraints nums1.length == m + n , so
            // nums1 have space to store nums2 values by using copyto method

            int left = 0;
            int right = nums1.Length-1;
            nums2.CopyTo(nums1, m); // 
            while (left <= right)
            {

                int temp = nums1[left];
                if (nums1[left] > nums1[right])
                {
                    nums1[left] = nums1[right];
                    nums1[right] = temp;
                    right--;
                }
                else
                {
                    right--;
                    left++;
                }
               
            }
            m = nums1.Length;
        }
        public void Merge(int[] nums1, int m, int[] nums2, int n)
        {
            int i = m - 1;
            int j = n - 1;
            int k = m + n - 1;

            while (j >= 0)
            {
                if (i >= 0 && nums1[i] > nums2[j])
                    nums1[k--] = nums1[i--];
                else
                    nums1[k--] = nums2[j--];
            }
        }


    }
}
