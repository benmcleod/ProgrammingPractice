using System;
using System.Diagnostics;
using System.Linq;

namespace BadSorting
{
    class Badsorting
    {
        static void Main(string[] args)
        {
            Debug.Assert(StoogeSort(new[] { 1, 2, 3, 4, 6, 5 }).SequenceEqual(new[] { 1, 2, 3, 4, 5, 6 }));
            Debug.Assert(StoogeSort(new[] { 1 }).SequenceEqual(new[] { 1 }));
            Debug.Assert(StoogeSort(new[] { 2, 1 }).SequenceEqual(new[] { 1, 2 }));
            Debug.Assert(StoogeSort(new[] { 6, 5, 4, 3, 2, 1 }).SequenceEqual(new[] { 1, 2, 3, 4, 5, 6 }));
            Debug.Assert(StoogeSort(new int[] { }).SequenceEqual(new int[] { }));
            Debug.Assert(StoogeSort(new[] { 1, 3, 4, 2, 5 }).SequenceEqual(new[] { 1, 2, 3, 4, 5 }));

            Debug.Assert(BogoSort(new[] { 1, 2, 3, 4, 6, 5 }).SequenceEqual(new[] { 1, 2, 3, 4, 5, 6 }));
            Debug.Assert(BogoSort(new[] { 1 }).SequenceEqual(new[] { 1 }));
            Debug.Assert(BogoSort(new[] { 2, 1 }).SequenceEqual(new[] { 1, 2 }));
            Debug.Assert(BogoSort(new[] { 6, 5, 4, 3, 2, 1 }).SequenceEqual(new[] { 1, 2, 3, 4, 5, 6 }));
            Debug.Assert(BogoSort(new int[] { }).SequenceEqual(new int[] { }));
            Debug.Assert(BogoSort(new[] { 1, 3, 4, 2, 5 }).SequenceEqual(new[] { 1, 2, 3, 4, 5 }));

        }

        private static int[] BogoSort(int[] p)
        {
            Random rnd = new Random();

            while (true)
            {

                int[] temp = p.OrderBy(x => rnd.Next()).ToArray();
                if (IsSorted(temp))

                    return temp;
            }
        }

        private static bool IsSorted(int[] temp)
        {
            for (int i = 1; i < temp.Length; i++)
            {
                if (temp[i - 1] > temp[i]) return false;
            }
            return true;
        }

        private static int[] StoogeSort(int[] sortInts)
        {
            int count = sortInts.Length;

            if (count < 2)
                return sortInts;

            if (count < 3)
            {
                if (sortInts[0] > sortInts[1])
                {
                    int temp = sortInts[0];
                    sortInts[0] = sortInts[1];
                    sortInts[1] = temp;
                }

                return sortInts;
            }

            var twoThirds = (int)Math.Ceiling((double)count * 2 / 3);
            var oneThirds = (int)Math.Floor((double)count / 3);

            Array.Sort(sortInts, 0, twoThirds);
            Array.Sort(sortInts, oneThirds, twoThirds);
            Array.Sort(sortInts, 0, twoThirds);

            return sortInts;
        }
    }
}
