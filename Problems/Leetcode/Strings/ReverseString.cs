namespace CS.Problems.Leetcode.Strings
{
    public class ReverseString
    {
        public static void Solve(char[] chars)
        {
            if (chars.Length < 2)
            {
                return;
            }

            int start = 0, end = chars.Length - 1;
            while (start < end)
            {
                Swap(chars, start++, end--);
            }
        }

        private static void Swap(char[] chars, int i, int j)
        {
            var temp = chars[i];
            chars[i] = chars[j];
            chars[j] = temp;
        }
    }
}
