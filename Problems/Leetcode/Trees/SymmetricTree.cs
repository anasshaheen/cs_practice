namespace CS.Problems.Leetcode.Trees
{
    public class SymmetricTree
    {
        public static bool Solve(TreeNode root)
        {
            if (root == null)
            {
                return true;
            }


            return IsSym(root, root);
        }

        private static bool IsSym(TreeNode left, TreeNode right)
        {
            if (left == null && right == null)
            {
                return true;
            }

            if (left == null || right == null || left.Val != right.Val)
            {
                return false;
            }

            return IsSym(left.Left, right.Right) && IsSym(left.Right, right.Left);
        }
    }
}
