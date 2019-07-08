using System.Collections.Generic;

namespace CS.Problems.Leetcode.MathP
{
    public class RomanToInteger
    {
        public static int Solve(string s)
        {
            var dict = new Dictionary<char, int>
            {
                {'M', 1000},
                {'D', 500},
                {'C', 100},
                {'L', 50},
                {'X', 10},
                {'V', 5},
                {'I', 1}
            };

            var number = 0;
            for (var i = 0; i < s.Length; ++i)
            {
                if (i + 1 <= s.Length - 1 && dict[s[i]] < dict[s[i + 1]])
                {
                    number -= dict[s[i]];
                }
                else
                {
                    number += dict[s[i]];
                }
            }

            return number;
        }
    }
}
