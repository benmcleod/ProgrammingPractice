using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace Bingo
{
    //http://programmingpraxis.com/2009/02/19/bingo/
    class PlayBingo
    {
        static void Main(string[] args)
        {
            double score = 0;
            Random rng = new Random();
            int numruntimes = 10000;


            Stopwatch sw = new Stopwatch();

            sw.Start();

            for (int i = 0; i < numruntimes; i++)
            {
                score += PlayBingo(rng);
            }

            sw.Stop();

            score = score / numruntimes;

            Console.WriteLine(score + " " + sw.ElapsedMilliseconds);

            

        }

        static int PlayBingo(Random rng)
        {
            int[,] card = new int[5, 5];

            int lowest = 75;
            int highest = 0;

            var fullCol = new int[15];

            var allNumbers = new int[75];

            for (int i = 1; i <= 75; i++)
            {
                allNumbers[i - 1] = i;
            }

            rng.Shuffle(allNumbers);

            for (int biggame = 0; biggame < 500; biggame++)
            {


                for (int j = 0; j < 5; j++)
                {

                    for (int i = 1; i <= 15; i++)
                    {
                        fullCol[i - 1] = i + (15 * j);
                    }

                    rng.Shuffle(fullCol);

                    for (int k = 0; k < 5; k++)
                    {
                        if (j == 2 && k == 2) card[j, k] = 0;
                        card[j, k] = Array.IndexOf(allNumbers, fullCol[k]) - 1;
                    }
                }


                //find fastest finish
                #region

                for (int i = 0; i < 5; i++)
                {
                    highest = 0;

                    for (int j = 0; j < 5; j++)
                    {
                        if (card[i, j] > highest) highest = card[i, j];
                    }

                    if (lowest > highest) lowest = highest;
                }

                for (int j = 0; j < 5; j++)
                {
                    highest = 0;

                    for (int i = 0; i < 5; i++)
                    {
                        if (card[i, j] > highest) highest = card[i, j];
                    }

                    if (lowest > highest) lowest = highest;
                }


                highest = 0;
                for (int i = 0; i < 5; i++)
                {
                    if (card[i, i] > highest) highest = card[i, i];
                }
                if (lowest > highest) lowest = highest;


                highest = 0;
                for (int i = 0; i < 5; i++)
                {
                    if (card[i, 4 - i] > highest) highest = card[i, 4 - i];
                }
                if (lowest > highest) lowest = highest;
                #endregion

            }

            return lowest;
        }
    }

    static class RandomExtensions
    {
        public static void Shuffle<T>(this Random rng, T[] array)
        {
            int n = array.Length;
            while (n > 1)
            {
                int k = rng.Next(n--);
                T temp = array[n];
                array[n] = array[k];
                array[k] = temp;
            }
        }
    }

}
