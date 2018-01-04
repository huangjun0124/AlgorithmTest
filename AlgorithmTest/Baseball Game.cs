using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{
    class Baseball_Game
    {
        public static int CalPoints(string[] ops)
        {
            int ret = 0;
            List<int> valid = new List<int>();
            var tmp = 0;
            foreach (var s in ops)
            {
                switch (s)
                {
                    case "+":
                        tmp = valid[valid.Count - 1] + valid[valid.Count - 2];
                        ret += tmp;
                        valid.Add(tmp);
                        break;
                    case "D":
                        tmp = valid[valid.Count - 1] * 2;
                        ret += tmp;
                        valid.Add(tmp);
                        break;
                    case "C":
                        ret -= valid[valid.Count - 1];
                        valid.RemoveAt(valid.Count-1);
                        break;
                    default:
                        valid.Add(int.Parse(s));
                        ret += valid[valid.Count - 1];
                        break;
                }
            }
            return ret;
        }
    }
}
