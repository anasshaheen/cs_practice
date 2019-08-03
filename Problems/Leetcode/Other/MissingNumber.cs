namespace CS.Problems.Leetcode.Other
{
    public class MissingNumber
    {
        public static int Solve(int[] nums)
        {
            if (nums.Length == 0)
            {
                return 0;
            }

            var max = nums[0];
            for (var i = 1; i < nums.Length; ++i)
            {
                if (nums[i] > max)
                {
                    max = nums[i];
                }
            }

            if (max == 0)
            {
                return 1;
            }

            var arr = new int?[max + 1];
            foreach (var num in nums)
            {
                arr[num] = num;
            }

            for (var i = 0; i < arr.Length; ++i)
            {
                if (arr[i] == null)
                {
                    return i;
                }

                if (i == arr.Length - 1)
                {
                    return max + 1;
                }
            }

            return -1;
        }
    }
}