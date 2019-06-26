using System.Collections.Generic;
using System.Linq;

namespace CS.Problems.Leetcode.Trees
{
    public class BinaryTreeLevelOrderTraversal
    {
        public static IList<IList<int>> Solve(TreeNode root)
        {
            var result = new List<IList<int>>();
            if (root == null)
            {
                return result;
            }

            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);

            while (queue.Any())
            {
                var levelItems = new List<int>();
                var count = queue.Count;

                while (count > 0)
                {
                    var node = queue.Dequeue();
                    levelItems.Add(node.Val);

                    if (node.Left != null)
                    {
                        queue.Enqueue(node.Left);
                    }

                    if (node.Right != null)
                    {
                        queue.Enqueue(node.Right);
                    }

                    --count;
                }

                result.Add(levelItems);
            }

            return result;
        }
    }
}
