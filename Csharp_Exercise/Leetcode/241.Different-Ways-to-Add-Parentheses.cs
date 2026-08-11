namespace Csharp_Exercise
{
    public partial class Leecodes
    {
        public IList<int> DiffWaysToCompute(string expression)
        {

            /*
             About this Problem:-
                Given expression string contains both no.s and operators
                need to find the all possible result by using given no.s with operator

                Constraints:-
                    operator not start in starting of the expression.
                    result no.  < 10^4 (10,000)
                    no sequence of operators(++)
                    operator starting and ending of the expression (+2)(2*)
                    No need to change the positions of expression.

              My Approach:-

                 attempt 1:-
                     Questions:- "2*3-4*5"
                          How to find all possible way from the expression ?



            */
            return new List<int>(-1);
        }
        public IList<int> DiffWaysToCompute1(string expression) // time O(2^N x N)  space O(2^N x N)  
        {
            List<int> result = new();// recursively split expression at operators to compute all possible results.
            for (int i = 0; i < expression.Length; i++)
            {
                // skip No.
                if (expression[i] != '*' && expression[i] != '+' && expression[i] != '-')
                    continue;

                char opt = expression[i];
                // split left by operator
                IList<int> LeftPart = DiffWaysToCompute(expression.Substring(0, i));
                // split right
                IList<int> RightPart = DiffWaysToCompute(expression.Substring(i + 1));

                // calculate each leftpart to each rightpart
                foreach (int k in LeftPart)
                {

                    foreach (int j in RightPart)
                    {

                        int value = opt switch
                        {
                            '+' => k + j,
                            '-' => k - j,
                            '*' => k * j,
                            _ => 0
                        };
                        result.Add(value);
                    }
                }
            }
            // No operator = number
            if (result.Count == 0)
                result.Add(int.Parse(expression));

            return result;
        }
        public Dictionary<string, List<int>> memos = new Dictionary<string, List<int>>();

        public IList<int> DiffWaysToCompute2(string expression)
        {

            var list = new List<int>();

            if (string.IsNullOrEmpty(expression))
            {
                return list;
            }

            if (expression.Length <= 2)
            {
                list.Add(int.Parse(expression));
                return list;
            }

            if (memos.ContainsKey(expression))
            {
                return memos[expression];
            }


            for (var i = 0; i < expression.Length; i++)
            {

                if (Char.IsDigit(expression[i]))
                {
                    continue;
                }

                var left = DiffWaysToCompute2(expression.Substring(0, i));
                var right = DiffWaysToCompute2(expression.Substring(i + 1, expression.Length - i - 1));

                foreach (var l in left)
                {
                    foreach (var r in right)
                    {
                        if (expression[i] == '+')
                        {
                            list.Add(l + r);
                        }
                        else if (expression[i] == '-')
                        {
                            list.Add(l - r);
                        }
                        else
                        {
                            list.Add(l * r);
                        }
                    }
                }
            }

            memos[expression] = list;
            return list;
        }
        public IList<int> DiffWaysToCompute3(string expression)
        {

            var list = new List<int>();

            if (string.IsNullOrEmpty(expression))
            {
                return list;
            }

            if (expression.Length <= 2)
            {
                list.Add(int.Parse(expression));
                return list;
            }



            for (var i = 0; i < expression.Length; i++)
            {

                if (Char.IsDigit(expression[i]))
                {
                    continue;
                }

                var left = DiffWaysToCompute3(expression.Substring(0, i));
                var right = DiffWaysToCompute3(expression.Substring(i + 1, expression.Length - i - 1));

                foreach (var l in left)
                {
                    foreach (var r in right)
                    {
                        if (expression[i] == '+')
                        {
                            list.Add(l + r);
                        }
                        else if (expression[i] == '-')
                        {
                            list.Add(l - r);
                        }
                        else
                        {
                            list.Add(l * r);
                        }
                    }
                }
            }

            return list;
        }
        int compute(int num1, int num2, string op)
        {
            switch (op)
            {
                case "*":
                    return num1 * num2;
                case "-":
                    return num1 - num2;
                default:
                    return num1 + num2;
            }

        }
        public IList<int> DiffWaysToCompute4(string expression)
        {
            char[] charSeparators = new char[] { '*', '+', '-' };
            List<int> nums;
            // Split the string and return all elements
            nums = expression.Split(charSeparators, StringSplitOptions.None).Select(num => int.Parse(num)).ToList();

            List<string> ops = expression
            .Where(ch => charSeparators.Contains(ch))
            .Select(ch => ch.ToString())
            .ToList();

            List<int>[,] dp = new List<int>[nums.Count, nums.Count];
            for (int g = 0; g < nums.Count; g++)
            {
                for (int i = 0, j = g; j < nums.Count; i++, j++)
                {
                    dp[i, j] = new List<int>();
                    if (g == 0) dp[i, j].Add(nums[j]);
                    else if (g == 1)
                    {
                        int ans = compute(dp[i, j - 1][0], dp[i + 1, j][0], ops[j - 1]);
                        dp[i, j].Add(ans);
                    }
                    else
                    {

                        for (int k = i; k < j; k++)
                        {
                            foreach (var val_i in dp[i, k])
                            {
                                foreach (var val_j in dp[k + 1, j])
                                {
                                    int ans = compute(val_i, val_j, ops[k]);
                                    dp[i, j].Add(ans);
                                }
                            }
                        }
                    }
                }
            }

            return dp[0, dp.GetLength(1) - 1];
        }
    }
}
