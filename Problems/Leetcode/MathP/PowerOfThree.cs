namespace CS.Problems.Leetcode.MathP
{
    public class IsPowerOfThree
    {
        public static bool Solve(int n)
        {
            if (n == 0)
            {
                return false;
            }

            while (n != 1)
            {
                if (n % 3 != 0)
                {
                    return false;
                }

                n = n / 3;
            }

            return true;
        }
    }
}
