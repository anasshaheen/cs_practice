namespace CS.Algorithms.Sorting
{
    public class BubbleSort
    {
        public static void Sort(int[] array)
        {
            if (array.Length == 0)
            {
                return;
            }

            var lastIndex = array.Length;
            var swapExists = false;
            while (lastIndex != 1)
            {
                for (var j = 0; j < lastIndex - 1; ++j)
                {
                    if (array[j] > array[j + 1])
                    {
                        SortHelpers.Swap(array, j + 1, j);
                        swapExists = true;
                    }
                }

                if (!swapExists)
                {
                    break;
                }
                --lastIndex;
            }
        }
    }
}