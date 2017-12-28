using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{
    class ZigZagConversion
    {
        /*
        Zigzag:即循环对角线结构（
        0 	  	  	  	8 	  	  	  	16 	  	  	 
        1 	  	  	7 	9 	  	  	15 	17 	  	  	 
        2 	  	6 	  	10 	  	14 	  	18 	  	  	 
        3 	5 	  	  	11 	13 	  	  	19 	  	  	 
        4 	  	  	  	12 	  	  	  	20 	  	  	 

        ）
        向下循环:nRows
        斜角线循环:nRows-2(减去首尾两个端点)
        */
        public static string Convert(string s, int nRows)
        {
            if (nRows == 1) return s;
            string[] res = new string[nRows];
            int i = 0, j, gap = nRows - 2, len = s.Length;
            while (i < len)
            {
                //loop down
                for (j = 0; i < len && j < nRows; ++j) res[j] += s[i++];
                // loop cross corner
                for (j = gap; i < len && j > 0; --j) res[j] += s[i++];
            }
            string str = "";
            for (i = 0; i < nRows; ++i)
                str += res[i];
            return str;
        }
    }
}
