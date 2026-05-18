using static System.Formats.Asn1.AsnWriter;

namespace Csharp_Exercise
{
    public partial class Leecodes
    {
        public string[] FindRelativeRanks(int[] score)
        {

            /*
              about this problem :-
                   Here given the unSorted unique arary, I find the first 3 hight place and replace the Medals 
                   instead of score, in the same unSorted array.

              Approach :-
                    Attempted 1 :- failed due to understanding gap, The placements are [1st, 5th, 3rd, 2nd, 4th].
                        first the array in temp and store the first 3 
                        then loop the real score and replace the Medals

                    Attempted 2 :- 
                         make sorted array -- O(n)
                         Two nested loop for find and store the each array element. -- O(n^2)
            */
            string[] result = new string[score.Length];
            int[] temp = new int[score.Length];
            Array.Copy(score, temp, score.Length);
            Array.Sort(score);
            int first = -1, second = -1, third = -1;

            if (score.Length > 1)
                first = score[score.Length - 1];
            if (score.Length > 2)
                second = score[score.Length - 2];
            if (score.Length > 3)
                third = score[score.Length - 3];

            for (int i = 0; i < temp.Length; i++)
            {
                if (temp[i] == first)
                    result[i] = "Gold Medal";
                else if (temp[i] == second)
                    result[i] = "Silver Medal";
                else if (temp[i] == third)
                    result[i] = "Bronze Medal";
                else
                    result[i] = temp[i].ToString();
            }

            return result;
        }
        public string[] FindRelativeRanks1(int[] score) // 34ms time O(n^2) space O(n)
        {
            string[] result = new string[score.Length];
            int[] sortedScore = score.OrderByDescending(x => x).ToArray();

            for (int i = 0; i < score.Length; i++)
            {
                if (score[i] == sortedScore[i] && i > 3)
                    result[i] = (i + 1).ToString();
                else
                {
                    for (int j = 0; j < score.Length; j++)
                    {
                        if (score[i] == sortedScore[j] && j < 3)  // to reduce the each time condition check
                        {
                            if (j == 0)
                                result[i] = "Gold Medal";
                            else if (j == 1)
                                result[i] = "Silver Medal";
                            else if (j == 2)
                                result[i] = "Bronze Medal";

                            break;
                        }
                        else if (score[i] == sortedScore[j])
                        {
                            result[i] = (j + 1).ToString();
                            break;
                        }
                    }
                }
            }
            return result;
        }
        public string[] FindRelativeRanks2(int[] score)
        {
            var ordered = new int[score.Length];

            for (int i = 0; i < score.Length; i++)
            {
                ordered[i] = i;
            }

            Array.Sort(ordered, (a, b) => score[b].CompareTo(score[a]));
            var result = new string[score.Length];

            for (int i = 0; i < ordered.Length; i++)
            {
                switch (i)
                {
                    case 0:
                        result[ordered[i]] = "Gold Medal";
                        break;
                    case 1:
                        result[ordered[i]] = "Silver Medal";
                        break;
                    case 2:
                        result[ordered[i]] = "Bronze Medal";
                        break;
                    default:
                        result[ordered[i]] = (i + 1).ToString();
                        break;
                }
            }

            return result;
        }

        public String[] FindRelativeRanks3(Int32[] score)
        {
            String[] result = new String[score.Length];

            Span<Int32> sorted = stackalloc Int32[score.Length];
            score.CopyTo(sorted);
            sorted.Sort(/*(a, b) => b.CompareTo(a)*/);

            for (Int32 i = 0; i < score.Length; i++)
            {
                Int32 index = sorted.BinarySearch(score[i]);
                index = score.Length - 1 - index;
                result[i] = index switch
                {
                    0 => "Gold Medal",
                    1 => "Silver Medal",
                    2 => "Bronze Medal",
                    _ => (index + 1).ToString()
                };
            }

            return result;
        }
        public string[] FindRelativeRanks4(int[] score)
        {
            string[] a = ["Gold Medal", "Silver Medal", "Bronze Medal"];

            PriorityQueue<int, int> pq = new();
            foreach (var s in score)
            {
                pq.Enqueue(s, -s);
            }

            int i = 0;
            Dictionary<int, string> d = new();
            while (pq.Count > 0)
            {
                var item = pq.Dequeue();
                d[item] = i < 3 ? a[i] : $"{i + 1}";
                i++;
            }

            string[] o = new string[score.Length];

            for (int j = 0; j < score.Length; j++)
            {
                o[j] = d[score[j]];
            }

            return o;
        }
        public string[] FindRelativeRanks5(int[] score)
        {
            int[] map = new int[1_000_000 + 1];
            Array.Fill(map, -1);
            int rank = 1;
            for (int i = 0; i < score.Length; i++)
            {
                map[score[i]] = i;
            }

            string[] result = new string[score.Length];
            for (int i = 1_000_000; i >= 0; i--)
            {
                if (map[i] != -1)
                {
                    result[map[i]] = getRank(rank);
                    rank++;
                }
            }

            return result;
        }

        public string getRank(int i)
        {
            switch (i)
            {
                case 1:
                    return "Gold Medal";
                case 2:
                    return "Silver Medal";
                case 3:
                    return "Bronze Medal";
                default:
                    return i.ToString();
            }
        }
    }
}
