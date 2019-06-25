using System.Collections.Generic;

namespace CS.Problems.Leetcode.Arrays
{
    public class PlusOne
    {
        public static int[] Solve(int[] digits)
        {
            var lastIndex = digits.Length - 1;
            if (digits[lastIndex] + 1 < 9)
            {
                ++digits[lastIndex];
                return digits;
            }

            var result = new Stack<int>();
            var carry = 1;
            digits[lastIndex] = 0;
            result.Push(digits[lastIndex]);

            for (var i = digits.Length - 2; i >= 0; --i)
            {
                if (carry == 0)
                {
                    result.Push(digits[i]);
                    continue;
                }

                if (digits[i] + carry < 9)
                {
                    digits[i] += carry;
                    carry = 0;
                    result.Push(digits[i]);
                }
                else
                {
                    carry = 1;
                    digits[i] = 0;
                    result.Push(digits[i]);
                }
            }

            if (carry != 0)
            {
                result.Push(carry);
                carry = 0;
            }

            return result.ToArray();
        }
    }
}
