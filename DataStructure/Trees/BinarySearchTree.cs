using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace CS.DataStructure.Trees
{
    public class BinarySearchTree<TData> where TData : IComparable
    {
        private TreeNode<TData> _root;

        public BinarySearchTree(TreeNode<TData> root = null)
        {
            _root = root;
        }

        public void Traverse(TraversalTypes type = TraversalTypes.InOrder)
        {
            switch (type)
            {
                case TraversalTypes.InOrder:
                    InOrderTraversal(_root);
                    break;
                case TraversalTypes.PostOrder:
                    PostOrderTraversal(_root);
                    break;
                case TraversalTypes.PreOrder:
                    PreOrderTraversal(_root);
                    break;
                case TraversalTypes.DFS:
                    DfsTraversal(_root);
                    break;
                default:
                    BfsTraversal(_root);
                    break;
            }
        }

        public bool Exists(TData data)
        {
            return SearchHelper(_root, data);
        }

        public void Insert(TData data)
        {
            if (_root == null)
            {
                _root = new TreeNode<TData>(data);
            }
            else
            {
                InsertHelper(_root, data);
            }
        }

        public bool Delete(TData data)
        {
            try
            {
                if (_root == null)
                {
                    return false;
                }

                DeleteHelper(_root, data);

                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return false;
            }
        }

        public TData FindMin()
        {
            if (_root == null)
            {
                return default;
            }

            var current = _root;
            while (current.Left != null)
            {
                current = current.Left;
            }

            return current.Data;
        }

        public TData FindMax()
        {
            if (_root == null)
            {
                return default;
            }

            var current = _root;
            while (current.Right != null)
            {
                current = current.Right;
            }

            return current.Data;
        }

        public int FindHeight()
        {
            if (_root == null)
            {
                return 0;
            }

            return FindHeight(_root);
        }

        #region Helpers

        private int FindHeight(TreeNode<TData> node)
        {
            if (node == null)
            {
                return 0;
            }

            return 1 + Math.Max(FindHeight(node.Left), FindHeight(node.Right));
        }

        private TreeNode<TData> InsertHelper(TreeNode<TData> node, TData data)
        {
            if (node == null)
            {
                return new TreeNode<TData>(data);
            }

            if (data.CompareTo(node.Data) <= 0)
            {
                node.Left = InsertHelper(node.Left, data);
            }
            else if (data.CompareTo(node.Data) >= 0)
            {
                node.Right = InsertHelper(node.Right, data);
            }

            return node;
        }

        private void InOrderTraversal(TreeNode<TData> node)
        {
            if (node == null)
            {
                return;
            }

            InOrderTraversal(node.Left);
            Console.WriteLine(node.Data);
            InOrderTraversal(node.Right);
        }

        private void PreOrderTraversal(TreeNode<TData> node)
        {
            if (node == null)
            {
                return;
            }

            Console.WriteLine(node.Data);
            InOrderTraversal(node.Left);
            InOrderTraversal(node.Right);
        }

        private void PostOrderTraversal(TreeNode<TData> node)
        {
            if (node == null)
            {
                return;
            }

            InOrderTraversal(node.Left);
            InOrderTraversal(node.Right);
            Console.WriteLine(node.Data);
        }

        private void BfsTraversal(TreeNode<TData> node)
        {
            if (node == null)
            {
                return;
            }

            var queue = new Queue<TreeNode<TData>>();
            queue.Enqueue(node);
            while (queue.Any())
            {
                var currentNode = queue.Dequeue();

                Console.WriteLine(currentNode.Data);

                if (currentNode.Left != null)
                {
                    queue.Enqueue(currentNode.Left);
                }

                if (currentNode.Right != null)
                {
                    queue.Enqueue(currentNode.Right);
                }
            }
        }

        private void DfsTraversal(TreeNode<TData> node)
        {
            if (node == null)
            {
                return;
            }

            var stack = new Stack<TreeNode<TData>>();
            stack.Push(node);

            while (stack.Any())
            {
                var currentNode = stack.Pop();

                Console.WriteLine(currentNode.Data);

                if (currentNode.Left != null)
                {
                    stack.Push(currentNode.Left);
                }

                if (currentNode.Right != null)
                {
                    stack.Push(currentNode.Right);
                }
            }
        }

        private bool SearchHelper(TreeNode<TData> node, TData data)
        {
            if (data.CompareTo(node.Data) == 0)
            {
                return true;
            }

            if (data.CompareTo(node.Data) <= 0)
            {
                if (node.Left != null)
                {
                    return SearchHelper(node.Left, data);
                }

                return false;
            }

            if (data.CompareTo(node.Data) >= 0)
            {
                if (node.Right != null)
                {
                    return SearchHelper(node.Right, data);
                }

                return false;
            }

            return false;
        }

        private TreeNode<TData> DeleteHelper(TreeNode<TData> node, TData data)
        {
            if (data.CompareTo(node.Data) < 0)
            {
                node.Left = DeleteHelper(node.Left, data);
            }

            if (data.CompareTo(node.Data) > 0)
            {
                node.Right = DeleteHelper(node.Right, data);
            }

            if (data.CompareTo(node.Data) == 0)
            {
                if (node.Left == null && node.Right == null)
                {
                    return null;
                }

                if (node.Left == null && node.Right != null)
                {
                    return node.Right;
                }

                if (node.Right == null && node.Left != null)
                {
                    return node.Left;
                }

                if (node.Right != null && node.Left != null)
                {
                    var value = FindMin(node.Right);
                    node.Data = value;
                    node.Right = DeleteHelper(node.Right, value);
                }
            }

            return node;

            TData FindMin(TreeNode<TData> root)
            {
                if (root == null)
                {
                    return default;
                }

                var current = root;
                while (current.Left != null)
                {
                    current = current.Left;
                }

                return current.Data;
            }
        }

        #endregion

        public class TreeNode<T> where T : IComparable
        {
            public TreeNode(T data, TreeNode<T> left = null, TreeNode<T> right = null)
            {
                Data = data;
                Right = right;
                Left = left;
            }

            public T Data { get; set; }
            public TreeNode<T> Right { get; set; }
            public TreeNode<T> Left { get; set; }
        }
    }

    public enum TraversalTypes
    {
        InOrder = 1,
        PreOrder = 2,
        PostOrder = 3,
        BFS = 4,
        DFS = 5
    }
}
