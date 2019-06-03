using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class StringOrder
{
    enum Order { Precedes = -1, Equals = 0, Follows = 1 };

    public static void Main()
    {
        string nameA;
        string nameB;
        int test;
        int found = 0;
        Console.WriteLine("What is name A?");
        nameA = Console.ReadLine();
        Console.WriteLine("What is name B?");
        nameB = Console.ReadLine();
        found = nameA.IndexOf(": ");
        nameA = nameA.Substring(found + 2);
        found = nameB.IndexOf(": ");
        nameB = nameB.Substring(found + 2);
        test = nameA.CompareTo(nameB);
        Console.WriteLine("{0} {1} {2}", nameA, (Order)test, nameB);
        Console.ReadLine();
    }
}
