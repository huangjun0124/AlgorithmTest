using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{
    class Island_Perimeter
    {
        public static int IslandPerimeter(int[,] grid)
        {
            int ret = 0, i = 0;
            for (; i < grid.GetLength(0); i++)
            {
                int j = 0;
                for (; j < grid.GetLength(1); j++)
                {
                    if (j == 0)
                    {
                        if (grid[i, j] == 1) ret++;
                    }
                    else
                    {
                        if (grid[i, j - 1] != grid[i, j])
                            ret++;
                    }
                    if (i == 0)
                    {
                        if (grid[i, j] == 1) ret++;
                    }
                    else
                    {
                        if (grid[i - 1, j] != grid[i, j])
                            ret++;
                    }
                }
                if (grid[i, j - 1] == 1) ret++;
            }
            i--;
            for (int j = 0; j < grid.GetLength(1); j++)
            {
                if (grid[i, j] == 1) ret++;
            }
            return ret;
        }

        public int Solution2(int[][] grid)
        {
            int m = grid.Length, n = grid[0].Length;
            int count = 0;
            int[,] dir = { { 0, 1 }, { 1, 0 }, { -1, 0 }, { 0, -1 } };
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (grid[i][j] == 1)
                    {
                        for (int k = 0; k < 2; k++)
                        {
                            int x = i + dir[k,0], y = j + dir[k, 1];
                            if (x < 0 || y < 0 || x == m || y == n || grid[x][y] == 0)
                            {
                                count++;
                            }
                        }
                    }
                }
            }
            return count;
        }

        public int Solution3(int[,] grid)
        {
            int islands = 0, neighbours = 0;
            for (int i = 0; i < grid.GetLength(0); i++)
            {
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    if (grid[i,j] == 1)
                    {
                        islands++; // count islands
                        if (i < grid.GetLength(0) - 1 && grid[i + 1,j] == 1) neighbours++; // count down neighbours
                        if (j < grid.GetLength(1) - 1 && grid[i,j + 1] == 1) neighbours++; // count right neighbours
                    }
                }
            }
            return islands * 4 - neighbours * 2;
        }
    }
}
