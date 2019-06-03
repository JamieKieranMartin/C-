using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class IncomeTax
{
    public static void Main()
    {
        double INCOME_TAX_RATE = 0.02;
        int INIT_DEDUCTION = 10000;
        string input = "";
        int income = 0;
        int childCount = 0;
        int CHILD_DEDUCTION = 2000;
        double taxOwed = 0;
        bool IncomeTrue = false;
        bool ChildTrue = false;

        while (!IncomeTrue)
        {
            Console.Write("What is your total income: ");
            input = Console.ReadLine();
            bool test1 = int.TryParse(input, out income);
            if (!test1)
            {
                Console.WriteLine("Enter your income as a whole-dollar figure.");
            }
            else if (income < 0)
            {
                Console.WriteLine("Your income cannot be negative.");
            }
            else
            {
                IncomeTrue = true;
            }
        }

        while (!ChildTrue)
        {
            Console.Write("How many children do you have: ");
            input = Console.ReadLine();
            bool test2 = int.TryParse(input, out childCount);
            if (!test2)
            {
                Console.WriteLine("You must enter a valid number.");
            }
            else if (childCount < 0)
            {
                Console.WriteLine("You must enter a positive number.");
            }
            else
            {
                ChildTrue = true;
            }
        }

        taxOwed = ((income - INIT_DEDUCTION) - (childCount * CHILD_DEDUCTION)) * INCOME_TAX_RATE;

        if (taxOwed > 0)
        {
            string output = Convert.ToDecimal(taxOwed).ToString("$0.00");
            Console.WriteLine("You owe a total of {0} tax", output);
        }
        else
        {
            Console.WriteLine("You owe no tax.");
        }

        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine(" Hit Enter to exit.");
        Console.ReadLine();
    }
}
