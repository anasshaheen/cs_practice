using System;
using System.Diagnostics;

namespace CS.DataStructure.Trees
{
    public class BinarySearchTree<TData> where TData : IComparable
    {
        public TreeNode<TData> Root;

        public BinarySearchTree(TreeNode<TData> root = null)
        {
            Root = root;
        }

        public void Traverse(TraversalTypes type = TraversalTypes.InOrder)
        {
            switch (type)
            {
                case TraversalTypes.InOrder:
                    InOrderTraversal(Root);
                    break;
                case TraversalTypes.PostOrder:
                    PostOrderTraversal(Root);
                    break;
                default:
                    PreOrderTraversal(Root);
                    break;
            }
        }

        public bool Exists(TData data)
        {
            return SearchHelper(Root, data);
        }

        public void Insert(TData data)
        {
            if (Root == null)
            {
                Root = new TreeNode<TData>(data);
            }
            else
            {
                InsertHelper(Root, data);
            }
        }

        public bool Delete(TData data)
        {
            try
            {
                if (Root == null)
                {
                    return false;
                }

                DeleteHelper(Root, data);

                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return false;
            }
        }

        #region Helpers

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
        }

        private TData FindMin(TreeNode<TData> node)
        {
            if (node.Left == null)
            {
                return node.Data;
            }

            return FindMin(node.Left);
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
        PostOrder = 3
    }
}
