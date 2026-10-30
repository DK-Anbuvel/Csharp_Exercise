using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Csharp_Exercise
{
    public partial class Leecodes
    {
        public partial class GreedyProblem
        {
            public int MinInsertions(string s)
            {

                /*
                 about this problem:-
                    Here need to balance parentheses and return no. insert required to make this balance.

                 My approach:-

                    brute focus approach:-
                      s String consists only '(' and ')'
                      no. open parenthese = ( 2 * no. open parenthese)
                      so count both open and close parenthese
                      return (2* no. open parenthesis - no. close parenthesis )

                      ASCII value
                       '(' = 40 
                       ')' = 41
                      Failed = "))())
                " */
                (int l, int r) = (0, 0);
                foreach (char c in s)
                {
                    if (c == '(')
                        l++;
                    else
                        r++;
                }

                return (2 * l) - r;

            }
            public int MinInsertions1(string s)
            {
                /*
                  Here no need to count separate open and close count, so used overall 
                  need insertions count.
                */
                int insertions = 0;
                int need = 0;
                foreach (char c in s)// (
                {
                    if (c == '(')
                    {
                        // Complete a pending single ')' if needed
                        if (need % 2 == 1)
                        {
                            insertions++;
                            need--;
                        }
                        // Every '(' requires two ')'
                        need += 2;
                    }
                    else
                    {
                        need--;
                        // No opening '(' available for this ')'
                        if (need < 0)
                        {
                            insertions++;
                            need = 1;
                        }
                    }
                }
                // Add all missing closing parentheses
                return insertions + need;
            }
        }
    }
}
