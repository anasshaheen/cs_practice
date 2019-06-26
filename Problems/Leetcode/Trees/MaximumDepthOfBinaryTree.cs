using System;

namespace CS.Problems.Leetcode.Trees
{
    public class MaximumDepthOfBinaryTree
    {
        public static int Solve(TreeNode node)
        {
            if (node == null)
            {
                return 0;
            }

            var leftSubTree = Solve(node.Left);
            var rightSubTree = Solve(node.Right);

            return Math.Max(leftSubTree, rightSubTree) + 1;
        }
    }
}
