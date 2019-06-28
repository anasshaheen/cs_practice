namespace CS.Problems.Leetcode.SortingAndSearching
{
    public class VersionControl
    {
        public bool IsBadVersion(int version)
        {
            // IsBadVersion implementation.
            return true;
        }
    }


    public class FirstBadVersion : VersionControl
    {
        public int Solve(int n)
        {
            int low = 0, high = n;
            while (low <= high)
            {
                var mid = low + (high - low) / 2;
                if (IsBadVersion(mid))
                {
                    high = mid - 1;
                }
                else
                {
                    low = mid + 1;
                }
            }

            return low;
        }
    }
}
