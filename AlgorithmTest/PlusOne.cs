namespace ConsoleApp1
{
    class PlusOne
    {
        /*Given a non-negative integer represented as a non-empty array of digits, plus one to the integer.
         * You may assume the integer do not contain any leading zero, except the number 0 itself.
         * The digits are stored such that the most significant digit is at the head of the list.
         */
        public static int[] PlusOneSolution(int[] digits)
        {
            int carry = 1;
            for (int i = digits.Length-1; i > -1; i--)
            {
                int temp = digits[i] + carry;
                carry = temp / 10;
                digits[i] = temp % 10;
                if (carry == 0) return digits;
            }
            var ret =  new int[digits.Length+1];
            ret[0] = 1;
            return ret;
        }

        public static int[] Solution2(int[] digits)
        {
            var n = digits.Length;
            for (var i = n - 1; i >= 0; i--)
            {
                if (digits[i] < 9)
                {
                    digits[i]++;
                    return digits;
                }

                digits[i] = 0;
            }

            var newNumber = new int[n + 1];
            newNumber[0] = 1;
            return newNumber;
        }

    }
}
