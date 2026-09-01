namespace Csharp_Exercise
{
    public partial class Leecodes
    {
        public int[][] MatrixReshape(int[][] mat, int r, int c) // 0ms
        {
            /* About this problem :-
                     Here 2d array given neet to relocate the value in required way(r,c)

               Approach:-

                  first eadge case like r * c != mat.length * mat[i].Length

                  Need to get each mat[][] element --N^2
                  store each element in list
                  Need to set each element in result[][] -- N^2
            */

            int inp_Column = mat[0].Length;
            int inp_Row = mat.Length;

            if ((inp_Column * inp_Row) != (r * c)) return mat;

            int[][] out_Array = new int[r][]; // arrary of array
            int out_Column = 0, out_Row = 0;

            for (int i = 0; i < r; i++)
            {
                out_Array[i] = new int[c];
            }

            for (int i = 0; i < inp_Row; i++)
            {
                for (int j = 0; j < inp_Column; j++)
                {
                    out_Array[out_Row][out_Column] = mat[i][j];
                    out_Column++;

                    if (out_Column == c)
                    {
                        out_Column = 0;
                        out_Row++;
                    }

                }
            }
            return out_Array;

        }
        public int[][] MatrixReshape1(int[][] mat, int r, int c)
        {
            int m = mat.Length;
            int n = mat[0].Length;
            if (m * n != r * c || m == r && n == c) return mat; //   m == r && n == c
            int[][] res = new int[r][];
            for (int i = 0; i < r; i++)
            {
                res[i] = new int[c];
            }

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < mat[i].Length; j++)
                {
                    int count = i * mat[i].Length + j;
                    int k = count / c;
                    int l = count % c;
                    res[k][l] = mat[i][j];
                }
            }
            return res;
        }
        public int[][] MatrixReshape2(int[][] mat, int r, int c)
        {

            int[][] matrix = new int[r][];

            for (int i = 0; i < r; i++)
            {
                matrix[i] = new int[c];
            }

            int m = mat.Length;
            int n = mat[0].Length;

            int count = 0;

            if (m * n == r * c)
            {
                for (int i = 0; i < m; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        int NewRow = count / c; /// math
                        int NewCol = count % c;
                        matrix[NewRow][NewCol] = mat[i][j];

                        count++;
                    }
                }

                return matrix;
            }
            else
            {
                return mat;
            }
        }
        public int[][] MatrixReshape3(int[][] mat, int r, int c)
        {
            int m = mat.Length, n = mat[0].Length;
            if (m * n != r * c)
                return mat;
            int[][] final = new int[r][];
            for (int i = 0; i < r; i++)
            {
                final[i] = new int[c];
            }
            int total = m * n;
            for (int i = 0; i < total; i++)
            {
                final[i / c][i % c] = mat[i / n][i % n];
            }
            return final;
        }
    }
}
