using System;

namespace Csharp_Exercise
{
    public partial class Leecodes
    {
        public int FindContentChildren(int[] g, int[] s) // runtime 53
        {
            /* time O(NlogN + MlogM)
              
             about this problem :- 
                    they are two arrays, hurry children no. cookies required and no. cookies per plate.
              here our goal is maximum children can feet by using any possible. 
              
             my approach :-
                   
                     Here  cookie plates are not breakable (s[j] >= g[i]) so we can't give excess cookies to 
            other child. 
                     Here first g[i] find the minimum no. in s[i]
                     better we sort the both array in the ascending order.
                     then using two pointers move the forward.
               
             */

            Array.Sort(g);
            Array.Sort(s);

            int result = 0;

            int left = 0;
            int right = 0;

            while(left < g.Length && right < s.Length)
            {
                if (g[left] <= s[right])
                {
                    result++;
                    left++;
                    right++;
                }
                else
                    right++;
            }

            return result;
        }
        public int FindContentChildren1(int[] g, int[] s)
        {
            Array.Sort(g);
            Array.Sort(s);
            int child = 0, cookie = 0;
            while (child < g.Length && cookie < s.Length)
            {
                if (s[cookie] >= g[child])
                {
                    child++;
                    cookie++;
                }
                else
                {
                    cookie++;
                }
            }
            return child;
        }
        public int FindContentChildren2(int[] g, int[] s)
        {
            int c = 0;
            Array.Sort(g, (l, r) => l - r);
            Array.Sort(s, (l, r) => l - r);
            int lenG = g.Length;
            int lenS = s.Length;
            for (int i = 0; c < lenG && i < lenS; i++)
            {
                if (g[c] <= s[i])
                {
                    c++;
                }
            }
            return c;
        }
        public int FindContentChildren3(int[] g, int[] s)
        {
          //  g.Sort();
           // s.Sort();
            int result = 0;
            int sIndex = 0;
            while (g.Length > result && s.Length > sIndex)
            {
                if (g[result] <= s[sIndex]) result++;
                sIndex++;
            }
            return result;
        }
    }
}
