using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

//https://code.google.com/codejam/contest/90101/dashboard#s=p0
namespace AlienLanguage
{
    class alienlanguage
    {
        static void Main(string[] args)
        {
            string[] firstLine = Console.ReadLine().Split(' ');
            int L = int.Parse(firstLine[0]);
            int D = int.Parse(firstLine[1]);
            int N = int.Parse(firstLine[2]);

            string[] knownWords = new string[D];
            for (int i = 0; i < D; i++)
            {
                knownWords[i] = Console.ReadLine();
            }

            string[] possibleWords = new string[N];
            for (int i = 0; i < N; i++)
            {
                string pattern = Console.ReadLine().Replace("(", "[").Replace(")", "]").Replace(" ","");
                int count = knownWords.Count(new Func<string, bool>(w => Regex.IsMatch(w, pattern)));
                Console.WriteLine("Case #"+i+": "+count);
            }

        }
    }
}
