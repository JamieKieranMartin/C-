using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class CommandLineArgs
{
    public static void Main(string[] args)
    {
        int length = args.Length;

        if(length <= 0)
        {
            Console.WriteLine("Please enter at least one argument.");
        }
        else
        {
            Console.WriteLine("Argument count is: {0}", length);
            for(int i=0; i < length; i++)
            {
                Console.WriteLine("Arg {0} is: {1}", i, args[i]);
            }
        }       
    }
}
