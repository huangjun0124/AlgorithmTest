using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{
    /*
     You are climbing a stair case. It takes n steps to reach to the top.
     Each time you can either climb 1 or 2 steps. In how many distinct ways can you climb to the top?
     Note: Given n will be a positive integer. 
     */
    class ClimbingStairs
    {
        // input 44, this would take 8 seconds
        public static int ClimbStairs(int n)
        {
            return f(n);
        }

        private static int f(int n)
        {
            if (n == 0)
                return 0;
            if (n == 1)
                return 1;
            if (n == 2)
                return 2;
            return f(n - 1) + f(n - 2);
        }

        //input 44, take 5 milliseconds
        public static int SolutionByDP(int n)
        {
            if (n == 1)
            {
                return 1;
            }
            if (n == 2)
            {
                return 2;
            }
            int[] dp = new int[n + 1];
            dp[0] = 0;
            dp[1] = 1;
            dp[2] = 2;
            for (int i = 3; i <= n; i++)
            {
                dp[i] = dp[i - 1] + dp[i - 2];
            }
            return dp[n];
        }

        // save space
        public static int Solution3(int n)
        {
            if (n == 1) return 1;
            if (n == 2) return 2;
            int oneStepBefore = 2, twoStepBefore = 1;
            int result = 0;
            for (int i = 3; i <= n; i++)
            {
                result = oneStepBefore + twoStepBefore;
                twoStepBefore = oneStepBefore;
                oneStepBefore = result;
            }
            return result;
        }
    }
}
