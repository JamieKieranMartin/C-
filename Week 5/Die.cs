using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DieRoller
{
    /// <summary>
    /// Represents one die (singular of dice) with faces showing values between
    /// 1 and the number of faces on the die.
    /// </summary>
    public class Die
    {
        private int numFaces = 6;
        private int faceValue = 1;
        // Implement your 'Die' class here

        Random random = new Random();


        public Die()
        {
            this.numFaces = 6;
        }

        public Die(int faces)
        {
            if (faces >= 3)
            {
                this.numFaces = faces;
            }
        }

        public void RollDie()
        {
            
            this.faceValue = random.Next(1, this.numFaces+1);
        }

        public int GetFaceValue()
        {
            return this.faceValue;
        }

        public int GetNumFaces()
        {
            return this.numFaces;
        }




    }// end Class Die

    public class Program
    {
        public static void Main()
        {
            // This will not be called by the AMS, however you may want to test your Die class here.
            Die myDie = new Die();
            Console.WriteLine("{0}", myDie.GetFaceValue());
            Console.WriteLine("{0}", myDie.GetNumFaces());
            Console.WriteLine();
            for (int i = 0; i < 1000; i++)
            {
                myDie.RollDie();
                Console.WriteLine("{0}", myDie.GetFaceValue());
            }
            //Console.WriteLine();
            //Die myDie2 = new Die(10);
            //Console.WriteLine("{0}", myDie2.GetFaceValue());
            //Console.WriteLine("{0}", myDie2.GetNumFaces());
            //Console.WriteLine();

            //for (int i = 0; i < 1000; i++)
            //{
            //    myDie.RollDie();
            //    Console.WriteLine("{0}", myDie.GetFaceValue());
            //}
            Console.ReadLine();

        }
    }
}
