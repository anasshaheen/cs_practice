using System.Collections.Generic;

namespace CS.Problems.Leetcode.Arrays
{
    public class ValidSudoku
    {
        public static bool Solve(char[][] board)
        {
            return CheckBoard(board);
        }

        static bool CheckBoard(char[][] board)
        {
            for (int i = 0; i < 9; i++)
            {
                if (!IsColsValid(board, i) || IsRowsValid(board, i))
                {
                    return false;
                }
            }

            return IsSubBoardsValid(board);
        }

        static bool IsColsValid(char[][] board, int col)
        {
            var set = new HashSet<char>();
            for (var row = 0; row < 9; row++)
            {
                if (board[row][col] != '.' && !set.Add(board[row][col]))
                {
                    return false;
                }
            }

            return true;
        }

        static bool IsRowsValid(char[][] board, int row)
        {
            var set = new HashSet<char>();
            for (var col = 0; col < 9; col++)
            {
                if (board[row][col] != '.' && !set.Add(board[row][col]))
                {
                    return false;
                }
            }

            return true;
        }

        static bool IsSubBoardsValid(char[][] board)
        {
            var set = new HashSet<char>();
            var points = new List<(int i, int j)>
            {
                (0, 0), (0, 3), (0, 6), (3, 0),
                (6, 0), (3, 3), (3, 6), (6, 3),
                (6, 6)
            };
            foreach (var point in points)
            {
                var result = IsSubBoardValid(board, point.i, point.j, set);
                if (!result)
                {
                    return false;
                }

                set.Clear();
            }

            return true;
        }

        static bool IsSubBoardValid(char[][] board, int i, int j, HashSet<char> set)
        {
            var rowCount = 3;
            for (var c = 0; c < 9; ++c)
            {
                if (rowCount == 0)
                {
                    rowCount = 3;
                    ++i;
                    j -= rowCount;
                }

                if (board[i][j] != '.' && !set.Add(board[i][j]))
                {
                    return false;
                }

                ++j;
                --rowCount;
            }

            return true;
        }
    }
}
