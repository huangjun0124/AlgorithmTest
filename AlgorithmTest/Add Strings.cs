using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{
    /*
    Given two non-negative integers num1 and num2 represented as string, return the sum of num1 and num2.

    Note:

    The length of both num1 and num2 is < 5100.
    Both num1 and num2 contains only digits 0-9.
    Both num1 and num2 does not contain any leading zero.
    You must not use any built-in BigInteger library or convert the inputs to integer directly.
    */
    class Add_Strings
    {
        public string AddStrings(string num1, string num2)
        {
            StringBuilder ret = new StringBuilder();
            int i = num1.Length - 1, j = num2.Length - 1, carry = 0, ba = '0' * 2;
            while (i > -1 && j > -1)
            {
                int tmp = num1[i] + num2[j] - ba + carry;
                Caculate(tmp, ref carry, ret);
                i--;
                j--;
            }
            while (i > -1)
            {
                if (carry == 0)
                {
                    ret.Insert(0, num1[i]);
                }
                else
                {
                    int tmp = num1[i] - '0' + carry;
                    Caculate(tmp, ref carry, ret);
                }
                i--;
            }
            while (j > -1)
            {
                if (carry == 0)
                {
                    ret.Insert(0, num2[j]);
                }
                else
                {
                    int tmp = num2[j] - '0' + carry;
                    Caculate(tmp, ref carry, ret);
                }
                j--;
            }
            if (carry == 1)
                ret.Insert(0, "1");
            return ret.ToString();
        }

        private void Caculate(int tmp, ref int carry, StringBuilder ret)
        {
            if (tmp <= 9)
            {
                carry = 0;
                ret.Insert(0, tmp);
            }
            else
            {
                carry = 1;
                ret.Insert(0, tmp%10);
            }
        }

        public string Solution2(string num1, string num2)
        {
            StringBuilder sb = new StringBuilder();
            int carry = 0;
            for (int i = num1.Length - 1, j = num2.Length - 1; i >= 0 || j >= 0 || carry == 1; i--, j--)
            {
                int x = i < 0 ? 0 : num1[i] - '0';
                int y = j < 0 ? 0 : num2[j] - '0';
                sb.Append((x + y + carry) % 10);
                carry = (x + y + carry) / 10;
            }
            char[] charArray = sb.ToString().ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);

            return new string(sb.ToString().Reverse().ToArray());
        }
    }
}
