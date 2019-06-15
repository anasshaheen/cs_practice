using System;
using System.Collections.Generic;

namespace Questions.LeetCode.Arrays
{
    public class ContainsDuplicate
    {
        public static void Run()
        {
            var input = new[] { 1, 2, 3, 1 };
            var result = Solve(input);

            Console.WriteLine("Result from ContainsDuplicate: " + result);
        }

        public static bool Solve(int[] array)
        {
            if (array == null || array.Length < 2)
            {
                return false;
            }

            var set = new HashSet<int>();
            for (var i = 0; i < array.Length; i++)
            {
                if (!set.Add(array[i]))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
