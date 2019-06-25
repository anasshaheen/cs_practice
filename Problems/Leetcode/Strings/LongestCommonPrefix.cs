using System.Collections.Generic;
using System.Linq;

namespace CS.Problems.Leetcode.Strings
{
    public class LongestCommonPrefix
    {
        public static string Solve(string[] strs)
        {
            if (strs == null || strs.Length == 0)
            {
                return "";
            }

            if (strs.Length == 1)
            {
                return strs[0];
            }

            var result = "";
            var trie = new TrieNode();
            foreach (var word in strs)
            {
                if (string.IsNullOrWhiteSpace(word))
                {
                    return result;
                }

                trie.Insert(word);
            }

            if (trie.Nodes.Count != 1)
            {
                return result;
            }

            var current = trie;
            while (current.Nodes.Count == 1 && !current.IsValid)
            {

                var temp = current.Nodes.First();
                current = temp.Value;
                result += temp.Key;
            }

            return result;
        }

        public class TrieNode
        {
            public Dictionary<char, TrieNode> Nodes { get; set; }
            public bool IsValid { get; set; }

            public TrieNode(bool isValid = false)
            {
                IsValid = isValid;
                Nodes = new Dictionary<char, TrieNode>();
            }

            public void Insert(string word)
            {
                var current = this;
                for (var i = 0; i < word.Length; i++)
                {
                    var ch = word[i];
                    if (current.Nodes.ContainsKey(ch))
                    {
                        current = current.Nodes[ch];
                        if (i == word.Length - 1)
                        {
                            current.IsValid = true;
                        }
                    }
                    else
                    {
                        var newNode = new TrieNode(i == word.Length - 1);
                        current.Nodes.Add(ch, newNode);

                        current = newNode;
                    }
                }
            }
        }
    }
}
