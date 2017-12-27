using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string str;
            while (true)
            {
                str = Console.ReadLine();
                Console.WriteLine(MyAtoI.atoi(str));
            }
        }

        
    }
}
