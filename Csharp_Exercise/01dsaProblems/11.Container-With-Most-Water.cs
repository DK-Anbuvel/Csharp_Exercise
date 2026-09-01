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
        /*
        You are given an integer array height of length n. There are n vertical lines
        drawn such that the two endpoints of the ith line are (i, 0) and (i, height[i]).
        Find two lines that together with the x-axis form a container, such that the 
        container contains the most water.
        Return the maximum amount of water a container can store.
        Notice that you may not slant the container.
         */
        public int MaxArea(int[] height) // traditional way to compare the area to max area.  O(N^2) Time Limit Exceeded Exception
        {
            /*
             * it act just like rectangle container, need to find maximum area of this.
             * Area of the Rectangle = Length * Height
             * MaxArea = ( Length[j].index - Length[i].index ) * height[j]
             */
           // height = [1, 1];
            int MaxArea = 0;
            for (int i = 1; i <= height.Length; i++)
            {
                for(int j = i+1;j <= height.Length; j++)
                {
                    int tempArea = (j - i) * (Math.Min(height[j - 1], height[i-1])); // 
                    if (tempArea > MaxArea)
                    {
                        //set height and max 
                        MaxArea = tempArea;
                    }

                }

            }

            return MaxArea;
        }

        public int MaxArea1(int[] height) // Two Pointers pattern o(n)
        {
            /*
             *  set two pointer (left) and (right)
             *  if after calculate area then compare two pointer height and adjust the pointer with minimum height
             *  pointer inward.
             */
            int result = 0;
            int left = 0;
            int right = height.Length -1;
            while (left < right){

                int temp = (right - left) * (Math.Min(height[right], height[left]));
                if (result < temp)
                {
                    result = temp;
                }

                if (height[left] > height[right]) // minimized the size
                    right--;
                else
                    left++;
            }

            return result;
        }
        public int MaxArea2(int[] height) // best case (time) O(log n)
        {
            int l = 0;
            int r = height.Length - 1;
            int res = 0;
            while (l < r && res < (r - l) * 10000)
            {
                res =  Math.Max( res,
                                 height[l] > height[r]
                               ? height[r] * (r - l)  // y (height)  * x (to get exact container  r - 1)
                               : height[l] * (r - l));

                if (height[l] > height[r]) r--;
                else l++;
            }
            return res;
        }

        public int MaxArea3(int[] height) // best case (space)
        {
            /*
               This is also like  traditional 2 loop pattern, but here to minimized the loop run time.
             */
            var right = new int[height.Length];

            right[height.Length - 1] = height[height.Length - 1];

            for (var i = height.Length - 2; i >= 0; i--)
            {
                right[i] = Math.Max(height[i], right[i + 1]);
            }

            var maxArea = 0;
            var maxLeft = 0; 
            for (var i = 0; i < height.Length; i++)
            {
                if (maxLeft >= right[i]) // if 
                {
                    break;
                }
                if (height[i] <= maxLeft)
                {
                    continue;
                }
                maxLeft = height[i];
                var maxRight = 0;
                for (var j = height.Length - 1; j > i; j--)
                {
                    if (height[j] <= maxRight)
                    {
                        continue;
                    }
                    maxArea = Math.Max(maxArea, (j - i) * Math.Min(height[i], height[j]));
                }
            }

            return maxArea;
        }
    }
}
