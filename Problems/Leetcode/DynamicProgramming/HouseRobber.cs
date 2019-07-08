using System;

namespace CS.Problems.Leetcode.DynamicProgramming
{
    public static class HouseRobber
    {
        public static int Solve(int[] numbers)
        {
            if (numbers == null || numbers.Length == 0)
            {
                return 0;
            }

            if (numbers.Length == 1)
            {
                return numbers[0];
            }

            if (numbers.Length == 2)
            {
                return Math.Max(numbers[0], numbers[1]);
            }

            int robbed = 0, skipped = 0;
            foreach (var number in numbers)
            {
                var lastRob = robbed;
                robbed = skipped + number;
                skipped = Math.Max(skipped, lastRob);
            }

            return Math.Max(robbed, skipped);
        }
    }
}
