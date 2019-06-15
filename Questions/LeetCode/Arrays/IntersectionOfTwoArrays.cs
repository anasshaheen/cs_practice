using System;
using System.Collections.Generic;

namespace Questions.LeetCode.Arrays
{
    public class IntersectionOfTwoArrays
    {
        public static void Run()
        {
            var array1 = new[] { 1, 2, 2, 1 };
            var array2 = new[] { 2, 2 };
            var result = Solve(array1, array2);

            Console.WriteLine("Result from IntersectionOfTwoArrays: " + string.Join(",", result));
        }

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
