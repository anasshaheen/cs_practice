using System;

namespace CS.Problems.Leetcode.Strings
{
    public class ImplementStrString
    {
        public static int Solve(string haystack, string needle)
        {
            var result = -1;
            var needleLength = needle.Length;
            var haystackSpan = haystack.AsSpan();

            for (var i = 0; i < haystack.Length - needleLength + 1; ++i)
            {
                var slice = haystackSpan.Slice(i, needleLength);
                if (slice.Equals(needle.AsSpan(), StringComparison.CurrentCulture))
                {
                    result = i;
                    break;
                }
            }

            return result;
        }
    }
}
