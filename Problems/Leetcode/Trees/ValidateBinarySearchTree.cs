namespace CS.Problems.Leetcode.Trees
{
    public class ValidateBinarySearchTree
    {
        public static bool Solve(TreeNode root)
        {
            if (root == null || (root.Left == null && root.Right == null))
            {
                return true;
            }

            return CheckHelper(root);
        }

        private static bool CheckHelper(TreeNode node, int? min = null, int? max = null)
        {
            if (node == null)
            {
                return true;
            }

            if (!(node.Val > min && node.Val < max) ||
                (node.Left != null && node.Left.Val >= node.Val) ||
                (node.Right != null && node.Right.Val <= node.Val))
            {
                return false;
            }

            var lCheck = CheckHelper(node.Left, min, node.Val);
            var rCheck = CheckHelper(node.Right, node.Val, max);

            return lCheck && rCheck;
        }
    }
}
