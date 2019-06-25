using System.Collections.Generic;

namespace CS.Problems.Leetcode
{
    public class WordCountEngine
    {
        static string[,] Solve(string document)
        {
            var dict = new Dictionary<string, DocumentWord>();

            var word = "";
            var largestCount = 0;
            for (var i = 0; i < document.Length; ++i)
            {
                if (char.IsLetter(document[i]))
                {
                    word += char.ToLower(document[i]);
                }
                else if (document[i] == '\'')
                {
                    continue;
                }
                else
                {
                    var count = CheckCompleteWord(dict, word, i);
                    if (largestCount < count)
                    {
                        largestCount = count;
                    }
                    word = "";
                }
            }

            if (word.Length > 0)
            {
                var count = CheckCompleteWord(dict, word);
                if (largestCount < count)
                {
                    largestCount = count;
                }
            }

            var sortedArr = new List<string[]>[largestCount + 1];
            foreach (var valuePair in dict)
            {
                if (sortedArr[valuePair.Value.Count] == null)
                {
                    sortedArr[valuePair.Value.Count] = new List<string[]>();
                }

                sortedArr[valuePair.Value.Count].Add(new[] { valuePair.Key, $"{valuePair.Value.Count}" });
            }

            var result = new string[dict.Count, 2];
            var j = 0;
            for (var i = sortedArr.Length - 1; i >= 0; --i)
            {
                if (sortedArr[i] != null)
                {
                    foreach (var value in sortedArr[i])
                    {
                        result[j, 0] = value[0];
                        result[j, 1] = value[1];

                        ++j;
                    }
                }
            }

            return result;
        }

        private static int CheckCompleteWord(Dictionary<string, DocumentWord> dict, string word, int index = default)
        {
            if (word.Length > 0)
            {
                if (dict.ContainsKey(word))
                {
                    return dict[word].Increment();
                }
                else
                {
                    dict.Add(word, new DocumentWord(index));
                    return 1;
                }
            }

            return 0;
        }

        public class DocumentWord
        {
            public int Index;
            public int Count;

            public DocumentWord(int index)
            {
                Count = 1;
                Index = index;
            }

            public int Increment()
            {
                ++Count;

                return Count;
            }
        }
    }
}
