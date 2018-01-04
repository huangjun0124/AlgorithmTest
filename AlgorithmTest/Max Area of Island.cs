using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{
    /*
    Given a non-empty 2D array grid of 0's and 1's, an island is a group of 1's (representing land) connected 4-directionally (horizontal or vertical.) You may assume all four edges of the grid are surrounded by water.

    Find the maximum area of an island in the given 2D array. (If there is no island, the maximum area is 0.)

    Example 1:

[[0,0,1,0,0,0,0,1,0,0,0,0,0],
[0,0,0,0,0,0,0,1,1,1,0,0,0],
[0,1,1,0,1,0,0,0,0,0,0,0,0],
[0,1,0,0,1,1,0,0,1,0,1,0,0],
[0,1,0,0,1,1,0,0,1,1,1,0,0],
[0,0,0,0,0,0,0,0,0,0,1,0,0],
[0,0,0,0,0,0,0,1,1,1,0,0,0],
[0,0,0,0,0,0,0,1,1,0,0,0,0]]

Given the above grid, return 6. Note the answer is not 11, because the island must be connected 4-directionally.

Example 2:

[[0,0,0,0,0,0,0,0]]

Given the above grid, return 0.

Note: The length of each dimension in the given grid does not exceed 50. 
*/
    class Max_Area_of_Island
    {
        private bool[,] Traversed = new bool[50,50];

        public int MaxAreaOfIsland(int[,] grid)
        {
            int max = 0;
            for (int i = 0; i < grid.GetLength(0); i++)
            {
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    Traversed[i, j] = true;
                    if (grid[i, j] == 1)
                    {                   
                        var area = 1;
                        FindConnected(ref area, i, j, grid);
                        max = max > area ? max : area;
                    }
                }
            }
            return max;
        }
               
        private void FindConnected(ref int area,int i, int j, int[,] grid)
        {
            if (i > 0 && !Traversed[i-1,j])
            {
                Traversed[i - 1, j] = true;
                if (grid[i - 1, j] == 1)
                {
                    area++;
                    FindConnected(ref area, i - 1, j, grid);
                }
            }
            if (j > 0 && !Traversed[i, j - 1])
            {
                Traversed[i, j - 1] = true;
                if (grid[i, j - 1] == 1)
                {
                    area++;
                    FindConnected(ref area, i, j-1, grid);
                }
            }
            if (i < grid.GetLength(0)-1 && !Traversed[i + 1, j])
            {
                Traversed[i+1, j] = true;
                if (grid[i + 1, j] == 1)
                {
                    area++;
                    FindConnected(ref area, i+1, j, grid);
                }
            }
            if (j < grid.GetLength(1) - 1 && !Traversed[i, j+1])
            {
                Traversed[i, j + 1] = true;
                if (grid[i, j + 1] == 1)
                {
                    area++;
                    FindConnected(ref area, i, j + 1, grid);
                }
            }
        }
    }
}
