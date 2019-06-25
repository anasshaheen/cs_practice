namespace CS.Problems.Graph
{
    public class RankTree
    {
        private RankNode _root;

        public void Insert(int data)
        {
            if (_root == null)
            {
                _root = new RankNode(data);
            }
            else
            {
                Insert(data, _root);
            }
        }

        public int FindRank(int data)
        {
            return FindRank(data, _root);
        }

        #region Helpers

        private int FindRank(int data, RankNode node)
        {
            if (node.Data == data)
            {
                return node.LeftSize;
            }

            if (data < node.Data)
            {
                if (node.Left == null)
                {
                    return -1;
                }

                return FindRank(data, node.Left);
            }

            if (data > node.Data)
            {
                if (node.Right == null)
                {
                    return -1;
                }

                return FindRank(data, node.Right) + 1 + node.LeftSize;
            }

            return -1;
        }

        private RankNode Insert(int data, RankNode node)
        {
            if (node == null)
            {
                return new RankNode(data);
            }

            if (data <= node.Data)
            {
                node.Left = Insert(data, node.Left);
                node.Increment();
            }
            else
            {
                node.Right = Insert(data, node.Right);
            }

            return node;
        }

        #endregion

        public class RankNode
        {
            public RankNode(int data, RankNode left = null, RankNode right = null)
            {
                Data = data;
                Left = left;
                Right = right;
                LeftSize = 0;
            }

            public void Increment()
            {
                ++LeftSize;
            }

            public int LeftSize { get; private set; }
            public RankNode Right { get; set; }
            public RankNode Left { get; set; }
            public int Data { get; private set; }
        }
    }
}
