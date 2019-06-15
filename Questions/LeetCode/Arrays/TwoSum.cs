using System;
using System.Collections.Generic;

namespace Questions.LeetCode.Arrays
{
    public class TwoSum
    {
        public static void Run()
        {
            var input1 = new[] { 2, 7, 11, 15 };
            var result1 = Solve(input1, 9);

            Console.WriteLine("Result from TwoSum: " + string.Join(",", result1));
        }

        public static int[] Solve(int[] numbers, int target)
        {
            var dict = new Dictionary<int, int>();
            for (var i = 0; i < numbers.Length; ++i)
            {
                var diff = target - numbers[i];
                if (dict.ContainsKey(diff))
                {
                    return new[] { dict[diff], i };
                }

                dict.Add(numbers[i], i);
            }

            return new[] { -1, -1 };
        }
    }
}
