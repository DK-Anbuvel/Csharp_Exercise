using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp_Exercise
{
    public  partial class Leecodes
    {
        public string Convert0(string s, int numRows)
        {
            if(numRows ==1) return s;

            List<List<char>>zigzagList = new List<List<char>>(); // store in dynamic D list
            int dir = -1; // minus(-) up way and plus (+) down way
            int currentRow = 0;
            string res = string.Empty;

            for (int i = 0; i < numRows; i++) zigzagList.Add(new List<char>());

            foreach(char c in s)
            {
                zigzagList[currentRow].Add(c);

                if (currentRow == 0 || currentRow == numRows - 1) dir = -dir; 

                currentRow += dir;
            }

            for (int i = 0; i < zigzagList.Count; i++)
            {
                for (int j = 0; j < zigzagList[i].Count; j++) 
                {
                    res += zigzagList[i][j];
                }

            }
            return res;
        }
        public string Convert2(string s, int numRows)  // best case (time)
        {
            if (numRows == 1)
            {
                return s;
            }

            Span<char> result = stackalloc char[s.Length]; //stack-based type that represents a contiguous region of memory

            var resultIndex = 0;
            var period = numRows * 2 - 2;

            for (int row = 0; row < numRows; row++)
            {
                var increment = 2 * row;

                for (int i = row; i < s.Length; i += increment)
                {
                    result[resultIndex++] = s[i];

                    if (increment != period)
                    {
                        increment = period - increment;
                    }
                }
            }

            return result.ToString();
        }
        public string Convert3(string s, int numRows)  // worst case (time)
        {
            if (numRows == 1) return s;
            List<List<Char>> rows = new List<List<Char>>();
            for (int i = 0; i < numRows; i++)
            {
                rows.Add(new List<Char>());
            }
            Console.Write(rows.Count());
            int index = 0;
            bool isReverse = false;
            foreach (var c in s)
            {
                Console.Write(index);
                rows[index].Add(c);

                if (index == numRows - 1)
                {
                    isReverse = true;
                }
                else if (index == 0)
                {
                    isReverse = false;
                }

                if (isReverse)
                {
                    index--;
                }
                else
                {
                    index++;
                }

            }

            var result = "";
            foreach (var a in rows)
            {
                foreach (var ch in a)
                {
                    result = result + ch;
                }
            }
            return result;
        }

        public string Convert4(string s, int numRows) // best case (memory)
        {
            if (numRows == 1)
                return s;
            int period = 2 * numRows - 2;
            List<char> symbolsArray = s.ToCharArray().ToList();
            string[] lines = new string[numRows];
            for (int i = 0; i < symbolsArray.Count; i++)
            {
                lines[numRows - 1 - Math.Abs((i % period - period / 2))] += symbolsArray[i];
            }
            GC.Collect();
            return String.Concat(lines);
        }
        private void FillArr(char[][] mat, int numRows)
        {
            for (int i = 0; i < mat.Length; i++)
            {
                mat[i] = new char[numRows];
                for (int j = 0; j < numRows; j++)
                {
                    mat[i][j] = ' ';
                }
            }
        }

        /*
        1
        2     8
        3   7 
        4 6
        5

        */
        public string Convert5(string s, int numRows) // worst case (memory)
        {
            if (numRows == 1)
            {
                return s;
            }
            int h = numRows;
            int w = numRows - 1;
            int elemPerSquare = h + w - 1;
            int numOfSquares = (int)(Math.Ceiling(s.Length / (double)elemPerSquare));
            char[][] mat = new char[numOfSquares * w][];
            FillArr(mat, numRows);
            int i = 0;
            for (int ins = 0; ins < numOfSquares; ins++)
            {
                for (int iep = 0; iep < elemPerSquare; iep++)
                {
                    int curH = iep < h ? iep : (h - 1) - (iep - h) - 1;
                    int curW = iep < h ? 0 : iep - h + 1;
                    int finalW = ins * w + curW;
                    if (i >= s.Length)
                        goto breakDoubleForLoop;
                    // Console.WriteLine($"{i} {finalW} {curH}, {iep}");
                    char c = s[i];
                    // Console.WriteLine(c);
                    mat[finalW][curH] = c;
                    i++;
                }
            }
        breakDoubleForLoop:

            // for(int iw = 0; iw < mat.Length; iw++) {
            //     for(int ih = 0; ih < mat[0].Length; ih++) {
            //         Console.Write(mat[iw][ih]);
            //     }
            //     Console.Write('\n');
            // } 

            /*
            [[], [], []]
            [[]  []  []]
            */
            StringBuilder sb = new StringBuilder();
            for (int ih = 0; ih < h; ih++)
            {
                for (int iw = 0; iw < numOfSquares * w; iw++)
                {
                    char c = mat[iw][ih];
                    if (c == ' ')
                        continue;
                    sb.Append(c);
                }
            }
            return sb.ToString();
        }
    }
}
