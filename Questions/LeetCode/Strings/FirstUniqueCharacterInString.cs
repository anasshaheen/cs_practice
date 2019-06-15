using System;
using System.Collections.Generic;

namespace Questions.LeetCode.Strings
{
    public class FirstUniqueCharacterInString
    {
        public static void Run()
        {
            var word = "leetcode";
            var result = Solve(word);

            Console.WriteLine("Result from FirstUniqueCharacterInString: " + result);
        }

        public static int Solve(string s)
        {
            if (string.IsNullOrWhiteSpace(s))
            {
                return -1;
            }

            var dict = new Dictionary<int, int>();
            for (var i = 0; i < s.Length; ++i)
            {
                if (dict.ContainsKey(s[i]))
                {
                    ++dict[s[i]];
                }
                else
                {
                    dict.Add(s[i], 1);
                }
            }

            for (var i = 0; i < s.Length; ++i)
            {
                if (dict[s[i]] == 1)
                {
                    return i;
                }
            }

            return -1;
        }
    }
}
