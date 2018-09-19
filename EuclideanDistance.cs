using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;

namespace EuclideanDistance
{
    class EuclideanDistance
    {
        static void Main(string[] args)
        {
            double lat = 48.8584;
            double lon = 2.2945;

            using (WebClient wc = new WebClient())
            {
                var client = new WebClient();
                var response = client.DownloadString("https://opensky-network.org/api/states/all"); ;

                RootObject m = JsonConvert.DeserializeObject<RootObject>(response);

                var distance = 100000000.00;
                var closestplane = new List<string>();

                foreach(List<string> plane in m.states)
                {
                    double longitude, latitude;
                    if (!(plane[5] == null || plane[6] == null))
                    {
                        longitude = double.Parse(plane[5]);
                        latitude = double.Parse(plane[6]);

                        var tempdistance = Distance(lat, lon, latitude, longitude);

                        if (tempdistance < distance)
                        {
                            distance = tempdistance;
                            closestplane = plane;
                        }
                    }
                }

                Console.WriteLine("Distance : {0}", distance);
                Console.WriteLine("Callsign : {0}", closestplane[1]);
                Console.WriteLine("Lattitude : {0}, Longitude : {1}", closestplane[6], closestplane[5]);
                Console.WriteLine("Altitude : {0}", closestplane[7]);
                Console.WriteLine("Country of origin : {0}", closestplane[2]);
                Console.WriteLine("ICAO24 ID : {0}", closestplane[0]);

            }
        }

        private static double Distance(double lat, double lon, double latitude, double longitude)
        {
            return Math.Sqrt(Math.Pow((latitude - lat), 2) + Math.Pow((longitude - lon), 2));
        }
    }

    public class RootObject
    {
        public int time { get; set; }
        public List<List<string>> states { get; set; }
    }
}
