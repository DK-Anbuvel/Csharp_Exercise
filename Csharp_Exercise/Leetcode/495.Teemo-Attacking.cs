namespace Csharp_Exercise
{
    public partial class Leecodes
    {
        public int FindPoisonedDuration(int[] timeSeries, int duration) // runtime 1ms
        {
            /*
              About this probelm:-
                   here need to find the count for the
                   timeseries[n] + duration count 
                   if timeseries[n] + d is interspect the timeseries[n+1] then duration loop restart.

             My Approach:-
                   build a burce force base logic
                   [1,2,6,8],2 count 7

                 Attempt 1 // failed due to insead of count times they store
                   single For Loop(positioning the index)  
                   the sum in res.

                   loop n
                   if((n+1 - n)  <= d) then res +=(n+1 - n) ;
                   else res +=2;  

                 Attempt 2
                     single For Loop(positioning the index)  
                     the sum in res.
                     alter to count

                time : O(1)
                space : O(1)
            */

            int res = 0;
            for (int i = 0; i + 1 < timeSeries.Length; i++)
            {

                if ((timeSeries[i + 1] - timeSeries[i]) < duration) res += (timeSeries[i + 1] - timeSeries[i]);
                else res += duration;
            }
            res += duration;
            return res;
        }
        public int FindPoisonedDuration1(int[] timeSeries, int duration)
        {
            var total = duration;

            for (int i = 1; i < timeSeries.Length; i++)
                total += Math.Min(duration, timeSeries[i] - timeSeries[i - 1]);

            return total;
        }
        public int FindPoisonedDuration2(int[] timeSeries, int duration)
        {
            return timeSeries.Select((x, i) => i > 0 
                             ? Math.Min(duration, timeSeries[i] - timeSeries[i - 1]) 
                             : duration).Aggregate((x, y) => x + y);
        }
        public int FindPoisonedDuration3(int[] timeSeries, int duration)
        {
            int t_size = timeSeries.Length, curr_time = 0, poisoned = 0;

            for (int i = 0; i < t_size; i++)
            {
                poisoned = poisoned + timeSeries[i] + duration - Math.Max(curr_time, timeSeries[i]);
                curr_time = timeSeries[i] + duration;
            }

            return poisoned;
        }
    }
}
