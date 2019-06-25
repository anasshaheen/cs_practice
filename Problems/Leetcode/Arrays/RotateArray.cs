using System;

namespace CS.Problems.Leetcode.Arrays
{
    public class RotateArray
    {
        public static void Solve(int[] array, int k)
        {
            if (array == null || array.Length < 2)
            {
                return;
            }

            k = k % array.Length;
            Reverse(array, 0, array.Length - 1);
            Reverse(array, 0, k - 1);
            Reverse(array, k, array.Length - 1);
        }

        public static void SolveWithExtraSpace(int[] array, int k)
        {
            if (array == null || array.Length < 2)
            {
                return;
            }

            var result = new int[array.Length];
            Array.Copy(array, 0, result, 0, array.Length);

            for (var i = 0; i < array.Length; i++)
            {
                array[(i + k) % array.Length] = result[i];
            }
        }

        static void Reverse(int[] array, int start, int end)
        {
            if (start > end)
            {
                return;
            }

            while (start < end)
            {
                Swap(array, start++, end--);
            }
        }

        static void Swap(int[] array, int i, int j)
        {
            var temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }
    }
}
