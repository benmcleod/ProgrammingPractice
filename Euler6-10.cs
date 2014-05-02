using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler6_10
{
    class Program
    {
        static void Main(string[] args)
        {
            //https://projecteuler.net/problem=6
            //int result = sumSquareDifference(100);

            //https://projecteuler.net/problem=7
            //long result = nthPrimeNumber(10001);
            //Debug.Assert(result == 104743);

            //https://projecteuler.net/problem=8
            //int result = largestProductinaSeries();

            //https://projecteuler.net/problem=9
            //int result = pythagoreanTriplet(1000);

            //https://projecteuler.net/problem=10
            //ulong result = sumOfPrimes(2000000);

        }

        private static ulong sumOfPrimes(int i)
        {
            int[] num = new int[i + 1];
            num[0] = 1;
            num[1] = 1;

            if (i < 2) return 0;

            else if (i == 2) return 1;

            else
            {
                for (int k = 2; k < (int)Math.Sqrt(i + 1) + 1; k++)
                {
                    if (num[k] == 0)
                    {
                        for (int j = k * k; j < i + 1; j += k)
                        {
                            num[j] = 1;
                        }
                    }
                }

            }

            List<long> primes = new List<long>();
            for (int p = 0; p <= i; p++)
            {
                if (num[p] == 0) primes.Add(p);
            }

            return (ulong)primes.Sum();
        }

        private static int pythagoreanTriplet(int p)
        {
            int result = 0;
            

            for (int a = 333; a > 0; a--)
            {
                int b = 334;
                int c = p - a - b;
                while (b < c)
                {
                    if (Math.Pow(a,2) + Math.Pow(b,2) == Math.Pow(c,2))
                    {
                        return a * b * c;
                    }
                    b++;
                    c--;
                }

            }


            return result;
        }

        private static int largestProductinaSeries()
        {
            int result = 0;

            string digits = "73167176531330624919225119674426574742355349194934" +
                "96983520312774506326239578318016984801869478851843" +
                "85861560789112949495459501737958331952853208805511" +
                "12540698747158523863050715693290963295227443043557" +
                "66896648950445244523161731856403098711121722383113" +
                "62229893423380308135336276614282806444486645238749" +
                "30358907296290491560440772390713810515859307960866" +
                "70172427121883998797908792274921901699720888093776" +
                "65727333001053367881220235421809751254540594752243" +
                "52584907711670556013604839586446706324415722155397" +
                "53697817977846174064955149290862569321978468622482" +
                "83972241375657056057490261407972968652414535100474" +
                "82166370484403199890008895243450658541227588666881" +
                "16427171479924442928230863465674813919123162824586" +
                "17866458359124566529476545682848912883142607690042" +
                "24219022671055626321111109370544217506941658960408" +
                "07198403850962455444362981230987879927244284909188" +
                "84580156166097919133875499200524063689912560717606" +
                "05886116467109405077541002256983155200055935729725" +
                "71636269561882670428252483600823257530420752963450";

            Queue<int> q = new Queue<int>();
            int start = 0;
            while (start < 4)
            {
                q.Enqueue(int.Parse(digits.Substring(start++, 1)));
            }

            for (int i = 5; i < digits.Count(); i++)
            {
                q.Enqueue(int.Parse(digits.Substring(i, 1)));

                int p = Product(q);
                if (result < p) result = p;

                q.Dequeue();
            }
            return result;
        }

        private static int Product(Queue<int> q)
        {
            int total = 1;
            foreach (int n in q)
            {
                total *= n;
            }

            return total;
        }

        private static long nthPrimeNumber(long p)
        {
            long result = 0;
            long primeCount = 0;
            long prime = 2;

            while (primeCount < p)
            {
                if (Prime(prime))
                {
                    result = prime;
                    primeCount++;
                }
                prime++;
            }


            return result;
        }

        private static bool Prime(long prime)
        {

            if (prime == 2) return true;
            else if (prime % 2 == 0 || prime == 1) return false;

            long sqr = (long)Math.Sqrt(prime) + 1;
            for (int i = 3; i <= sqr; i++)
            {
                if (prime % i == 0) return false;
            }
            return true;
        }

        private static int sumSquareDifference(int count)
        {
            int total = 0;
            for (int i = 1; i <= count; i++)
            {
                for (int j = 1; j <= count; j++)
                {
                    if (i != j)
                        total += i * j;
                }
            }

            int total2 = (int)Math.Pow(Enumerable.Range(1, count).Sum(), 2);
            foreach (var v in Enumerable.Range(1, count))
            {
                total2 -= (int)Math.Pow(v, 2);
            }
            Debug.Assert(total == total2);

            return total;
        }
    }
}
