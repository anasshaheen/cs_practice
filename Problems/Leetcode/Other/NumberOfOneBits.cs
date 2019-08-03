using System;
using System.Collections;
using System.Linq;

namespace CS.Problems.Leetcode.Other
{
    public class NumberOfOneBits
    {
        public static int Solve(uint n, bool useShift = false)
        {
            var count = 0;
            if (useShift)
            {
                while (n > 0)
                {
                    count += (int) n & 1;
                    n = n >> 1;
                }
            }
            else
            {
                var bitStr = Convert.ToString(n, 2);
                foreach (var ch in bitStr)
                {
                    if (ch == '1')
                    {
                        ++count;
                    }
                }
            }

            return count;
        }
    }
}