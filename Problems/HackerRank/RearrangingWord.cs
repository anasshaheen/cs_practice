using System;
using System.Linq;

namespace CS.Problems.HackerRank
{
    public class RearrangingWord
    {
        public static string Solve(string word)
        {
            var hiI = -1;
            for (var i = 0; i < word.Length - 1; ++i)
            {
                if (word[i] < word[i + 1])
                {
                    hiI = i;
                }
            }

            if (hiI == -1)
            {
                return "no answer";
            }

            var hiJ = -1;
            for (var i = hiI + 1; i < word.Length; ++i)
            {
                if (word[i] > word[hiI])
                {
                    hiJ = i;
                }
            }

            var wordAsChars = word.ToCharArray().ToList();
            var tempChar = wordAsChars[hiI];
            wordAsChars[hiI] = wordAsChars[hiJ];
            wordAsChars[hiJ] = tempChar;

            var startingWord = wordAsChars.Take(hiI + 1);
            var endingWord = wordAsChars.Skip(hiI + 1);

            return string.Join("", startingWord) + string.Join("", endingWord.Reverse());
        }
    }
}
