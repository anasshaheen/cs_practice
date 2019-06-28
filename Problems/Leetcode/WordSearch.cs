using System;
using System.Collections.Generic;

namespace CS.Problems.Leetcode
{
    public class WordSearch
    {
        private readonly char[][] _board;
        private readonly int _n;
        private readonly int _m;
        private readonly TrieNode _trieRoot;
        private readonly List<string> _result;

        public WordSearch(char[][] board, string[] words, int n, int m)
        {
            if (words == null || words.Length == 0)
            {
                throw new ArgumentException("Words list can't be empty.");
            }

            _board = board;
            _n = n;
            _m = m;
            _trieRoot = BuildTrie(words);
            _result = new List<string>();
        }

        public List<string> Solve()
        {
            var visited = new bool[_n][];
            for (int i = 0; i < visited.Length; i++)
            {
                visited[i] = new bool[_m];
            }

            for (var i = 0; i < _board.Length; i++)
            {
                for (var j = 0; j < _board[i].Length; j++)
                {
                    if (_trieRoot.Exists(_board[i][j]))
                    {
                        SearchHelper(
                            _trieRoot.GetNode(_board[i][j]),
                            i, j,
                            $"{_board[i][j]}",
                            visited
                        );
                    }
                }
            }

            return _result;
        }

        #region Helpers

        private void SearchHelper(TrieNode trie, int i, int j, string word, bool[][] visited)
        {
            if (trie.IsValid)
            {
                _result.Add(word);
            }

            if (!IsSafeToMove(i, j, visited))
            {
                return;
            }

            visited[i][j] = true;
            foreach (var node in trie.GetNodes())
            {
                if (IsSafeToMove(i - 1, j, visited) && _board[i - 1][j] == node.Key)
                {
                    SearchHelper(node.Value, i - 1, j, word + _board[i - 1][j], visited);
                }

                if (IsSafeToMove(i + 1, j, visited) && _board[i + 1][j] == node.Key)
                {
                    SearchHelper(node.Value, i + 1, j, word + _board[i + 1][j], visited);
                }

                if (IsSafeToMove(i, j - 1, visited) && _board[i][j - 1] == node.Key)
                {
                    SearchHelper(node.Value, i, j - 1, word + _board[i][j - 1], visited);
                }

                if (IsSafeToMove(i, j + 1, visited) && _board[i][j + 1] == node.Key)
                {
                    SearchHelper(node.Value, i, j + 1, word + _board[i][j + 1], visited);
                }
            }

            visited[i][j] = false;
        }

        private bool IsSafeToMove(int i, int j, bool[][] visited)
        {
            return i >= 0 && j >= 0 && i < _board.Length &&
                   j < _board[_n - 1].Length && !visited[i][j];
        }

        private TrieNode BuildTrie(string[] words)
        {
            var trie = new TrieNode();
            foreach (var word in words)
            {
                trie.Insert(word);
            }

            return trie;
        }

        #endregion
    }

    public class TrieNode
    {
        private readonly Dictionary<char, TrieNode> _nodes;
        public bool IsValid { get; private set; }

        public TrieNode(bool isValid = false)
        {
            IsValid = isValid;
            _nodes = new Dictionary<char, TrieNode>();
        }

        public void Insert(string word)
        {
            var current = this;
            for (var i = 0; i < word.Length; i++)
            {
                var ch = word[i];
                if (current.Exists(ch))
                {
                    current = current.GetNode(ch);
                    if (i == word.Length - 1)
                    {
                        current.IsValid = true;
                    }
                }
                else
                {
                    var newNode = new TrieNode(i == word.Length - 1);
                    current._nodes.Add(ch, newNode);

                    current = newNode;
                }
            }
        }

        public bool Exists(char ch)
        {
            return _nodes.ContainsKey(ch);
        }

        public TrieNode GetNode(char ch)
        {
            return _nodes[ch];
        }

        public Dictionary<char, TrieNode> GetNodes()
        {
            return _nodes;
        }
    }
}
