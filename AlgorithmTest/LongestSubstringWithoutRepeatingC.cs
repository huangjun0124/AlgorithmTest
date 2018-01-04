using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class LongestSubstringWithoutRepeatingCharacter
    {
        /*
            "滑动窗口" 
            比方说 abcabccc 当你右边扫描到abca的时候你得把第一个a删掉得到bca，
            然后"窗口"继续向右滑动，每当加到一个新char的时候，左边检查有无重复的char，
            然后如果没有重复的就正常添加，
            有重复的话就左边扔掉一部分（从最左到重复char这段扔掉），在这个过程中记录最大窗口长度
        */
        public static int LongestSubstringWithoutRepeatingC(string s)
        {
            if (string.IsNullOrEmpty(s)) return 0;
            //新建一个map进行存储char
            Dictionary<char, int> map = new Dictionary<char, int>();
            int leftBound = 0;
            int max = 0;
            for (int i = 0; i < s.Length; i++)
            {
                char c = s[i];
                //窗口左边可能为下一个char，或者不变
                leftBound = Math.Max(leftBound, (map.ContainsKey(c)) ? map[c] + 1 : 0);
                max = Math.Max(max, i - leftBound + 1);//当前窗口长度
                map[c] = i;
            }
            return max;
        }
    }
}
