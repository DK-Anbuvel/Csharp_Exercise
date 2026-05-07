namespace Csharp_Exercise
{
    public partial class Leecodes
    {
        public int IslandPerimeter(int[][] grid) // runtime 5 ms
        {

            /*
              About this problem ;-
                      first of all this problem looks pretty,Here 2d array given like paddy field 
                need to find the sum the parameter field except shared edges.

             My Approach :-
                      while brute force this problem, two condition will suitable avoid the margining sides.
                      
                    * first, add the 4 sides then by using this condition subtract sides.
                    * square-top : grid[i][j] + grid[i-1][j] ==2 then total parameter =-2
                    * square-left-sides : grid[i][j] + grid[i][j-1] ==2 then total parameter =-2
                    
                     Nested ForLoop 
                     time : O(row* col)
                     space : O(1)
             */

            int parameter = 0;
             
            for(int i=0; i < grid.Length; i++)
            {
                for(int j=0; j < grid[i].Length; j++)
                {
                    if (grid[i][j] == 1) // first check is it land or not
                    {
                        parameter += 4;
                        if (j > 0) // square-left-sides
                        {
                            if (grid[i][j] + grid[i][j-1] == 2) parameter -= 2;
                        }
                        if (i > 0) // square-top 
                        {
                            if (grid[i][j] + grid[i-1][j] == 2) parameter -= 2;
                        }
                    }
                }
            }
            return parameter;
        }
        public int IslandPerimeter1(int[][] grid)
        {
            int gsize = grid.Length, lsize = grid[0].Length, res = 0;
            Span<(int f, int s)> ind = stackalloc (int, int)[4];

            for (int i = 0; i < gsize; i++)
            {
                for (int y = 0; y < lsize; y++)
                {
                    if (grid[i][y] == 1)
                    {
                        ind[0] = (i - 1, y);
                        ind[1] = (i, y - 1);
                        ind[2] = (i + 1, y);
                        ind[3] = (i, y + 1);

                        for (int j = 0; j < 4; j++)
                        {
                            // ind[j].f = Math.Max(Math.Min(ind[j].f, size-1),0);
                            // ind[j].s = Math.Max(Math.Min(ind[j].s, size-1),0);

                            if (ind[j].f == -1 || ind[j].f == gsize || ind[j].s == -1 || ind[j].s == lsize)
                            {
                                res++;
                            }
                            else if (grid[ind[j].f][ind[j].s] != 1)
                            {
                                res++;
                            }

                        }
                    }
                }
            }
            return res;
        }
        public int IslandPerimeter2(int[][] grid)
        {

            int peri = 0;

            for (int r = 0; r < grid.Length; r++)
            {
                int c = 0;
                while (c < grid[r].Length)
                {
                    int cell = grid[r][c];

                    if (cell == 1)
                    {
                        int s = 4;
                        if ((r - 1 >= 0 && grid[r - 1][c] == 1))
                        {
                            s--;
                        }
                        if ((r + 1 < grid.Length && grid[r + 1][c] == 1))
                        {
                            s--;
                        }
                        if (((c + 1) < grid[r].Length && grid[r][c + 1] == 1))
                        {
                            s--;
                        }
                        if (((c - 1) >= 0 && grid[r][c - 1] == 1))
                        {
                            s--;
                        }
                        peri = peri + s;
                    }
                    c++;
                }

            }
            return peri;
        }

        private int islandPerimeter = 0;
        public int IslandPerimeter3(int[][] grid)
        {
            int rows = grid.Length;
            int cols = grid[0].Length;

            for (int rowIdx = 0; rowIdx < rows; rowIdx++)
            {
                for (int colIdx = 0; colIdx < cols; colIdx++)
                {
                    if (grid[rowIdx][colIdx] == 1)
                    {
                        DFS(grid, rows, cols, rowIdx, colIdx);
                        break;
                    }
                }
            }

            return islandPerimeter;
        }

        public void DFS(int[][] grid, int rows, int cols, int rowIdx, int colIdx)
        {
            if (rowIdx < 0 || rowIdx >= rows || colIdx < 0 || colIdx >= cols || grid[rowIdx][colIdx] == 0 || grid[rowIdx][colIdx] == 2)
            {
                return;
            }

            // Mark this cell as visited
            grid[rowIdx][colIdx] = 2;

            if (rowIdx - 1 < 0 || grid[rowIdx - 1][colIdx] == 0)
            {
                islandPerimeter++;
            }

            if (rowIdx + 1 >= rows || grid[rowIdx + 1][colIdx] == 0)
            {
                islandPerimeter++;
            }

            if (colIdx - 1 < 0 || grid[rowIdx][colIdx - 1] == 0)
            {
                islandPerimeter++;
            }

            if (colIdx + 1 >= cols || grid[rowIdx][colIdx + 1] == 0)
            {
                islandPerimeter++;
            }

            DFS(grid, rows, cols, rowIdx - 1, colIdx);
            DFS(grid, rows, cols, rowIdx + 1, colIdx);
            DFS(grid, rows, cols, rowIdx, colIdx - 1);
            DFS(grid, rows, cols, rowIdx, colIdx + 1);
        }
        public int IslandPerimeter4(int[][] grid)
        {
            HashSet<(int, int)> visited = new HashSet<(int, int)>();
            int rows = grid.Length;
            int columns = grid[0].Length;

            //Find the first land
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if (grid[i][j] == 1)
                        return DFS(i, j);
                }
            }
            return 0;

            int DFS(int row, int column)
            {
                if (row < 0 || column < 0 || row >= rows || column >= columns || grid[row][column] == 0)
                    return 1; //Get to the edge
                if (visited.Contains((row, column)))
                    return 0; //Already visited
                visited.Add((row, column));
                //Otherwise iterate the land
                int edgeCount = 0;
                edgeCount = DFS(row - 1, column);
                edgeCount += DFS(row, column - 1);
                edgeCount += DFS(row + 1, column);
                edgeCount += DFS(row, column + 1);
                return edgeCount;
            }
        }
        public int IslandPerimeter5(int[][] grid)
        {
            int n = grid.Length, m = grid[0].Length;
            int ans = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (grid[i][j] == 1)
                    {
                        // check 4 dirs
                        int p = 0;
                        if (i == 0 || grid[i - 1][j] == 0) p++;
                        if (j == 0 || grid[i][j - 1] == 0) p++;
                        if (i == n - 1 || grid[i + 1][j] == 0) p++;
                        if (j == m - 1 || grid[i][j + 1] == 0) p++;
                        ans += p;
                    }
                }
            }
            return ans;
        }
    }
}
