namespace CS.Algorithms.Sorting
{
    public class SortHelpers
    {
        public static void Swap(int[] array, int i, int j)
        {
            var temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }
    }
}