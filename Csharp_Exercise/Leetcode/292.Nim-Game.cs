namespace Csharp_Exercise
{
    public partial class Leecodes
    {
        public bool CanWinNim(int n) // time ( O(1) ) — single arithmetic check. space ( O(1) ) — no extra space.
        {
            /*
             Let assume Two player play truly.
              Key idea : If i play first, I always try to keep maintain 4+ stone for my friend. bcz if less then 4 stone he can pick all stone and win this game.
    My friend also use this same idea to stop me.

             A is me and B is my Friend.
              Case 1 : n=8 
                   A->3 , B->1 (he also know the idea), A->2 ,B->2(win)
              Case 2 : n=9
                   A->3, B->2, A->1, B->3, A->1 (win) 

        Here the proccess are round the no. 4 , if it 4 multiper the , if my friend plays correctly we win the match and other wise I will win the match.
            */
            return n % 4 != 0;
        }
        public bool CanWinNim1(int n)
        {
            int turn = 1;
            while (n > 3)
            {
                if (turn == 1)
                {
                    n = n - 1;
                    turn = 2;
                }
                else
                {
                    n = n - 3;
                    turn = 1;
                }
            }
            if (n <= 3)
            {
                if (turn == 2)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }

            return true;


        }
    }
}
