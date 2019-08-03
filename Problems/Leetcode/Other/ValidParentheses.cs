using System.Collections.Generic;

namespace CS.Problems.Leetcode.Other
{
    public class ValidParentheses
    {
        public static bool Solve(string s)
        {
            var para = new Dictionary<char, char> {{')', '('}, {'}', '{'}, {']', '['}};

            var stack = new Stack<char>();
            foreach (var token in s)
            {
                if (para.ContainsValue(token))
                {
                    stack.Push(token);
                }
                else
                {
                    if (stack.Count == 0 || stack.Pop() != para[token])
                    {
                        return false;
                    }
                }
            }

            return stack.Count <= 0;
        }
    }
}