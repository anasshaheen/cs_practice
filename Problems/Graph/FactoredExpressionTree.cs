using System;
using System.Collections.Generic;
using System.Linq;

namespace CS.Problems.Graph
{
    public class FactoredExpressionTree
    {
        private HashSet<string> _operators;
        private readonly Node _root;

        public FactoredExpressionTree(Node root = null)
        {
            _root = root;
            InitOperations();
        }

        public int Evaluate()
        {
            var arguments = Evaluate(_root);
            if (arguments.Count > 1)
            {
                throw new ArgumentException("Invalid expression!");
            }

            return arguments.First();
        }

        #region Helpers

        private Stack<int> Evaluate(Node node, Stack<int> arguments = null, Dictionary<Node, int> cache = null)
        {
            if (arguments == null)
            {
                cache = new Dictionary<Node, int>();
                arguments = new Stack<int>();
            }

            if (node == null)
            {
                return arguments;
            }

            Evaluate(node.Left, arguments, cache);
            Evaluate(node.Right, arguments, cache);

            HandleArgument(node, arguments, cache);

            return arguments;
        }

        private void HandleArgument(Node node, Stack<int> arguments, Dictionary<Node, int> cache)
        {
            if (cache.ContainsKey(node))
            {
                if (IsOperation(node.Data))
                {
                    arguments.Push(cache[node]);
                }
            }
            else
            {
                if (int.TryParse(node.Data, out var data))
                {
                    arguments.Push(data);

                    cache.Add(node, -1);
                }
                else if (IsOperation(node.Data))
                {
                    var arg2 = arguments.Pop();
                    var arg1 = arguments.Pop();

                    var result = CalculateResult(node.Data, arg1, arg2);
                    arguments.Push(result);

                    cache.Add(node, result);
                }
                else
                {
                    throw new ArgumentException("Invalid argument!");
                }
            }
        }

        private bool IsOperation(string @operator)
        {
            return _operators.Contains(@operator);
        }

        private int CalculateResult(string @operator, int arg1, int arg2)
        {
            switch (@operator)
            {
                case "+":
                    return arg1 + arg2;
                case "-":
                    return arg1 - arg2;
                case "/":
                    return arg1 / arg2;
                case "*":
                    return arg1 * arg2;
            }

            return 0;
        }

        private void InitOperations()
        {
            _operators = new HashSet<string>
            {
                "+",
                "-",
                "*",
                "/",
                "^"
            };
        }

        #endregion

        public class Node
        {
            public Node Left { get; set; }
            public Node Right { get; set; }
            public string Data { get; set; }

            public Node(string data, Node left = null, Node right = null)
            {
                Left = left;
                Right = right;
                Data = data;
            }
        }
    }
}