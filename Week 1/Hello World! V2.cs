using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class HelloWorldV2
{
    public static void Main()
    {
        // Declare a 'string' variable called 'name' to hold the user's name
        string name;
        // Display the message "Please enter your name: ".
        // (hint: Use Console.Write instead of WriteLine for this)
        Console.Write("Please enter your name:  ");
        // Use Console.ReadLine to read what the user types into the 'name' variable
        name = Console.ReadLine();
        // Write a single blank line
        Console.WriteLine();
        // Write "Hello (name goes here), and welcome to CAB201" on a line by itself.
        // Instead of (name goes here) you should put in the name the user gave you.
        Console.WriteLine("Hello " + name + ", and welcome to CAB201");
        // Write "Press enter to exit" on a line by itself
        Console.WriteLine("Press enter to exit");
        // Wait for the user to press the enter key
        Console.ReadLine();
    }
}
