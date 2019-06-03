using System;

class MatrixLibrary
{
    public static string MatrixToString(int[,] matrixInput)
            {
                string output = "";
                int cell = 0;
                int num_rows = matrixInput.GetLength(0);
                int num_cols = matrixInput.GetLength(1);
                
                for (int y = 0; y < num_rows; y++)
                {
                    for (int x = 0; x < num_cols; x++)
                    {
                        cell = matrixInput[y, x];
                        output = output + string.Format("{0,-4}", cell);
                    }
                    output = output + "\n";
                }
                
                return output;
                                
            }

    public static int[,] MatrixMultiply(int[,] matrix1, int[,] matrix2)
            {
                int num_rows = matrix1.GetLength(0);
                int num_cols = matrix2.GetLength(1);
                int n = matrix1.GetLength(1);

                int[,] output = new int[num_rows, num_cols];

                for (int y = 0; y < num_rows; y++)
                {
                    for (int x = 0; x < num_cols; x++)
                    {
                        output[y, x] = 0;
                        for (int m = 0; m < n; m++)
                        {
                            output[y, x] += matrix1[y, m] * matrix2[m, x];
                        }
                    }
                }

                return output;
            }

    //static void Main(string[] args)
    //{
    //    int[,] matrixone = new int[,]
    //    {
    //        {0, 1, 2},
    //        {3, 4, 5}
    //    };
    //    int[,] matrixtwo = new int[,]
    //    {
    //        {0, 1},
    //        {2, 3},
    //        {4, 5}
    //    };
    //    Console.WriteLine(MatrixToString(MatrixMultiply(matrixone, matrixtwo)));
    //    Console.ReadLine();
    //}
}
