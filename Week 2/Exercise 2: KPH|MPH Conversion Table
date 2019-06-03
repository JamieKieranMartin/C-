using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class MilesPerHourTable
{
    public static void Main()
    {
        string input = "";
        while (!(input == "q"))
        {
            int max = 0;
            Console.Write("Enter row count or quit(q): ");
            input = Console.ReadLine();
            if (input != "q")
            {
                int.TryParse(input, out max);

                Console.WriteLine("MPH\tKPH");

                int mph = 15;
                double kph = mph / 0.62137;

                for (int i = 1; i <= max; ++i)
                {
                    Console.WriteLine("{0}\t{1:0.00}", mph, kph);
                    mph = mph + 10;
                    kph = mph / 0.62137;

                }
            }
        }
    }
}
