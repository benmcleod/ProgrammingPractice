using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

//http://www.reddit.com/r/dailyprogrammer/comments/1ystvb/022414_challenge_149_easy_disemvoweler/
namespace Disemvoweler
{
    class DisemVoweler
    {
        static void Main(string[] args)
        {
            string str = "did you hear about the excellent farmer who was outstanding in his field";
            string vowels = "aeiou";
            str = str.Replace(" ", "");
            Console.WriteLine(str.Where(c => !vowels.Contains(c)).ToArray());
            Console.WriteLine(str.Where(c => vowels.Contains(c)).ToArray());


        }
    }
}
