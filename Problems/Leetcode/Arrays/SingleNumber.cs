using System.Collections.Generic;

namespace CS.Problems.Leetcode.Arrays
{
    public class SingleNumber
    {
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
