// Enhancements and additional features
// Added random motivational messages on Program.cs
using System;

namespace Mindfulness
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool running = true;

            while (running)
            {
                Console.Clear();
                Console.WriteLine("Welcome to the Mindfulness Program!");
                Console.WriteLine();
                Console.WriteLine("Menu Options:");
                Console.WriteLine("  1. Start breathing activity");
                Console.WriteLine("  2. Start reflection activity");
                Console.WriteLine("  3. Start listing activity");
                Console.WriteLine("  4. Quit");
                Console.Write("Select a choice from the menu: ");

                string choice = Console.ReadLine() ?? "";

                Activity activity = null;

                switch (choice)
                {
                    case "1":
                        activity = new BreathingActivity();
                        break;

                    case "2":
                        activity = new ReflectionActivity();
                        break;

                    case "3":
                        activity = new ListingActivity();
                        break;

                    case "4":
                        running = false;
                        Console.WriteLine("Thank you for using the Mindfulness Program. Goodbye!");
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Please select 1, 2, 3, or 4.");
                        Thread.Sleep(1500);
                        break;
                }

                if (activity != null)
                {
                    activity.Run();
                    Console.WriteLine();
                    Console.WriteLine("Press Enter to return to the menu.");
                    Console.ReadLine();
                }
            }
        }
    }
}