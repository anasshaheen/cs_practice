using System;

namespace Questions.LeetCode.Strings
{
    public class ValidPalindrome
    {
        public static void Run()
        {
            var str = "A man, a plan, a canal: Panama";
            var result = Solve(str);

            Console.WriteLine("Result from ValidPalindrome: " + result);
        }

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
