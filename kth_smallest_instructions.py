class Solution:
    def kthSmallestPath(self, destination: List[int], k: int) -> str:
        rows = destination[0]
        columns = destination[1]

        dp = [[0 for _ in range(columns+1)] for _ in range(rows+1)]
        # each element of dp is the number of ways to reach the destination
        for row in range(rows, -1, -1):
            for column in range(columns, -1, -1):
                if column == columns and row == rows:
                    dp[rows][columns] = 1
                elif row == rows:
                    dp[row][column] = dp[row][column+1]
                elif column == columns:
                    dp[row][column] = 1
                else:
                    dp[row][column] = dp[row][column+1] + dp[row+1][column]
        answer = ""
        V = 0
        H = 0
        while True:
            if V == rows and H == columns:
                return answer
            if V == rows:  # all V's are used so we just need to add H's
                answer += "H"
                H += 1
            elif H == columns:  # all H's are used so we just need to add V's
                answer = answer+"V"
                V += 1
            else:
                right = dp[V][H+1]
                # right is the number of ways to reach the destination
                # if we will turn right
                if k > right:
                    k -= right
                    answer = answer+"V"
                    V += 1
                else:
                    answer = answer+"H"
                    H += 1
