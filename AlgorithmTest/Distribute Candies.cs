using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{
    /*
Example 1:
Input: candies = [1,1,2,2,3,3]
Output: 3
Explanation:
There are three different kinds of candies(1, 2 and 3), and two candies for each kind.
Optimal distribution: The sister has candies [1,2,3] and the brother has candies[1, 2, 3], too.
The sister has three different kinds of candies. 

Example 2:
Input: candies = [1, 1, 2, 3]
Output: 2
Explanation: For example, the sister has candies [2,3] and the brother has candies[1, 1]. 
The sister has two different kinds of candies, the brother has only one kind of candies. 

Note:
The length of the given array is in range[2, 10, 000], and will be even.
The number in given array is in range[-100, 000, 100, 000].
*/
    class Distribute_Candies
    {
        public int DistributeCandies(int[] candies)
        {
            int ret = 0;
            Dictionary<int, int> map = new Dictionary<int, int>();
            foreach (var i in candies)
            {
                if (!map.ContainsKey(i))
                    map[i] = 1;
                else
                {
                    map[i]++;
                }
            }
            return map.Count >= candies.Length / 2 ? candies.Length / 2 : map.Count;
        }

        public int Solution2(int[] candies)
        {
            BitArray hash = new BitArray(200001);
            int count = 0;
            foreach (int i in candies)
            {
                if (!hash.Get(i + 100000))
                {
                    count++;
                    hash.Set(i + 100000, true);
                }
            }
            int n = candies.Length;
            return Math.Min(count, n / 2);
        }
    }
}
