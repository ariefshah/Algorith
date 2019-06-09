using System;
using System.Diagnostics;
using System.Numerics;


namespace Algorith
{
    class Problem57
    {

        public static void Run(string[] args)
        {
            new Problem57().BruteForce();
        }

        public void BruteForce()
        {
            Stopwatch clock = Stopwatch.StartNew();

            const int limit = 1000;
            int result = 0;

            BigInteger den = 2;
            BigInteger num = 3;

            for (int i = 1; i < limit; i++)
            {
                num += 2 * den;
                den = num - den;
                if (((int)BigInteger.Log10(num)) > ((int)BigInteger.Log10(den))) result++;
            }


            clock.Stop();
            Console.WriteLine("The number of iterations with more digits in numerator is {0}", result);
            Console.WriteLine("Solution took {0} ms", clock.ElapsedMilliseconds);
        }

    }
}