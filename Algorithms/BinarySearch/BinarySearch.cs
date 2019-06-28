using System;

namespace CS.Algorithms.BinarySearch
{
    public class BinarySearch
    {
        public static int SearchIteratively<T>(T[] array, T item) where T : IComparable
        {
            int low = 0, high = array.Length - 1;
            while (low <= high)
            {
                var mid = low + (high - low) / 2;
                if (array[mid].CompareTo(item) == 0)
                {
                    return mid;
                }

                if (array[mid].CompareTo(item) < 0)
                {
                    low = mid + 1;
                }
                else
                {
                    high = mid - 1;
                }
            }

            return -1;
        }

        public static int SearchRecursively<T>(T[] array, T item) where T : IComparable
        {
            return SearchRecursivelyHelper(array, item, 0, array.Length - 1);
        }

        private static int SearchRecursivelyHelper<T>(T[] array, T item, int low, int high) where T : IComparable
        {
            if (low > high)
            {
                return -1;
            }

            var mid = low + (high - low) / 2;
            if (array[mid].CompareTo(item) == 0)
            {
                return mid;
            }

            if (array[mid].CompareTo(item) > 0)
            {
                return SearchRecursivelyHelper(array, item, low, mid - 1);
            }

            return SearchRecursivelyHelper(array, item, mid + 1, high);
        }
    }
}
