using System.Collections.Generic;

namespace CS.Problems.Leetcode.Arrays
{
    public class TwoSum
    {
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
