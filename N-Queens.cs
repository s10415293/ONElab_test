using System;

public class Solution
{
    public IList<IList<string>> SolveQueens(int n)
    {
        List<IList<string>> queens = new List<IList<string>>();
        dfs(queens, new int[n], 0);
        return queens;
    }

    private static void dfs(List<IList<string>> all, int[] result, int row)  // all:儲存所有方案的list, row:當前處理的行
    { 
        if (row == result.Length)
        {
            List<string> tmpLst = new List<string>();
            for (int j = 0; j < result.Length; j++)
            {
                StringBuilder sb = new StringBuilder();
                for (int k = 0; k < result.Length; k++)
                    if (result[j] == k) sb.Append("Q");
                    else sb.Append(".");
                tmpLst.Add(sb.ToString());
            }
            all.Add(tmpLst);
            return;
        }

        for (int i = 0; i < result.Length; i++)
        {
            bool bAvail = true;
            for (int j = 0; j < row; j++)
                if (result[j] == i || Math.Abs(result[j] - i) == row - j) bAvail = false;
            if (bAvail)
            {
                int[] result2 = new int[result.Length];
                Array.Copy(result, result2, result.Length);
                result2[row] = i;
                dfs(all, result2, row + 1);
            }
        }
        return;
    }
}

