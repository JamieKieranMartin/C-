using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DiceRoller
{

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
            this.faceValue = random.Next(1, this.numFaces + 1);
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

    public class Dice
    {
        // Implement your 'Dice' class here
        // ...
        Die[] myDice;
        public Dice(int dice)
        {
            this.myDice = new Die[dice];
            for (int i = 0; i < this.myDice.Length; i++)
            {
                this.myDice[i] = new Die();
                System.Threading.Thread.Sleep(20);
            }
        }

        public Dice(int dice, int faces)
        {
            this.myDice = new Die[dice];
            for (int i = 0; i < this.myDice.Length; i++)
            {
                this.myDice[i] = new Die(faces);
                System.Threading.Thread.Sleep(20);
            }
        }

        public void RollDice()
        {
            for (int i = 0; i < this.myDice.Length; i++)
            {
                this.myDice[i].RollDie();
                
            }
        }

        public int GetFaceValue()
        {
            int output = 0;
            for (int i = 0; i < this.myDice.Length; i++)
            {
                output += this.myDice[i].GetFaceValue();
                
            }
            return output;
        }

    }// end class Dice

    public class Program
    {
        public static void Main()
        {
            // This will not be called by the AMS, however you may want to test your Die class here.
            Dice myNewDie = new Dice(3, 3);
            Console.WriteLine();
            for (int i = 0; i < 100; i++)
            {
                myNewDie.RollDice();
                Console.WriteLine("{0}", myNewDie.GetFaceValue());
            }
            Console.ReadLine();

        }
    }
}
