using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

//http://programmingpraxis.com/2009/04/07/flipping-pancakes/
namespace Sorting
{
    class FlippingPancakes
    {
        static void Main(string[] args)
        {
            int[] ordered = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            int[] numbers1 = { 3, 1, 2, 5, 4, 6, 9, 7, 8 };
            int[] numbers2 = { 9, 8, 6, 7, 5, 4, 2, 1, 3 };
            int[] numbers3 = { 5, 4, 3, 7, 8, 9, 1, 2, 6 };

            Debug.Assert(Enumerable.SequenceEqual(flipPancakes(ordered), ordered));
            Debug.Assert(Enumerable.SequenceEqual(flipPancakes(numbers2), ordered));
            Debug.Assert(Enumerable.SequenceEqual(flipPancakes(numbers2), ordered ));
            Debug.Assert(Enumerable.SequenceEqual(flipPancakes(numbers3), ordered ));


        }

        private static int[] flipPancakes(int[] numbers)
        {
            int biggest;
            int biggestIndex;
            for (int i = numbers.Count() - 1; i >= 0; i--)
            {
                biggest = 0;
                biggestIndex = 0;
                for (int j = i; j >= 0; j--)
                {
                    if (numbers[j] > biggest)
                    {
                        biggest = numbers[j];
                        biggestIndex = j;
                    }
                }
                if (biggestIndex != i)
                {
                    numbers = flip(numbers, biggestIndex);
                    numbers = flip(numbers, i);
                }
            }


            return numbers;
        }

        private static int[] flip(int[] numbers, int i)
        {
            int temp;
            int j = 0;
            while (j < i)
            {
                temp = numbers[j];
                numbers[j] = numbers[i];
                numbers[i] = temp;

                j++;
                i--;
            }

            return numbers;
        }
    }
}
