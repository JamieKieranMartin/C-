using System;
using System.Linq;

namespace RandomArray
{
    public class RandomArrayNoDuplicates
    {
        static Random rng = new Random();
        /// <summary>
        /// Creates an array with each element a unique integer
        /// between 1 and 45 inclusively.
        /// </summary>
        /// <param name="size"> length of the returned array < 45
        /// </param>
        /// <returns>an array of length "size" and each element is
        /// a unique integer between 1 and 45 inclusive </returns>
        public static int[] ArrayWithNoDuplicates(int size)
        {
            Random rand = new Random();
            int[] output = new int[size];
            int randNumber;
            for (int i = 0; i < output.Length; i++)
            {
                do
                {
                    randNumber = rand.Next(0, (size+1));
                } while (output.Contains(randNumber));
                output[i] = randNumber;
            }
            return output;
        }

        public static void Main()
        {
            
            var result = string.Join(", ", ArrayWithNoDuplicates(45));
            Console.WriteLine(result);
            Console.ReadLine();
        }
    }
}
