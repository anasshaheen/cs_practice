namespace CS.Problems.Leetcode.Trees
{
    public class ConvertSortedArrayToBinarySearchTree
    {
        public static TreeNode Solve(int[] array)
        {
            if (array == null || array.Length == 0)
            {
                return null;
            }

            return ToBst(array, 0, array.Length - 1);
        }

        private static TreeNode ToBst(int[] array, int i, int j)
        {
            if (i > j)
            {
                return null;
            }

            var mid = (i + j) / 2;
            return new TreeNode(array[mid])
            {
                Left = ToBst(array, i, mid - 1),
                Right = ToBst(array, mid + 1, j)
            };
        }
    }
}
