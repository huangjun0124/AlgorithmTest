using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{
    /*
    Example 1:

    Input: 
    nums = 
[[1,2],
[3,4]]
r = 1, c = 4
Output: 
[[1,2,3,4]]
Explanation:
The row-traversing of nums is [1,2,3,4]. The new reshaped matrix is a 1 * 4 matrix, fill it row by row by using the previous list.

Example 2:

Input: 
nums =
[[1, 2],
[3,4]]
r = 2, c = 4
Output: 
[[1,2],
[3,4]]
Explanation:
There is no way to reshape a 2 * 2 matrix to a 2 * 4 matrix.So output the original matrix.
*/
    class Reshape_the_matrix
    {
        public static int[,] matrixReshape(int[,] nums, int r, int c)
        {
            if (nums.GetLength(0) * nums.GetLength(1) != r * c) return nums;
            int[,] ret = new int [r,c];
            int k = 0, m = 0;
            for (int i = 0; i < nums.GetLength(0); i++)
            {
                for (int j = 0; j < nums.GetLength(1); j++)
                {
                    ret[k, m++] = nums[i,j];
                    if (m == c)
                    {
                        k++;
                        m = 0;
                    }
                }
            }
            return ret;
        }

        public static int[,] Solution2(int[,] nums, int r, int c)
        {
            int n = nums.GetLength(0), m = nums.GetLength(1);
            if (n * m != r * c) return nums;
            int[,] ret = new int[r, c];
            for (int i = 0; i < r * c; i++)
                ret[i / c, i % c] = nums[i / m, i % m];
            return ret;
        }
    }
}
