using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Matrix
{
    public static void Main()
    {
        int rowSize;
        int columnSize;
        int matrixLength;
        int number;
        int outputRow;
        int outputColumn;

        Console.WriteLine("What is the matrix row size?");
        rowSize = int.Parse(Console.ReadLine());

        Console.WriteLine("What is the matrix column size?");
        columnSize = int.Parse(Console.ReadLine());
        
        matrixLength = rowSize * columnSize;

        Console.WriteLine("What is your number?");
        number = int.Parse(Console.ReadLine());

        outputColumn = number % columnSize;

        outputRow = number / columnSize;

        Console.WriteLine("{0} is in row {1} and column {2}", number, outputRow, outputColumn);
        Console.ReadLine();
    }
}
