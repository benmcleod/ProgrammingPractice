using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

//http://programmingpraxis.com/2009/04/28/morse-code/
namespace MorseCode
{
    class Morsecode
    {
        static void Main(string[] args)
        {   
            string test = "•——• •—• ——— ——• •—• •— —— —— •• —• ——•  •——• •—• •— —••— •• •••";
            
            Debug.Assert(convertMorseCode(test) == "PROGRAMMING PRAXIS");

        }

        private static string convertMorseCode(string test)
        {
            string[] str = {"•—","—•••", "—•—•", "—••", "•","••—•","——•","••••","••","•———","—•—",
                               "•—••","——","—•","———","•——•","——•—","•—•","•••","—","••—","•••—",
                               "•——","—••—","—•——","——••","•————","••———","•••——","••••—",
                               "•••••","—••••","——•••","———••","————•","—————", ""};
            char[] alpha = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789 ".ToArray();


            string[] tokin = test.Split(' ');

            StringBuilder answer = new StringBuilder();
            foreach (string s in tokin)
            {
                answer.Append(alpha[Array.IndexOf(str, s)]);
            }
            return answer.ToString();
        }
    }
}
