using System;
using System.Reflection.Metadata;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Exercise2 Project.");

        Console.Write("Enter a number: ");
        string valueFromUser = Console.ReadLine();

        int x = int.Parse(valueFromUser);
        int y = 2;
        int z = 5;

        if (!(x < y || x < z) && y < z)
        {
            Console.WriteLine("Greater");
        }
        else if (x < y)
        {
            Console.WriteLine("Less");
        }
        else
        {
            Console.WriteLine("Equal");
        }

        Console.Write("What is your grade percentage? ");
        string answer = Console.ReadLine();
        float percent = float.Parse(answer);

        string letter = "";

        if (percent >= 90)
        {
            letter = "A";
        }
        else if (percent >= 80)
        {
            letter = "B";
        }
        else if (percent >= 70)
        {
            letter = "C";
        }
        else if (percent >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        // Adding + / -
        float lastDigit = percent % 10;
        string sign = "";

        if (letter == "A" && percent >= 93)
        {
            sign = "";
        }
        else if (letter == "F")
        {
            sign = "";
        }
        else if (lastDigit >= 7)
        {
            sign = "+";
        }
        else if (lastDigit < 3)
        {
            sign = "-";
        }
        else
        {
            sign = "";
        }

        Console.WriteLine($"Your grade is: {letter}{sign}");
        
        if (percent >= 70)
        {
            Console.WriteLine($"You passed class with {letter}{sign}! Congratulations!");
        }
        else
        {
            Console.WriteLine("You did not passed class. Keep working for the next time!");
        }
    }
}