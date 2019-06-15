﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Questions.LeetCode.Strings
{
    public class ValidAnagram
    {
        public static void Run()
        {
            string s = "anagram", t = "nagaram";
            var result = Solve(s, t);

            Console.WriteLine("Result from ValidAnagram: " + result);
        }

        public static bool Solve(string s, string t)
        {
            if (string.IsNullOrWhiteSpace(s) && string.IsNullOrWhiteSpace(t))
            {
                return true;
            }

            if (string.IsNullOrWhiteSpace(s) || string.IsNullOrWhiteSpace(t))
            {
                return false;
            }

            if (s.Length != t.Length)
            {
                return false;
            }

            var dict = new Dictionary<char, int>();
            for (var i = 0; i < s.Length; i++)
            {
                if (!dict.TryAdd(s[i], 1))
                {
                    ++dict[s[i]];
                }
            }

            for (int i = 0; i < t.Length; i++)
            {
                if (!dict.ContainsKey(t[i]))
                {
                    return false;
                }
                else
                {
                    --dict[t[i]];
                }
            }

            return dict.Values.All(e => e == 0);
        }
    }
}
