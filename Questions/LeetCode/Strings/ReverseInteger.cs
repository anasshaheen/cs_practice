using System;

namespace Questions.LeetCode.Strings
{
    public class ReverseInteger
    {
        public static void Run()
        {
            var x = 123;
            var result = Solve(x);

            Console.WriteLine("Result from ReverseInteger: " + result);
        }

        public static int Solve(int x)
        {
            var result = 0;
            while (x != 0)
            {
                try
                {
                    result = checked((result * 10) + (x % 10));
                    x /= 10;
                }
                catch (Exception)
                {
                    return 0;
                }
            }

            return result;
        }
    }
}
