using System;
using System.Collections.Generic;

namespace CS.Problems.Leetcode.Arrays
{
    public class IntersectionOfTwoArrays
    {
        public static int[] Solve(int[] array1, int[] array2)
        {
            var result = new List<int>(Math.Max(array1.Length, array2.Length));

            var dict = new Dictionary<int, int>();
            for (var i = 0; i < array1.Length; ++i)
            {
                if (dict.ContainsKey(array1[i]))
                {
                    ++dict[array1[i]];
                }
                else
                {
                    dict.Add(array1[i], 1);
                }
            }

            for (var i = 0; i < array2.Length; ++i)
            {
                if (dict.TryGetValue(array2[i], out var num) && num > 0)
                {
                    --dict[array2[i]];
                    result.Add(array2[i]);
                }
            }

            return result.ToArray();
        }
    }
}
