using System;

namespace CS.Problems.Leetcode.DynamicProgramming
{
    public class MaximumSubArray
    {
        public static int Solve(int[] numbers)
        {
            if (numbers == null || numbers.Length == 0)
            {
                return 0;
            }

            var currentMax = numbers[0];
            var max = numbers[0];
            for (var i = 1; i < numbers.Length; ++i)
            {
                currentMax = Math.Max(numbers[i], currentMax + numbers[i]);
                max = Math.Max(currentMax, max);
            }

            return max;
        }
    }
}
