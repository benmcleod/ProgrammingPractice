using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//http://www.reddit.com/r/dailyprogrammer/comments/236va2/4162014_challenge_158_intermediate_part_1_the/
namespace ASCIIArchitect
{
    class AsciiArchitect
    {
        public static string j = "++--***...";
        static void Main(string[] args)
        {

            string airplane = "2d3a3a3b3b3b3c3c3ciji3c3c3c3b3b3b3a3a2d";
            string gatehouse = "gfgfg2c3b3b2cgfgfg";
            string[] asciiArray;


            asciiArray = buildArray(airplane);
            printascii(asciiArray);


            asciiArray = buildArray(gatehouse);
            printascii(asciiArray);

        }

        private static string[] buildArray(string input)
        {
            List<string> output = new List<string>();

            while (input.Length > 0)
            {
                int i = 0;
                char first = input.ElementAt(0);
                input = input.Remove(0, 1);

                if (int.TryParse(first.ToString(), out i))
                {
                    first = input.ElementAt(0);
                    input = input.Remove(0, 1);
                }

                int a = (int)char.ToLower(first) - 96;
                output.Add("".PadLeft(i) + j.Substring(0, a));


            }
            return output.ToArray();
        }

        private static void printascii(string[] output)
        {
            for (int j = 10; j > 0; j--)
            {
                for (int i = 0; i < output.Length; i++)
                {
                    if (output[i].Length == j)
                    {
                        Console.Write(output[i].ElementAt(j-1));
                        output[i] = output[i].Remove(j-1, 1);
                    }
                    else Console.Write(" ");
                }
                Console.WriteLine();
            }

            Console.WriteLine();
        }
    }
}
