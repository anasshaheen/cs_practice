using System;
using System.Collections.Generic;
using System.Linq;

namespace CS.Problems.Graph
{
    public class ExpressionTree
    {
        private HashSet<string> _operators;
        private readonly Node<string> _root;

        public ExpressionTree(Node<string> root = null)
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

        private Stack<int> Evaluate(Node<string> node, Stack<int> arguments = null)
        {
            if (arguments == null)
            {
                arguments = new Stack<int>();
            }

            if (node == null)
            {
                return arguments;
            }

            Evaluate(node.Left, arguments);
            Evaluate(node.Right, arguments);

            HandleArgument(node.Data, arguments);

            return arguments;
        }

        private void HandleArgument(string token, Stack<int> arguments)
        {
            if (int.TryParse(token, out var data))
            {
                arguments.Push(data);
            }
            else if (IsOperation(token))
            {
                var arg2 = arguments.Pop();
                var arg1 = arguments.Pop();

                var result = CalculateResult(token, arg1, arg2);
                arguments.Push(result);
            }
            else
            {
                throw new ArgumentException("Invalid argument!");
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

        public class Node<TData>
        {
            public Node<TData> Left { get; set; }
            public Node<TData> Right { get; set; }
            public TData Data { get; set; }

            public Node(TData data, Node<TData> left = null, Node<TData> right = null)
            {
                Left = left;
                Right = right;
                Data = data;
            }
        }
    }
}