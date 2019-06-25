using System;

namespace CS.Problems.Leetcode.Strings
{
    public class StringToInteger
    {
        public static int Solve(string str)
        {
            if (string.IsNullOrWhiteSpace(str))
            {
                return 0;
            }

            var spaceEndIndex = 0;
            try
            {
                var i = 0;
                while (str[i] == ' ')
                {
                    ++i;
                }
                spaceEndIndex = i;

                if (!char.IsDigit(str[i]) && !IsSign(str[i]))
                {
                    return 0;
                }

                var number = "";
                if (IsSign(str[i]))
                {
                    number += str[i];
                    ++i;
                }

                while (i < str.Length && char.IsDigit(str[i]))
                {
                    number += str[i];
                    ++i;
                }

                return int.Parse(number);
            }
            catch (OverflowException)
            {
                if (str[spaceEndIndex] == '-')
                {
                    return int.MinValue;
                }

                return int.MaxValue;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        private static bool IsSign(char ch)
        {
            return ch == '-' || ch == '+';
        }
    }
}
