using System;

namespace CS.Problems.Leetcode.Strings
{
    public class ReverseInteger
    {
        public static int Solve(int x)
        {
            var result = 0;
            while (x != 0)
            {
                try
                {
                    result = checked((result * 10) + (x % 10));
                    x /= 10;
                }
                catch (Exception)
                {
                    return 0;
                }
            }

            return result;
        }
    }
}
