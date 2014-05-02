using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//http://www.reddit.com/r/dailyprogrammer/comments/1s6484/120513_challenge_138_intermediate_overlapping/
namespace AreaOfIntersectingCircles
{
    class Areaofintersectingcircles
    {
        static void Main(string[] args)
        {

            double x = Double.Parse(Console.ReadLine());
            double y = Double.Parse(Console.ReadLine());
            double u = Double.Parse(Console.ReadLine());
            double w = Double.Parse(Console.ReadLine());

            double totalArea = 2 * Math.PI;
            double distance = Math.Sqrt(Math.Pow(Math.Abs(x-u),2)  + Math.Pow(Math.Abs(y-w),2));

            if (distance < 2)
            {
                double angle = 2 * Math.Acos(distance / 2);
                double overlap = angle - Math.Sin(angle);
                totalArea -= overlap;
            }
            Console.WriteLine(totalArea);

        }
    }
}
