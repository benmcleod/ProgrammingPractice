using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//http://programmingpraxis.com/2009/02/20/a-self-reproducing-program/
namespace SelfReproducingProgram
{
    class quine
    {
        static void Main(string[] args)
        {
            char q = (char)34;
            String[] s = {
"using System;",
"using System.Collections.Generic;",
"using System.Linq;",
"using System.Text;",
"",
"namespace SelfReproducingProgram",
"{",
"  class quine",
"  {",
"      static void Main(string[] args)",
"      {",
"          char q = (char)34;",
"          String[] s = {",
"          for(int i =0;i<12;i++)",
"              Console.WriteLine(s[i]);",
"          for (int j = 0; j < s.Length; j++)",
"              Console.WriteLine(q + s[j] + q + ';');",
"          for (int j = 14; j < s.Length; j++)",
"              Console.WriteLine(s[j]);",
"          }",
"      }",
"  }",
"};",
            };
            for(int i =0;i<13;i++)
                Console.WriteLine(s[i]);
            for (int j = 0; j < s.Length; j++)
                Console.WriteLine(q + s[j] + q + ',');
            for (int j = 12; j < s.Length; j++)
                Console.WriteLine(s[j]);

        }
    }
}
