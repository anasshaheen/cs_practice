namespace Questions.LeetCode.Arrays
{
    public class RotateImage
    {
        static void Solve(int[][] matrix)
        {
            if (matrix.Length == 0)
            {
                return;
            }

            for (var i = 0; i < matrix.Length; i++)
            {
                for (var j = i; j < matrix.Length; j++)
                {
                    var temp = matrix[i][j];
                    matrix[i][j] = matrix[j][i];
                    matrix[j][i] = temp;
                }
            }

            for (var i = 0; i < matrix.Length; i++)
            {
                for (var j = 0; j < matrix.Length / 2; j++)
                {
                    var temp = matrix[i][j];
                    matrix[i][j] = matrix[i][matrix.Length - j - 1];
                    matrix[i][matrix.Length - j - 1] = temp;
                }
            }
        }
    }
}
