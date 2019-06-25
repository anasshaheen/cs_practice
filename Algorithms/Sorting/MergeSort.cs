namespace CS.Algorithms.Sorting
{
    public class MergeSort
    {
        public static void Sort(int[] array)
        {
            MergeSortHelper(array, 0, array.Length - 1);
        }

        #region Helpers

        private static void MergeSortHelper(int[] array, int low, int high)
        {
            if (low < high)
            {
                var middle = (low / 2) + (high / 2);

                MergeSortHelper(array, low, middle);
                MergeSortHelper(array, middle + 1, high);

                Merge(array, low, middle, high);
            }
        }

        private static void Merge(int[] array, int low, int middle, int high)
        {
            var left = low;
            var right = middle + 1;
            var tmpArr = new int[(high - low) + 1];

            var tmpIndex = 0;
            while (left <= middle && right <= high)
            {
                if (array[left] < array[right])
                {
                    tmpArr[tmpIndex] = array[left];
                    ++left;
                }
                else
                {
                    tmpArr[tmpIndex] = array[right];
                    ++right;
                }

                ++tmpIndex;
            }

            if (left <= middle)
            {
                while (left <= middle)
                {
                    tmpArr[tmpIndex] = array[left];
                    ++left;
                    ++tmpIndex;
                }
            }

            if (right <= high)
            {
                while (right <= high)
                {
                    tmpArr[tmpIndex] = array[right];
                    ++right;
                    ++tmpIndex;
                }
            }

            for (int i = 0; i < tmpArr.Length; i++)
            {
                array[low + i] = tmpArr[i];
            }
        }

        #endregion
    }
}