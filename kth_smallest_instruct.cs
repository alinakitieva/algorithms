public class Solution
{
    public string KthSmallestPath(int[] destination, int k)
    {
        int rows = destination[0];
        int columns = destination[1];

        int[,] dp = new int[rows+1, columns+1];


        // Here we are filling up the dp in such a way that each element
        // is the number of ways to reach the destination
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
            if (v == rows)  // all V's are used so we just need to add H's
            {
                answer += "H";
                h += 1;
            }
            else if (h == columns) // all H's are used so we just need to add V's
            {
                answer += "V";
                v += 1;
            }
            else
            {
                int right = dp[v, h + 1]; // right is the number of ways to reach the destination
                                          // if we move horizontally
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
