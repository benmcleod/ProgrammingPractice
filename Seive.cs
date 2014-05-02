using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace seiveoferatosthenes
{
    class Seive
    {
        static void Main(string[] args)
        {
            Debug.Assert(seive(2).Count == 1);
            Debug.Assert(seive(3).Count == 2);
            Debug.Assert(seive(4).Count == 2);
            Debug.Assert(seive(9).Count == 4);
            Debug.Assert(seive(30).Count == 10);

        }

        static List<int> seive(int i)
        {
            int[] num = new int[i + 1];
            num[0] = 1;
            num[1] = 1;
            if (i < 2)
            {
                return new List<int>();
            }
            else if (i == 2)
            {
                List<int> two = new List<int>();
                two.Add(2);
                return two;

            }
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

            List<int> primes = new List<int>();
            for (int p = 0; p <= i; p++)
            {
                if (num[p] == 0) primes.Add(p);
            }
            return primes;
        }
    }
}
