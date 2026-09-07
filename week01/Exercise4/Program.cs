using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Contracts;
using System.Globalization;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Exercise4 Project.");

        List<int> numbers = new List<int>();

        int userNumber = 999;

        while (userNumber != 0)
        {
            Console.Write("Enter a number (0 to quit): ");
            string userResponse = Console.ReadLine();
            userNumber = int.Parse(userResponse);

            if (userNumber != 0)
            {
                numbers.Add(userNumber);
            }
        }

        int sum = 0;
        foreach (int number in numbers)
        {
            sum += number;

        }
        Console.WriteLine($"The sum is: {sum}");

        float average = ((float)sum) / numbers.Count;
        Console.WriteLine($"The average is: {average}");

        int max = numbers[0];
        foreach (int number in numbers)
        {
            if (number > max)
            {
                max = number;
            }
        }
        Console.WriteLine($"The max is: {max}");

        float mostNegative = 100;
        foreach (int number in numbers)
        {
            if (mostNegative > 0 && number < mostNegative)
            {
                mostNegative = number;
            } 
        }
        Console.WriteLine($"The smallest positive number is: {mostNegative}");

        var sortedNumbers = numbers.OrderBy(n => n).ToList();
        var descendingNumbers = numbers.OrderByDescending(n => n).ToList();
        Console.WriteLine("Descending: " + string.Join(", ", descendingNumbers));
        Console.WriteLine("Ascending: " + string.Join(", ", sortedNumbers));
    }
}