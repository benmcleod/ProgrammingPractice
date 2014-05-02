using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

//http://programmingpraxis.com/2009/03/23/binary-search/
namespace BinarySearch
{
    
    class BinarySearch
    {
        static void Main(string[] args)
        {
            Debug.Assert(binSearch(new List<int>(new int[] { 2, 12, 34, 41 }), 41) == 3);
            Debug.Assert(binSearch(new List<int>(new int[] { 2, 12, 34, 41 }), 13) == -1);
            Debug.Assert(binSearch(new List<int>(new int[] { 2, 12, 34, 41 }), 50) == -1);
            Debug.Assert(binSearch(new List<int>(new int[] { 2, 12, 34, 41 }), 2) == 0);
            Debug.Assert(binSearch(new List<int>(new int[] { 2, 12, 34, 41 }), 34) == 2);
            Debug.Assert(binSearch(new List<int>(new int[] { 2, 15, 20, 34, 41 }), 15) == 1);
            Debug.Assert(binSearch(new List<int>(new int[] { 2, 15, 20, 34, 41 }), 34) == 3);
            Debug.Assert(binSearch(new List<int>(new int[] { 2, 15, 20, 34, 41 }), 1) == -1);
            Debug.Assert(binSearch(new List<int>(new int[] { }), 1) == -1);
            Debug.Assert(binSearch(new List<int>(new int[] { 0}), 1) == -1);




        }


        static int binSearch(List<int> list, int target)
        {
            int first = 0;
            int last = list.Count - 1;

            while (first <= last)
            {

                int half = (int)Math.Floor((double)((last - first) / 2) + first);


                if (list.ElementAt(half).Equals(target))
                {
                    return half;
                }
                else if (list.ElementAt(half) > target)
                {
                    last = half - 1;
                }
                else if (list.ElementAt(half) < target)
                {
                    first = half + 1;
                }
            }
            return -1;

        }

    }
}
