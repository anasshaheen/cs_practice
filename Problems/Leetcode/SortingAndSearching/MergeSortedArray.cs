namespace CS.Problems.Leetcode.SortingAndSearching
{
    public class MergeSortedArray
    {
        public static void Solve(int[] array1, int m, int[] array2, int n)
        {
            int p1 = m - 1, p2 = n - 1, t = n + m - 1;
            while (p1 >= 0 || p2 >= 0)
            {
                if (p1 == -1)
                {
                    array1[t--] = array2[p2--];
                }
                else if (p2 == -1)
                {
                    array1[t--] = array1[p1--];
                }
                else if (array1[p1] == array2[p2])
                {
                    array1[t--] = array1[p1--];
                    array1[t--] = array2[p2--];
                }
                else if (array1[p1] > array2[p2])
                {
                    array1[t--] = array1[p1--];
                }
                else
                {
                    array1[t--] = array2[p2--];
                }
            }
        }
    }
}
