using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Permutations
{
    // Helper method for outputting an array.
    private static void PrintArray(string[] array)
    {
        foreach (string element in array)
        {
            Console.Write($"{element} ");
        }
        Console.WriteLine();
    }

    // Helper method for invoking Generate.
    private static void Generate(string[] array)
    {
        Generate(array.Length, array);
    }

    private static void Generate(int k, string[] A)
    {
        if (k == 1)
        {
            PrintArray(A);
        }
        else
        {
            Generate(k - 1, A);
            for (int i = 0; i < (k - 1); i++)
            {
                if (k % 2 == 0)
                {
                    string buffer = A[i];
                    A[i] = A[k - 1];
                    A[k - 1] = buffer;
                    
                }
                else
                {
                    string buffer = A[0];
                    A[0] = A[k - 1];
                    A[k - 1] = buffer;
                }
                Generate(k - 1, A);
            }
        }
    }

    public static void Main(string[] args)
    {
        Generate(args.Length, args);
    }
}
