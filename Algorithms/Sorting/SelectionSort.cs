namespace CS.Algorithms.Sorting
{
    public class SelectionSort
    {
        public static void Sort(int[] array)
        {
            if (array.Length == 0)
            {
                return;
            }

            for (var i = 0; i < array.Length - 1; ++i)
            {
                var minIndex = i;
                for (var j = i + 1; j < array.Length; ++j)
                {
                    if (array[j] < array[minIndex])
                    {
                        minIndex = j;
                    }
                }

                if (i != minIndex)
                {
                    SortHelpers.Swap(array, i, minIndex);
                }
            }
        }
    }
}