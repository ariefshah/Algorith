using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Collections;
using System.Linq;


namespace Algorith
{
  static  class MyProblem60
    {

        static int[] primes;
        static List<List<int>> numbers; 
        public static void problem60(string[] args)
        {
            MyMethod();
            BruteForce();
            Sets();
        }

        private static void MyMethod()
        {
            Stopwatch clock = Stopwatch.StartNew();

                primes = ESieve(30000);
            int setofPrimes = 5;
            int iteration = 0;
            for (int i = setofPrimes; i < primes.Length; i++)
            {
                for (int j = 0; j < primes.Length; j++)
                {
                    var result = primes[i] - primes[j];
                    if (result  % 2 ==1) //odd
                    {
                        //cannot be the number
                        break;
                    }
                    else
                    {
                        numbers[iteration].Add(primes[i]);
                    }
                }

            }
        }

      

        public static void BruteForce()
        {
            var adjList = new LinkedList<int>();

            adjList.AddFirst(1);

            Stopwatch clock = Stopwatch.StartNew();

            int result = int.MaxValue;
            primes = ESieve(30000);

            HashSet<int>[] pairs = new HashSet<int>[primes.Length];

            for (int a = 1; a < primes.Length; a++)
            {
                if (primes[a] * 5 >= result) break;
                if (pairs[a] == null) pairs[a] = MakePairs(a);
                for (int b = a + 1; b < primes.Length; b++)
                {
                    if (primes[a] + primes[b] * 4 >= result) break;
                    if (!pairs[a].Contains(primes[b])) continue;
                    if (pairs[b] == null) pairs[b] = MakePairs(b);

                    for (int c = b + 1; c < primes.Length; c++)
                    {
                        if (primes[a] + primes[b] + primes[c] * 3 >= result) break;
                        if (!pairs[a].Contains(primes[c]) ||
                            !pairs[b].Contains(primes[c])) continue;
                        if (pairs[c] == null) pairs[c] = MakePairs(c);

                        for (int d = c + 1; d < primes.Length; d++)
                        {
                            if (primes[a] + primes[b] + primes[c] + primes[d] * 2 >= result) break;
                            if (!pairs[a].Contains(primes[d]) ||
                                !pairs[b].Contains(primes[d]) ||
                                !pairs[c].Contains(primes[d])) continue;
                            if (pairs[d] == null) pairs[d] = MakePairs(d);

                            for (int e = d + 1; e < primes.Length; e++)
                            {
                                if (primes[a] + primes[b] + primes[c] + primes[d] + primes[e] >= result) break;
                                if (!pairs[a].Contains(primes[e]) ||
                                    !pairs[b].Contains(primes[e]) ||
                                    !pairs[c].Contains(primes[e]) ||
                                    !pairs[d].Contains(primes[e])) continue;

                                if (result > primes[a] + primes[b] + primes[c] + primes[d] + primes[e])
                                    result = primes[a] + primes[b] + primes[c] + primes[d] + primes[e];

                                Console.WriteLine("{0} + {1} + {2} + {3} + {4} = {5}", primes[a], primes[b], primes[c], primes[d], primes[e], result);
                                break;
                            }
                        }
                    }
                }
            }

            clock.Stop();
            Console.WriteLine("Lowest sum of 5 primes {0}", result);
            Console.WriteLine("Solution took {0} ms", clock.ElapsedMilliseconds);
        }

        public  static void Sets()
        {
            Stopwatch clock = Stopwatch.StartNew();

            int result = int.MaxValue;
            primes = ESieve(30000);
            HashSet<int>[] pairs = new HashSet<int>[primes.Length];


            for (int a = 1; a < primes.Length; a++)
            {
                if (primes[a] * 5 >= result) break;
                if (pairs[a] == null) pairs[a] = MakePairs(a);
                SortedSet<int> testSet = new SortedSet<int>(pairs[a]);
                for (int b = a + 1; b < primes.Length; b++)
                {
                    if (primes[a] + primes[b] * 4 >= result) break;
                    if (!testSet.Contains(primes[b])) continue;
                    if (pairs[b] == null) pairs[b] = MakePairs(b);
                    SortedSet<int> tempA = new SortedSet<int>(testSet);
                    testSet.IntersectWith(pairs[b]);
                    if (testSet.Count == 0)
                    {
                        testSet = tempA;
                        continue;
                    }

                    for (int c = b + 1; c < primes.Length; c++)
                    {
                        if (primes[a] + primes[b] + primes[c] * 3 >= result) break;
                        if (!testSet.Contains(primes[c])) continue;
                        if (pairs[c] == null) pairs[c] = MakePairs(c);
                        SortedSet<int> tempB = new SortedSet<int>(testSet);
                        testSet.IntersectWith(pairs[c]);
                        if (testSet.Count == 0)
                        {
                            testSet = tempB;
                            continue;
                        }

                        for (int d = c + 1; d < primes.Length; d++)
                        {
                            if (primes[a] + primes[b] + primes[c] + primes[d] * 2 >= result) break;
                            if (!testSet.Contains(primes[d])) continue;
                            if (pairs[d] == null) pairs[d] = MakePairs(d);
                            SortedSet<int> tempC = new SortedSet<int>(testSet);
                            testSet.IntersectWith(pairs[d]);
                            if (testSet.Count == 0)
                            {
                                testSet = tempC;
                                continue;
                            }

                            int e = testSet.Min;

                            if (primes[a] + primes[b] + primes[c] + primes[d] + e < result)
                                result = primes[a] + primes[b] + primes[c] + primes[d] + e;

                            Console.WriteLine("{0} + {1} + {2} + {3} + {4} = {5}", primes[a], primes[b], primes[c], primes[d], e, result);

                            testSet = tempC;
                        }
                        testSet = tempB;
                    }
                    testSet = tempA;
                }
            }



            clock.Stop();
            Console.WriteLine("Lowest sum of 5 primes {0}", result);
            Console.WriteLine("Solution took {0} ms", clock.ElapsedMilliseconds);
        }

        private static HashSet<int> MakePairs(int a)
        {
            HashSet<int> pairs = new HashSet<int>();
            for (int b = a + 1; b < primes.Length; b++)
            {
                if (isPrime(concat(primes[a], primes[b])) &&
                    isPrime(concat(primes[b], primes[a])))
                    pairs.Add(primes[b]);
            }
            return pairs;
        }

        private static int concat(int a, int b)
        {
            int c = b;
            while (c > 0)
            {
                a *= 10;
                c /= 10;
            }

            return a + b;
        }


        public static int[] ESieve(int upperLimit)
        {

            int sieveBound = (int)(upperLimit - 1) / 2;
            int upperSqrt = ((int)Math.Sqrt(upperLimit) - 1) / 2;

            BitArray PrimeBits = new BitArray(sieveBound + 1, true);

            for (int i = 1; i <= upperSqrt; i++)
            {
                if (PrimeBits.Get(i))
                {
                    for (int j = i * 2 * (i + 1); j <= sieveBound; j += 2 * i + 1)
                    {
                        PrimeBits.Set(j, false);
                    }
                }
            }

            List<int> numbers = new List<int>((int)(upperLimit / (Math.Log(upperLimit) - 1.08366)));
            numbers.Add(2);
            for (int i = 1; i <= sieveBound; i++)
            {
                if (PrimeBits.Get(i))
                {
                    numbers.Add(2 * i + 1);
                }
            }

            return numbers.ToArray();
        }

        private static bool isPrime(int n)
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


        private static bool Witness(int a, int n)
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


        private static long ModularExp(int a, int b, int n)
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