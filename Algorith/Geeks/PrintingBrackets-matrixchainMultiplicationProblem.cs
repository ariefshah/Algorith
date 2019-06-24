using System;
using System.Collections.Generic;
using System.Text;

namespace Algorith.Geeks
{
    class PrintingBrackets_matrixchainMultiplicationProblem
    {
      public static int MatrixChainOrder(int []p, int n)
        {

            int[,] m = new int[n, n];

            int j,q;

            for (int i = 1; i < n; i++)
            {
                m[i, i] = 0;

            }

            for (int L = 2; L < n; L++)
            {
                for (int i = 1; i < n-L+1; i++)
                {
                    j = i + L - 1;
                    m[i, j] = int.MaxValue;
                    for (int k = i; k <= j-1; k++)
                    {
                        q = m[i,k] + m[k + 1, j] + p[i - 1] * p[k] * p[j];

                        if (q < m[i, j])
                            m[i, j] = q;

                    }
                }
            }
            return m[1,n-1];
        }
    }
}
