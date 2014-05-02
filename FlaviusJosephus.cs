using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//http://programmingpraxis.com/2009/02/19/flavius-josephus/
namespace FlaviusJosephus
{
    class FlaviusJosephus
    {
        static void Main(string[] args)
        {

            List<int> test = josephus(31, 3);


        }

        static List<int> josephus(int n, int m)
        {
            List<int> joe = new List<int>(n);
            for (int i = 1; i <= n; i++)
                joe.Add(i);

            List<int> result = new List<int>(n);

            int next = 0;
            while (joe.Count > 1)
            {
                next += m - 1;
                if (next > joe.Count)
                {
                    next -= joe.Count;
                }
                result.Add(joe.ElementAt(next));
                joe.RemoveAt(next);

            }

            return result;
        }
    }
}
