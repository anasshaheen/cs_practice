using System;
using System.Collections.Generic;
using System.Text;

namespace CS.Problems.Leetcode.Other
{
    public class PascalTriangle
    {
        public static IList<IList<int>> Solve(int numberOfRows)
        {
            var rows = new List<IList<int>>();
            if (numberOfRows == 0)
            {
                return rows;
            }

            rows.Add(new List<int> { 1 });
            if (numberOfRows < 0)
            {
                return rows;
            }

            for (var i = numberOfRows - 2; i >= 0; --i)
            {
                var numberOfCols = numberOfRows - i - 1;
                var currentRow = new List<int> { 1 };

                var p = 0;
                for (var j = numberOfCols - 1; j > 0; --j)
                {
                    currentRow.Add(rows[rows.Count - 1][p] + rows[rows.Count - 1][p + 1]);
                    ++p;
                }

                currentRow.Add(1);
                rows.Add(currentRow);
            }

            return rows;
        }
    }
}
