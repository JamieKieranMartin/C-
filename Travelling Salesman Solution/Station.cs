using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentCAB201
{
    class Station
    {
        public string Name { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        //Initilise new Station
        public Station(string name, int x, int y)
        {
            try
            {
                Name = name;
                X = x;
                Y = y;
            } catch (Exception e)
            {
                Console.Write("StationCreationError: ");
                throw;
            }
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
