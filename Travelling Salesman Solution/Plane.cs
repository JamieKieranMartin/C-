using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentCAB201
{
    class Plane
    {
        public float RANGE { get; set; }
        public float SPEED { get; set; }
        public float TAKE_OFF_TIME { get; set; }
        public float LANDING_TIME { get; set; }
        public float REFUEL_TIME { get; set; }

        /// <summary>
        /// Read from a plane specification file. Format: range speed take-off-time landing-time refuel-time
        /// </summary>
        /// <param name="SPECIFICATION"></param>
        public Plane(string SPECIFICATION)
        {
            try
            {
                // open file and attempt to read
                FileStream specFile = new FileStream(SPECIFICATION, FileMode.Open, FileAccess.Read);
                StreamReader reader = new StreamReader(specFile);
                string recordIn;
                recordIn = reader.ReadLine();
                // splits each line into parts and assigns stores in variable names
                while (recordIn != null)
                {
                    string[] split = recordIn.Split(' ');
                    RANGE = Single.Parse(split[0]);
                    SPEED = Single.Parse(split[1]);
                    TAKE_OFF_TIME = Single.Parse(split[2]);
                    LANDING_TIME = Single.Parse(split[3]);
                    REFUEL_TIME = Single.Parse(split[4]);
                    recordIn = reader.ReadLine();
                }
                // close file
                specFile.Close();
                reader.Close();
            } catch (Exception e)
            {
                Console.Write($"PlaneInitialisationError: in file {SPECIFICATION}");
                Console.WriteLine("Please ensure argument format of 'mail.txt[input stations file] plane.txt[plane spec file] 00:00[time] -o output.txt[optional output file]");
                throw;
            }
            
        }
        // get the time duration of refueling 
        public float GetRefuelTime()
        {
            return REFUEL_TIME;
        }
        // get the range of the plane in time
        public float GetRange()
        {
            return RANGE;
        }
    }
}
