using System.Collections.Generic;

namespace CS.Problems.Leetcode.MathP
{
    public class FizzBuzz
    {
        public static List<string> Solve(int n)
        {
            var result = new List<string>();
            for (var i = 1; i <= n; ++i)
            {
                if (i % 15 == 0)
                {
                    result.Add("FizzBuzz");
                }
                else if (i % 3 == 0)
                {
                    result.Add("Fizz");
                }
                else if (i % 5 == 0)
                {
                    result.Add("Buzz");
                }
                else
                {
                    result.Add(i.ToString());
                }
            }

            return result;
        }
    }
}
