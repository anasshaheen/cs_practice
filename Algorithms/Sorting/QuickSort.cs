namespace CS.Algorithms.Sorting
{
    public class QuickSort
    {
        public static void Sort(int[] array)
        {
            QuickSortHelper(array, 0, array.Length - 1);
        }

        #region Helpers

        private static void QuickSortHelper(int[] array, int start, int end)
        {
            if (start < end)
            {
                var partitionIndex = Partition(array, start, end);

                QuickSortHelper(array, start, partitionIndex - 1);
                QuickSortHelper(array, partitionIndex + 1, end);
            }
        }

        private static int Partition(int[] arr, int start, int end)
        {
            var pivot = arr[end];
            var smallerElIndex = start - 1;

            for (var i = 0; i < arr.Length; ++i)
            {
                if (arr[i] < pivot)
                {
                    SortHelpers.Swap(arr, i, smallerElIndex);
                    ++smallerElIndex;
                }
            }

            ++smallerElIndex;
            SortHelpers.Swap(arr, smallerElIndex, end);

            return smallerElIndex;
        }

        #endregion
    }
}
