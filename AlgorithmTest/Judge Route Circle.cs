using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{
    class Judge_Route_Circle
    {
        public static bool JudgeCircle(string moves)
        {
            int v = 0, h = 0;
            foreach (var c in moves)
            {
                switch (c)
                {
                    case 'U':
                        v++;
                        break;
                    case 'D':
                        v--;
                        break;
                    case 'L':
                        h++;
                        break;
                    case 'R':
                        h--;
                        break;
                }
            }
            if (v == 0 && h == 0) return true;
            return false;
        }
    }
}
