using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{
    class ReverseInteger
    {
        public static int Reverse(int x)
        {
            int ret = 0;
            int div10pos = int.MaxValue / 10, mod10pos = int.MaxValue % 10;
            int div10neg = int.MinValue / 10, mod10neg = int.MinValue % 10;
            int signed = x >= 0 ? 1:-1;
            int mod = x % 10; 
            while (x / 10 != 0)
            {
                if (signed == 1)
                {
                    if (div10pos < ret || (div10pos == ret && mod10pos < mod))
                    {
                        ret = 0;
                        break;
                    }
                }
                else
                {
                    if (div10neg > ret || (div10neg == ret && mod10neg > mod))
                    {
                        ret = 0;
                        break;
                    }
                }
                ret = ret * 10 + mod;
                x = x / 10;
                mod = x % 10;
            }
            if (signed == 1)
            {
                if (div10pos < ret || (div10pos == ret && mod10pos < mod))
                {
                    ret = 0;
                }
                else
                {
                    ret = ret * 10 + mod;
                }
            }
            else
            {
                if (div10neg > ret || (div10neg == ret && mod10neg > mod))
                {
                    ret = 0;
                }
                else
                {
                    ret = ret * 10 + mod;
                }
            }

            return ret;
        }

        public static int Reverse2(int x)
        {
            int result = 0;
            while (x != 0)
            {
                int mod = x % 10;  //could be negtive
                int newResult = result * 10 + mod;
                if ((newResult - mod) / 10 != result)
                {
                    return 0;
                }
                result = newResult;
                x = x / 10;
            }
            return result;
        }
    }
}
