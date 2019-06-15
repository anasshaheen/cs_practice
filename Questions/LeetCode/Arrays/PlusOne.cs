using System;
using System.Collections.Generic;

namespace Questions.LeetCode.Arrays
{
    public class PlusOne
    {
        public static void Run()
        {
            var input1 = new[] { 9, 9, 9 };
            var result1 = Solve(input1);

            Console.WriteLine("Result from PlusOne: " + string.Join(",", result1));

            var input2 = new[] { 1, 2, 3 };
            var result2 = Solve(input2);
            Console.WriteLine("Result from PlusOne: " + string.Join(",", result2));

            var input3 = new[] { 2, 9, 9 };
            var result3 = Solve(input3);
            Console.WriteLine("Result from PlusOne: " + string.Join(",", result3));
        }

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
