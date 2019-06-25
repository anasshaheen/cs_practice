using System.Collections.Generic;
using System.Linq;
using CS.DataStructure.Trees;

namespace CS.Problems.Leetcode.Trees
{
    public class BinaryTreeLevelOrderTraversal
    {
        public IList<IList<int>> Solve(BinarySearchTree<int>.TreeNode<int> root)
        {
            var result = new List<IList<int>>();
            if (root == null)
            {
                return result;
            }

            var queue = new Queue<BinarySearchTree<int>.TreeNode<int>>();
            queue.Enqueue(root);

            while (queue.Any())
            {
                var levelItems = new List<int>();
                var count = queue.Count;

                while (count > 0)
                {
                    var node = queue.Dequeue();
                    levelItems.Add(node.Data);

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
