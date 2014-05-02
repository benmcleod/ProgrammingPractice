using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//http://programmingpraxis.com/2009/02/20/rot13/
namespace ROT13
{
    class rot13
    {
        static void Main(string[] args)
        {
            string str = "Cebtenzzvat Cenkvf vf sha!";
            char[] buffer = str.ToCharArray();
            for (int i = 0; i < buffer.Length; i++)
            {
                char letter = buffer[i];
                letter = (char)(letter + 13);
                if (letter > 'z')
                {
                    letter = (char)(letter - 26);
                }
                buffer[i] = letter;
            }
            Console.WriteLine(buffer);
        }
    }
}
