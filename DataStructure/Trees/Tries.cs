using System.Collections.Generic;

namespace CS.DataStructure.Trees
{
    public class Node
    {
        private readonly Dictionary<char, Node> _characters;
        private bool _isWord;

        public Node(bool isWord = false)
        {
            _characters = new Dictionary<char, Node>();
            _isWord = isWord;
        }

        public void MarkAsValidWord()
        {
            _isWord = true;
        }

        public Node AddNode(char ch, bool isWord = false)
        {
            var newNode = new Node(isWord);
            _characters.Add(ch, newNode);

            return newNode;
        }

        public Node GetCharNode(char ch)
        {
            return _characters[ch];
        }

        public bool IsPresent(char ch)
        {
            return _characters.ContainsKey(ch);
        }

        public bool IsValidWord()
        {
            return _isWord;
        }
    }

    public class Trie
    {
        private readonly Node _node;

        public Trie()
        {
            _node = new Node();
        }

        /** Inserts a word into the trie. */
        public void Insert(string word)
        {
            InsertHelper(word, _node);
        }

        private void InsertHelper(string word, Node node)
        {
            if (string.IsNullOrWhiteSpace(word))
            {
                node.MarkAsValidWord();
                return;
            }

            if (node.IsPresent(word[0]))
            {
                InsertHelper(word.Substring(1), node.GetCharNode(word[0]));
            }
            else
            {
                if (word.Length == 1)
                {
                    node.AddNode(word[0], true);
                }
                else
                {
                    var newNode = node.AddNode(word[0]);
                    InsertHelper(word.Substring(1), newNode);
                }
            }
        }

        /** Returns if the word is in the trie. */
        public bool Search(string word)
        {
            var result = SearchHelper(word, _node);
            if (result == null)
            {
                return false;
            }

            return result.Value;
        }

        private bool? SearchHelper(string word, Node node)
        {
            if (node.IsPresent(word[0]))
            {
                var charNode = node.GetCharNode(word[0]);
                if (word.Length == 1)
                {
                    return charNode.IsValidWord();
                }

                return SearchHelper(word.Substring(1), charNode);
            }

            return null;
        }

        /** Returns if there is any word in the trie that starts with the given prefix. */
        public bool StartsWith(string prefix)
        {
            var result = SearchHelper(prefix, _node);
            return result != null;
        }
    }
}
