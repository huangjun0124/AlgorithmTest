using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{
    class ValidParentheses
    {
        public static bool IsValid(string s)
        {
            if (s.Length % 2 != 0) return false;
            Stack<char> stack = new Stack<char>();
            foreach (var c in s)
            {
                if (c == ')' || c == '}' || c == ']')
                {
                    if (stack.Count > 0)
                    {
                        var top = stack.Peek();
                        switch (c)
                        {
                            case ')':
                                if (top == '(')
                                    stack.Pop();
                                else
                                    return false;
                                break;
                            case '}':
                                if (top == '{')
                                    stack.Pop();
                                else
                                    return false;
                                break;
                            case ']':
                                if (top == '[')
                                    stack.Pop();
                                else
                                    return false;
                                break;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    stack.Push(c);
                }
            }
            if (stack.Count > 0) return false;
            return true;
        }


        public static bool IsValid2(string s)
        {
            if (s.Length % 2 != 0) return false;
            Stack<char> stack = new Stack<char>();
            foreach (var c in s)
            {
                if (c == '(')
                    stack.Push(')');
                else if (c == '{')
                    stack.Push('}');
                else if (c == '[')
                    stack.Push(']');
                else if (stack.Count == 0 || stack.Pop() != c)
                    return false;
            }
            return stack.Count == 0;
        }
    }
}
