namespace CS.Problems.Leetcode.Arrays
{
    public class MoveZeroes
    {
        public static void Solve(int[] array)
        {
            var zeroIndices = 0;
            for (var i = 0; i < array.Length; ++i)
            {
                if (array[i] == 0)
                {
                    ++zeroIndices;
                }
                else
                {
                    var index = i - zeroIndices;
                    var temp = array[index];
                    array[index] = array[i];
                    array[i] = temp;
                }
            }
        }
    }
}
