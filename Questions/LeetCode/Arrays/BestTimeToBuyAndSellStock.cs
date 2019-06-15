using System;

namespace Questions.LeetCode.Arrays
{
    public class BestTimeToBuyAndSellStock
    {
        public static void Run()
        {
            var prices = new[] { 7, 1, 5, 3, 6, 4 };
            var profit = Solve(prices);

            Console.WriteLine("Result from BestTimeToBuyAndSellStock: " + profit);
        }

        public static int Solve(int[] prices)
        {
            if (prices == null || prices.Length < 2)
            {
                return 0;
            }

            var profit = 0;
            for (var i = 1; i < prices.Length; ++i)
            {
                if (prices[i] > prices[i - 1])
                {
                    profit += prices[i] - prices[i - 1];
                }
            }

            return profit;
        }
    }
}
