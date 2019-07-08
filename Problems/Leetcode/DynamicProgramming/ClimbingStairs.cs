using System;

namespace CS.Problems.Leetcode.DynamicProgramming
{
    public class ClimbingStairs
    {
        public static int Solve(int n)
        {
            var m = new int[n + 1];
            m[0] = 1;
            m[1] = 1;
            for (var i = 2; i <= n; i++)
            {
                m[i] = m[i - 1] + m[i - 2];
            }

            return m[n];
        }
    }
}
