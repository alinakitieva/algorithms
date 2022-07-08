public class Solution
{
    public string KthSmallestPath(int[] destination, int k)
    {
        int rows = destination[0];
        int columns = destination[1];

        int[,] dp = new int[rows+1, columns+1];

        for (int row=rows; row>-1; row--)
        {
            for (int column=columns; column>-1; column--)
            {
                if (column == columns && row == rows)
                    dp[row, column] = 1;
                else if (column == columns)
                    dp[row, column] = 1;
                else if (row == rows)
                    dp[row, column] = dp[row, column + 1];
                else
                    dp[row, column] = dp[row, column + 1] + dp[row + 1, column];
            }
        }

        string answer = "";
        int v = 0;
        int h = 0;
        while (true)
        {
            if (v == rows && h == columns)
                return answer;
            if (v == rows)
            {
                answer += "H";
                h += 1;
            }
            else if (h == columns)
            {
                answer += "V";
                v += 1;
            }
            else
            {
                int right = dp[v, h + 1];
                if (k > right)
                {
                    k -= right;
                    answer += "V";
                    v += 1;
                }
                else
                {
                    answer += "H";
                    h += 1;
                }
            }


        }
    }
}
