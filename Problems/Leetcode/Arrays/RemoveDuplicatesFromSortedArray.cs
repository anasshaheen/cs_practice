namespace CS.Problems.Leetcode.Arrays
{
    public class RemoveDuplicatesFromSortedArray
    {
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
