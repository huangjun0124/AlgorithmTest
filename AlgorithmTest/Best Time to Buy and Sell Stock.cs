using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{
    /*
    Say you have an array for which the ith element is the price of a given stock on day i.

    If you were only permitted to complete at most one transaction(ie, buy one and sell one share of the stock), design an algorithm to find the maximum profit.

    Example 1:

    Input: [7, 1, 5, 3, 6, 4]
Output: 5


max.difference = 6 - 1 = 5(not 7 - 1 = 6, as selling price needs to be larger than buying price)


Example 2:


Input: [7, 6, 4, 3, 1]
Output: 0


In this case, no transaction is done, i.e.max profit = 0.
    */
    class Best_Time_to_Buy_and_Sell_Stock
    {
        //Time Limit Exceeded
        public static int MaxProfit(int[] prices)
        {
            int maxDiff = 0;
            for (int i = 0; i < prices.Length-1; i++)
            {
                int max = prices[i];
                for (int j = i+1; j < prices.Length; j++)
                {
                    if (prices[j] > max)
                        max = prices[j];
                }
                if (max - prices[i] > maxDiff)
                    maxDiff = max - prices[i];
            }
            return maxDiff;
        }

        // Scan from right to left, evry encounter a num, the max to its right is know already
        public static int Solution2(int[] prices)
        {
            int l = prices.Length;
            if (l == 0) return 0;
            int curMax = prices[l-1], maxDiff = 0;
            for (int i = l-2; i > -1; i--)
            {
                if (prices[i] >= curMax)
                    curMax = prices[i];
                else
                {
                    if (maxDiff < curMax - prices[i])
                        maxDiff = curMax - prices[i];
                }
            }
            return maxDiff;
        }
    }
}
