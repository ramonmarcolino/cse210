using System;
using System.Collections.Generic;

namespace JournalApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Journal theJournal = new Journal();
            Random randomGenerator = new Random();

            List<string> prompts = new List<string>
            {
                "Who was the most interesting person I interacted with today?",
                "What was the best part of my day?",
                "How did I see the hand of the Lord in my life today?",
                "What was the strongest emotion I felt today?",
                "If I had one thing I could do over today, what would it be?"
            };

            string choice = "";

            Console.WriteLine("Welcome to the Journal Program!");

            while (choice != "5")
            {
                Console.WriteLine("\nPlease select one of the following choices:");
                Console.WriteLine("1. Write");
                Console.WriteLine("2. Display");
                Console.WriteLine("3. Load");
                Console.WriteLine("4. Save");
                Console.WriteLine("5. Quit");

                Console.Write("What would you like to do? ");
                choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        int index = randomGenerator.Next(prompts.Count);
                        string prompt = prompts[index];

                        Console.WriteLine($"\nPrompt: {prompt}");
                        Console.Write("> ");
                        string response = Console.ReadLine();

                        string dateText = DateTime.Now.ToShortDateString();

                        Entry newEntry = new Entry(
                            dateText,
                            prompt,
                            response
                        );

                        theJournal.AddEntry(newEntry);
                        break;

                    case "2":
                        theJournal.DisplayAll();
                        break;

                    case "3":
                        Console.Write("\nWhat is the filename? ");
                        string loadFile = Console.ReadLine();

                        theJournal.LoadFromFile(loadFile);
                        break;

                    case "4":
                        Console.Write("\nWhat is the filename? ");
                        string saveFile = Console.ReadLine();

                        theJournal.SaveToFile(saveFile);
                        break;

                    case "5":
                        Console.WriteLine("\nThank you for using the journal. Goodbye!");
                        break;

                    default:
                        Console.WriteLine("\nInvalid choice. Please try again.");
                        break;
                }
            }
        }
    }
}
