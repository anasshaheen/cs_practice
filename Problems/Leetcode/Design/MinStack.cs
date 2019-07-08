using System;
using System.Collections.Generic;
using System.Linq;

namespace CS.Problems.Leetcode.Design
{
    public class MinStack
    {
        private readonly Stack<int> _stack;
        private readonly Stack<int> _minStack;

        public MinStack()
        {
            _stack = new Stack<int>();
            _minStack = new Stack<int>();
        }

        public void Push(int x)
        {
            _stack.Push(x);
            if (!_minStack.Any())
            {
                _minStack.Push(x);
            }
            else
            {
                _minStack.Push(Math.Min(x, _minStack.Peek()));
            }
        }

        public void Pop()
        {
            if (_stack.Any())
            {
                _minStack.Pop();
                _stack.Pop();
            }

        }

        public int Top()
        {
            return _stack.Peek();
        }

        public int GetMin()
        {
            return _minStack.Peek();
        }
    }
}
