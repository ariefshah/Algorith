using System;
using System.Diagnostics;
using System.Numerics;


namespace Algorith
{
    class Problem56
    {


        public static void Run(string[] args)
        {
            new Problem56().BruteForce();
        }


        public void BruteForce()
        {
            Stopwatch clock = Stopwatch.StartNew();

            const int limit = 100;
            int result = 0;

            for (int a = limit - 1; a > 0; a--)
            {
                for (int b = limit - 1; b > 0; b--)
                {
                    BigInteger number = BigInteger.Pow(a, b);
                    if (((int)BigInteger.Log10(number)) * 9 < result) break;

                    int sum = DigitSum(number);
                    if (sum > result) result = sum;
                }
            }

            clock.Stop();
            Console.WriteLine("The largest digit sum of a^b with a, b < {0} is {1}", limit, result);
            Console.WriteLine("Solution took {0} ms", clock.ElapsedMilliseconds);
        }


        private int DigitSum(BigInteger number)
        {
            char[] k = number.ToString().ToCharArray();
            int ds = 0;

            for (int i = 0; i < k.Length; i++)
            {
                ds += Convert.ToInt32(k[i].ToString());
            }

            return ds;
        }

    }
}