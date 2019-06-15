using System;
using System.Linq;

namespace Questions.LeetCode.Arrays
{
    public class RemoveDuplicatesFromSortedArray
    {
        public static void Run()
        {
            var sortedArr = new[] { 0, 0, 1, 1, 1, 2, 2, 3, 3, 4 };
            var length = Solve(sortedArr);

            Console.WriteLine("Result from RemoveDuplicatesFromSortedArray: " + string.Join(",", sortedArr.Take(length)));
        }

        public static int Solve(int[] numbers)
        {
            if (numbers == null || numbers.Length == 0)
            {
                return 0;
            }

            if (numbers.Length == 1)
            {
                return 1;
            }

            var count = 0;
            for (var i = 1; i < numbers.Length; i++)
            {
                if (numbers[i] != numbers[count])
                {
                    numbers[++count] = numbers[i];
                }
            }

            return count + 1;
        }
    }
}
