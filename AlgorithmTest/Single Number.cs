using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{
    //Given an array of integers, every element appears twice except for one. Find that single one.
    class Single_Number
    {
        // A xor A = 0 and the XOR operator is commutative
        public static int FindSingleNumber(int[] nums)
        {
            int result = 0;
            foreach (var n in nums)
            {
                result = result ^ n;
            }
            return result;
        }
        /*
        we use bitwise XOR to solve this problem :

        first , we have to know the bitwise XOR 

        0 ^ N = N
        N ^ N = 0

        So… if N is the single number

            N1 ^ N1 ^ N2 ^ N2 ^…^ Nx ^ Nx ^ N

        = (N1^N1) ^ (N2^N2) ^…^ (Nx^Nx) ^ N

        = 0 ^ 0 ^ …^ 0 ^ N

        = N
        */
    }
}
