namespace CS.Problems.Leetcode.MathP
{
    public class CountPrimes
    {
        public static int Solve(int n)
        {
            if (n <= 2)
            {
                return 0;
            }

            var primes = new bool[n];

            var count = 0;
            for (var i = 2; i < n; i++)
            {
                if (!primes[i])
                {
                    ++count;
                    for (var j = 2; j * i < n; ++j)
                    {
                        primes[j * i] = true;
                    }
                }
            }

            return count;
        }
    }
}
