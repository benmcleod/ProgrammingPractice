using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//http://www.reddit.com/r/dailyprogrammer/comments/20l2it/17042014_challenge_153_easy_pascals_pyramid/
namespace PascalsPyramid
{
    class Pascalspyramid
    {
        static void Main(string[] args)
        {
            ulong n = 14 - 1;


            for (ulong row = 0; row <= n; row++)
            {
                for (ulong col = 0; col <= row; col++)
                {
                    Console.Write(getNumber(row-col,n-row,col) + "\t");

                }
                Console.WriteLine();
            }

        }

        static ulong getNumber(ulong a, ulong b, ulong c)
        {
            return Factorial(a + b + c) / (Factorial(a) * Factorial(b) * Factorial(c));
        }

        static ulong Factorial(ulong input)
        {
            ulong answer = 1;

            if (input > 0)
            {
                ulong count = 1;
                while (count <= input)
                {
                    if (count == 1)
                    {
                        answer = 1;
                        count++;
                    }
                    else
                    {
                        answer = count * answer;
                        count++;
                    }
                }
            }


            return answer;
        }

    }

}
