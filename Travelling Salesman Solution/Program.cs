using System;
using System.IO;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentCAB201
{
    class Program
    {
        //Reads Input Mail Txt and adds to list of Stations
        public static void ReadInput(ref string FILE, ref List<Station> list)
        {
            try
            {
                Console.WriteLine($"Reading input from {FILE}");
                FileStream inFile = new FileStream(FILE, FileMode.Open, FileAccess.Read);
                StreamReader reader = new StreamReader(inFile);

                string recordIn;
                recordIn = reader.ReadLine();
                while (recordIn != null)
                {
                    string[] split = recordIn.Split(' ');
                    string name = split[0];
                    int x = int.Parse(split[1]);
                    int y = int.Parse(split[2]);
                    Station station = new Station(name, x, y);
                    list.Add(station);
                    recordIn = reader.ReadLine();
                }
                inFile.Close();
                reader.Close();
                //Add final post office
                list.Add(list.ElementAt(0));

            } catch (Exception e)
            {
                Console.Write($"MailTxtReadError: in file {FILE}");
                Console.WriteLine("Please ensure argument format of 'mail.txt[input stations file] plane.txt[plane spec file] 00:00[time] -o output.txt[optional output file]");
                throw;
            }
        }

        static void Main(string[] args)
        {
            try
            {
                string INPUT_FILE = args[0], PLANE_SPEC = args[1], START_TIME = args[2];

                List<Station> stations = new List<Station>();
                ReadInput(ref INPUT_FILE, ref stations);
                Plane plane = new Plane(PLANE_SPEC);

                Tour tour = new Tour(ref stations, ref plane, ref START_TIME);

                float COMP_TIME;
                var stopwatch = new Stopwatch();
                stopwatch.Start();
                if (stations.Count > 12)
                {
                    tour.Level1();
                    tour.Level2();
                } else
                {
                    tour.Level3();
                }
                stopwatch.Stop();
                COMP_TIME = stopwatch.ElapsedMilliseconds;

                tour.CalcOverallTimes();
                tour.WriteToConsole(COMP_TIME);

                if (args.Length > 3 && args[3] == "-o")
                {
                    string OUTPUT_FILE = args[4];
                    tour.WriteToTxt(OUTPUT_FILE, COMP_TIME);
                }
            } catch (Exception e)
            {
                Console.WriteLine("Please ensure argument format of 'mail.txt[input stations file] plane.txt[plane spec file] 00:00[time] -o output.txt[optional output file]");
                Console.WriteLine($"{e.Message}");
            }

            Console.ReadLine();
        }
    }
}
