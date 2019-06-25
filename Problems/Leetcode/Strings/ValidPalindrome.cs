namespace CS.Problems.Leetcode.Strings
{
    public class ValidPalindrome
    {
        public static bool Solve(string s)
        {
            s.TrimStart();
            if (string.IsNullOrWhiteSpace(s))
            {
                return true;
            }

            int i = 0, j = s.Length - 1;
            while (i <= j)
            {
                while (!char.IsLetterOrDigit(s[i]) && i < j)
                {
                    ++i;
                }

                while (!char.IsLetterOrDigit(s[j]) && i < j)
                {
                    --j;
                }

                if (char.ToLower(s[i]) == char.ToLower(s[j]))
                {
                    ++i;
                    --j;
                }
                else
                {
                    return false;
                }
            }

            return true;
        }
    }
}
