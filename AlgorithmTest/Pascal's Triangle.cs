using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{
    /*
    Given numRows, generate the first numRows of Pascal's triangle.

    For example, given numRows = 5,
    Return

[
[1],
[1,1],
[1,2,1],
[1,3,3,1],
[1,4,6,4,1]
]
    */
    class Pascal_s_Triangle
    {
        public static IList<IList<int>> Generate(int numRows)
        {
            IList<IList<int>> ret = new List<IList<int>>();
            if (numRows == 0) return ret;
            List<int> l1 = new List<int>();
            l1.Add(1);
            ret.Add(l1);
            for (int i = 2; i <= numRows; i++)
            {
                var lpre = ret[i - 2];
                List<int> li = new List<int>();
                li.Add(1);
                for (int j = 1; j < i-1; j++)
                {
                   li.Add(lpre[j-1] + lpre[j]); 
                }
                li.Add(1);
                ret.Add(li);
            }
            return ret;
        }
    }
}
