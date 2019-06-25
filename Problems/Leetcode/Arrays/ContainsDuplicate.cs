using System.Collections.Generic;

namespace CS.Problems.Leetcode.Arrays
{
    public class ContainsDuplicate
    {
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
