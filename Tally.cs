using System;
using System.Linq;
using Newtonsoft.Json;

namespace TallyProgram
{
    class Tally
    {
        static void Main(string[] args)
        {

            TallyString("EbAAdbBEaBaaBBdAccbeebaec");

            TallyStringLinq("EbAAdbBEaBaaBBdAccbeebaec");
            

        }



        private static void TallyStringLinq(string v)
        {
            var scores = v
                .Where(char.IsLetter)
                .GroupBy(x => x)
                .Select(x => new { character = x.First().ToString(), score = (char.IsLower(x.First())) ? x.Count() : -1 * x.Count() })
                .GroupBy(x => x.character.ToLower())
                .Select(x => new { player = x.First().character.ToLower(), score = x.Sum(xx => xx.score) })
                .OrderByDescending(x => x.score);


            Console.WriteLine(string.Join(", ", scores.Select(x => string.Format("{0}:{1}", x.player, x.score))));

        }

        private static void TallyString(string a)
        {
            KeyVal[] i = new KeyVal[5];
            i[0] = new KeyVal('a', 0);
            i[1] = new KeyVal('b', 0);
            i[2] = new KeyVal('c', 0);
            i[3] = new KeyVal('d', 0);
            i[4] = new KeyVal('e', 0);

            foreach (var c in a)
            {
                if ((int)c >= (int)'a')
                {
                    i[(int)c - (int)'a'].Count++;
                }
                else i[(int)c - (int)'A'].Count--;
            }

            Array.Sort(i);

            Console.WriteLine(string.Join<KeyVal>(", ", i));
        }
    }
    

    public class KeyVal : IComparable<KeyVal>
    {
        public char Id { get; set; }
        public int Count { get; set; }

        public KeyVal() { }

        public KeyVal(char id, int count)
        {
            this.Id = id;
            this.Count = count;
        }

        public int CompareTo(KeyVal other)
        {
            if (this.Count == other.Count)
            {
                return this.Id.CompareTo(other.Id);
            }
            return other.Count.CompareTo(this.Count);
        }

        public override string ToString()
        {
            return string.Format(Id + ":" + Count);
        }
    }
}
