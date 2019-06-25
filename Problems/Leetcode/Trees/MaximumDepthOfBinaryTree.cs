using System;
using CS.DataStructure.Trees;

namespace CS.Problems.Leetcode.Trees
{
    public class MaximumDepthOfBinaryTree
    {
        public static int Solve(BinarySearchTree<int>.TreeNode<int> node)
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
