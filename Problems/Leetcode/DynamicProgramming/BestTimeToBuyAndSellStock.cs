namespace CS.Problems.Leetcode.DynamicProgramming
{
    public class BestTimeToBuyAndSellStock
    {
        public static int Solve(int[] prices)
        {
            if (prices == null || prices.Length == 0)
            {
                return 0;
            }

            int min = prices[0], profit = 0;
            for (var i = 0; i < prices.Length; ++i)
            {
                if (prices[i] < min)
                {
                    min = prices[i];
                }
                else if (prices[i] - min > profit)
                {
                    profit = prices[i] - min;
                }
            }

            return profit;
        }
    }
}
