using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler
{
    class Euler1to5
    {
        static void Main(string[] args)
        {
            //long total = sumOfFiveandThree(1000000000);

            //ulong fibonacciEvenTotal = fibonacciEven(4000000);

            //int palindrome = largestPalindrome(3);

            //Debug.Assert(findLCM(new int[]{4,7,12,21,42})==84);
            
            int[] a = Enumerable.Range(1, 20).ToArray();

            int lcm = findLCM(a);


        }

        private static int findLCM(int[] p)
        {
            int total = 1;
            int[] primes = { 2, 3, 5, 7, 11, 13, 17, 19 };


            bool flag = true;
            for (int j = 0; j < primes.Count(); j++)
            {
                while (flag)
                {
                    flag = false;
                    for (int i = 0; i < p.Count(); i++)
                    {
                        if (p[i] % primes[j] == 0)
                        {
                            p[i] = p[i] / primes[j];
                            flag = true;
                        }
                    }
                    if (flag) total *= primes[j];
                }
                flag = true;
                List<int> temp = p.ToList();
                temp.RemoveAll(a => a == 1);
                p = temp.ToArray();
            }
            return total;
        }

        private static int largestPalindrome(int digits)
        {
            int result = 0;
            int test = 0;

            for (int i = 999; i > 900; i--)
            {
                for (int j = 999; j > 900; j--)
                {
                    test = i * j;
                    if (checkIfPalindrome(test))
                        if (result < test)
                            result = test;
                }
            }


            Debug.Assert(checkIfPalindrome(1001) == true);
            Debug.Assert(checkIfPalindrome(910019) == true);
            Debug.Assert(checkIfPalindrome(91019) == true);
            Debug.Assert(checkIfPalindrome(91018) == false);
            Debug.Assert(checkIfPalindrome(122) == false);

            return result;
        }

        private static bool checkIfPalindrome(int test)
        {

            var str = test.ToString();
            string rev = new string(str.ToCharArray().Reverse().ToArray());
            if (rev == str)
                return true;

            return false;

        }


        private static ulong fibonacciEven(int p)
        {
            int a = 2, b = 3;
            ulong total = 0;
            int tempA = 0;
            while (a < p)
            {
                total += (ulong)a;
                tempA = a + 2 * b;
                b = 2 * (a + b) + b;
                a = tempA;
            }

            return total;
        }

        private static long sumOfFiveandThree(long p)
        {
            List<long> values = new List<long>();

            for (long i = 3; i < p; i += 1000)
                values.Add(i);

            for (long i = 5; i < p; i += 5033)
                values.Add(i);

            List<long> distinct = values.Distinct().ToList();


            return (long)distinct.Sum();
        }
    }
}
