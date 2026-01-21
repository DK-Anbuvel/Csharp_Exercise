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
        public int MaxArea(int[] height)
        {
            /*
             * it act just like rectangle container, need to find maximum area of this.
             * Area of the Rectangle = Length * Height
             * MaxArea = ( Length[j].index - Length[i].index ) * height[j]
             */

            // traditional way to compare the area to max area.  O(N^2) Time Limit Exceeded Exception
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
    }
}
