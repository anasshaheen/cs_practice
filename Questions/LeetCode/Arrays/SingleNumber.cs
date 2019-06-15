using System;
using System.Collections.Generic;

namespace Questions.LeetCode.Arrays
{
    public class SingleNumber
    {
        public static void Run()
        {
            var input = new[] { 2, 2, 1 };
            var result1 = Solve(input);
            var result2 = SolveWithExtraSpace(input);

            Console.WriteLine("Result from SingleNumber: " + result1);
            Console.WriteLine("Result from SingleNumber-ExtraSpace: " + result2);
        }

        public static int Solve(int[] array)
        {
            var result = array[0];
            for (var i = 1; i < array.Length; i++)
            {
                result ^= array[i];
            }

            return result;
        }

        public static int SolveWithExtraSpace(int[] array)
        {
            var dict = new Dictionary<int, int>();
            for (var i = 0; i < array.Length; ++i)
            {
                if (dict.ContainsKey(array[i]))
                {
                    ++dict[array[i]];
                }
                else
                {
                    dict.Add(array[i], 1);
                }
            }

            for (var i = 0; i < array.Length; ++i)
            {
                if (dict[array[i]] == 1)
                {
                    return array[i];
                }
            }

            return -1;
        }
    }
}
