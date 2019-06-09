using System;
using System.Diagnostics;


namespace Algorith
{
    class Problem58
    {


        public static void Run(string[] args)
        {
            var perc = 0.10;
            new Problem58().TrialDivision(perc);
            new Problem58().MillerRabin(perc);
        }

        public void TrialDivision(double perc)
        {
            Stopwatch clock = Stopwatch.StartNew();

            int noOfPrimes = 3;
            int sl = 2;
            int c = 9;

            while (((double)noOfPrimes) / (2 * sl + 1) > perc)
            {
                sl += 2;
                for (int i = 0; i < 3; i++)
                {
                    c += sl;
                    if (isPrime(c)) noOfPrimes++;
                }
                c += sl;
            }

            clock.Stop();
            Console.WriteLine("The sidelength of the spiral when the ratio falls below 10% is {0}", sl + 1);
            Console.WriteLine("Solution took {0} ms", clock.ElapsedMilliseconds);
        }

        private bool isPrime(int n)
        {
            if (n <= 1) return false;
            if (n == 2) return true;
            if (n % 2 == 0) return false;
            if (n < 9) return true;
            if (n % 3 == 0) return false;

            long counter = 5;
            while ((counter * counter) <= n)
            {
                if (n % counter == 0) return false;
                if (n % (counter + 2) == 0) return false;
                counter += 6;
            }

            return true;
        }


        public void MillerRabin(double perc)
        {
            Stopwatch clock = Stopwatch.StartNew();

            int noOfPrimes = 3;
            int sl = 2;
            int c = 9;

            while (((double)noOfPrimes) / (2 * sl + 1) > perc)
            {
                sl += 2;
                for (int i = 0; i < 3; i++)
                {
                    c += sl;
                    if (isPseudoPrime(c)) noOfPrimes++;
                }
                c += sl;
            }

            clock.Stop();
            Console.WriteLine("The sidelength of the spiral when the ratio falls below 10% is {0}", sl + 1);
            Console.WriteLine("Solution took {0} ms", clock.ElapsedMilliseconds);
        }


        private bool isPseudoPrime(int n)
        {
            if (n <= 1) return false;
            if (n == 2) return true;
            if (n % 2 == 0) return false;
            if (n < 9) return true;
            if (n % 3 == 0) return false;
            if (n % 5 == 0) return false;

            int[] ar = new int[] { 2, 3 };
            for (int i = 0; i < ar.Length; i++)
            {
                if (Witness(ar[i], n)) return false;
            }
            return true;
        }


        private bool Witness(int a, int n)
        {
            int t = 0;
            int u = n - 1;
            while ((u & 1) == 0)
            {
                t++;
                u >>= 1;
            }

            long xi1 = ModularExp(a, u, n);
            long xi2;

            for (int i = 0; i < t; i++)
            {
                xi2 = xi1 * xi1 % n;
                if ((xi2 == 1) && (xi1 != 1) && (xi1 != (n - 1))) return true;
                xi1 = xi2;
            }
            if (xi1 != 1) return true;
            return false;
        }


        private long ModularExp(int a, int b, int n)
        {
            long d = 1;
            int k = 0;
            while ((b >> k) > 0) k++;

            for (int i = k - 1; i >= 0; i--)
            {
                d = d * d % n;
                if (((b >> i) & 1) > 0) d = d * a % n;
            }

            return d;
        }
    }
}