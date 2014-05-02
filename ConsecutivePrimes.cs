using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//http://programmingpraxis.com/2009/04/14/google-treasure-hunt-2008-puzzle-4/
namespace TreasureHunt2008puzzle4
{
    class ConsecutivePrimes
    {
        static void Main(string[] args)
        {

            List<int> primes = seive(10000000);

            int seven = 0;
            int seventeen = 0;
            int fortyone = 0;
            int fivehundredfortyone = 0;

            int sumSeven = 0;
            int sumSeventeen = 0;
            int sumFortyone = 0;
            int sumFivehundredfortyone = 0;

            for (int i = 0; i < 7; i++)
                sumSeven += primes[i];
            for (int i = 0; i < 17; i++)
                sumSeventeen += primes[i];
            for (int i = 0; i < 41; i++)
                sumFortyone += primes[i];
            for (int i = 0; i < 541; i++)
                sumFivehundredfortyone += primes[i];

            for (int i = 0; i < primes.Count(); i++)
            {

                while (sumSeven < primes[i])
                {
                    sumSeven = sumSeven - primes[seven] + primes[seven + 7]; 
                    seven++;
                }
                while (sumSeventeen < primes[i])
                {
                    sumSeventeen = sumSeventeen - primes[seventeen] + primes[seventeen + 17];
                    seventeen++;
                }
                while (sumFortyone < primes[i])
                {
                    sumFortyone = sumFortyone - primes[fortyone] + primes[fortyone + 41];
                    fortyone++;
                }
                while (sumFivehundredfortyone < primes[i])
                {
                    sumFivehundredfortyone = sumFivehundredfortyone - primes[fivehundredfortyone] + primes[fivehundredfortyone + 541];
                    fivehundredfortyone++;
                }

                if (primes[i] == sumSeven && primes[i] == sumSeventeen && primes[i] == sumFortyone && primes[i] == sumFivehundredfortyone)
                {
                    Console.WriteLine(primes[i]);
                    break;
                }
            }


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
