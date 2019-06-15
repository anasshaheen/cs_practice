using System;

namespace Questions.LeetCode.Arrays
{
    public class MoveZeroes
    {
        public static void Run()
        {
            var input = new[] { 0, 1, 0, 3, 12, 0, 15, 0, 0 };
            Solve(input);

            Console.WriteLine("Result from MoveZeroes: " + string.Join(",", input));
        }

        public static void Solve(int[] array)
        {
            var zeroIndices = 0;
            for (var i = 0; i < array.Length; ++i)
            {
                if (array[i] == 0)
                {
                    ++zeroIndices;
                }
                else
                {
                    var index = i - zeroIndices;
                    var temp = array[index];
                    array[index] = array[i];
                    array[i] = temp;
                }
            }
        }
    }
}
