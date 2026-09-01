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
        public void Merge1(int[] nums1, int m, int[] nums2, int n) // it sort half only.
        {
            // Here we can use two-pointer for left(num1) and right(num2)
            // merge and sort  or sort via new arrary and store to nums1.
            // here constraints nums1.length == m + n , so
            // nums1 have space to store nums2 values by using copyto method

            int left = 0;
            int right = nums1.Length - 1;
            nums2.CopyTo(nums1, m); // 
            while (left <= right) // mistake it already in ascending order. no need to compare each element to others.
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
        public void Merge2(int[] nums1, int m, int[] nums2, int n)// easy way.
        {
            if (n == 0) return;
            int len1 = nums1.Length;
            int end_idx = len1 - 1;
            while (n > 0 && m > 0)
            {
                if (nums2[n - 1] >= nums1[m - 1])
                {
                    nums1[end_idx] = nums2[n - 1];
                    n--;
                }
                else
                {
                    nums1[end_idx] = nums1[m - 1];
                    m--;
                }
                end_idx--;
            }
            while (n > 0)
            {
                nums1[end_idx] = nums2[n - 1];
                n--;
                end_idx--;
            }
        }
        public void Merge3(int[] nums1, int m, int[] nums2, int n)// Two Pointer 0(m+n), 0(1)
        {
            if (n == 0) return;
            int NM_len = nums1.Length - 1;

            while(n>0 && m > 0) // iterate 
            {
                if (nums2[n - 1] >= nums1[m - 1]) // if num2 element >= num1 then set value in num2 last.
                {
                    nums1[NM_len]=nums2[n - 1];
                    n--;
                }
                else // if num2 element < num1 then set value in num1 last.
                {
                    nums1[NM_len] = nums1[m - 1];
                    m--;
                }
                NM_len--; // index move inwards.
            }
            while (n > 0) // set all element in begining. 
            {
                nums1[NM_len] = nums2[n - 1];
                n--;
                NM_len--;
            }


        }
        public void Merge4(int[] nums1, int m, int[] nums2, int n)
        {
            for (int i = 0; i < n; i++)
            {
                nums1[m + i] = nums2[i];
            }
            Array.Sort(nums1);
        }
        public void Merge5(int[] nums1, int m, int[] nums2, int n) // Best case (space)
        {
            int p1 = m - 1;
            int p2 = n - 1;

            for (int i = (m + n) - 1; i >= 0; i--)
            {
                if (p2 < 0) return;
                if (p1 >= 0)
                {
                    if (nums1[p1] >= nums2[p2])
                    {
                        nums1[i] = nums1[p1];
                        p1--;
                    }
                    else if (nums2[p2] > nums1[p1])
                    {
                        nums1[i] = nums2[p2];
                        p2--;
                    }
                }
                else
                {
                    nums1[i] = nums2[p2];
                    p2--;
                }
            }
        }
    }
}
