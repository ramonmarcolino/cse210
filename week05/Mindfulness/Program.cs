using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Creativity requirement:
        // This program records the completed activities in memory
        // and displays a session summary before exiting.

        List<string> completedActivities = new List<string>();

        bool running = true;

        while (running)
        {
            Console.Clear();

            Console.WriteLine("Mindfulness Program");
            Console.WriteLine();
            Console.WriteLine("1. Start breathing activity");
            Console.WriteLine("2. Start reflection activity");
            Console.WriteLine("3. Start listing activity");
            Console.WriteLine("4. View session summary");
            Console.WriteLine("5. Quit");
            Console.Write("Select a choice from the menu: ");

            string choice = Console.ReadLine() ?? "";

            switch (choice)
            {
                case "1":
                    BreathingActivity breathing =
                        new BreathingActivity();

                    breathing.Run();

                    completedActivities.Add(
                        $"Breathing Activity - {breathing.GetDuration()} seconds"
                    );
                    break;

                case "2":
                    ReflectionActivity reflection =
                        new ReflectionActivity();

                    reflection.Run();

                    completedActivities.Add(
                        $"Reflection Activity - {reflection.GetDuration()} seconds"
                    );
                    break;

                case "3":
                    ListingActivity listing =
                        new ListingActivity();

                    listing.Run();

                    completedActivities.Add(
                        $"Listing Activity - {listing.GetDuration()} seconds"
                    );
                    break;

                case "4":
                    Console.Clear();
                    Console.WriteLine("Session Summary");
                    Console.WriteLine();

                    if (completedActivities.Count == 0)
                    {
                        Console.WriteLine(
                            "No activities completed yet."
                        );
                    }
                    else
                    {
                        foreach (string activity in completedActivities)
                        {
                            Console.WriteLine($"- {activity}");
                        }
                    }

                    Console.WriteLine();
                    Console.WriteLine("Press Enter to return to the menu.");
                    Console.ReadLine();
                    break;

                case "5":
                    running = false;
                    break;

                default:
                    Console.WriteLine("Invalid choice. Try again.");
                    System.Threading.Thread.Sleep(1500);
                    break;
            }
        }

        Console.WriteLine("Thank you for using the Mindfulness Program!");
    }
}