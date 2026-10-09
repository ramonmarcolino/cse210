using System;
using System.Collections.Generic;

public class ListingActivity : Activity
{
    private string[] _prompts =
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "Who are some of your personal heroes?",
        "What are some things you are grateful for?"
    };

    private List<string> _items = new List<string>();
    private Random _random = new Random();

    public ListingActivity()
        : base(
            "Listing Activity",
            "This activity will help you reflect on the good things " +
            "in your life by having you list as many things as you can."
        )
    {
    }

    public void Run()
    {
        DisplayStartingMessage();

        _items.Clear();

        string prompt = _prompts[_random.Next(_prompts.Length)];

        Console.WriteLine();
        Console.WriteLine($"List as many responses as you can to:");
        Console.WriteLine($"--- {prompt} ---");

        ShowCountDown(5);

        DateTime endTime = DateTime.Now.AddSeconds(GetDuration());

        while (DateTime.Now < endTime)
        {
            Console.WriteLine();
            Console.Write("Enter an item (or press Enter to finish): ");

            string item = Console.ReadLine() ?? "";

            if (string.IsNullOrWhiteSpace(item))
            {
                break;
            }

            _items.Add(item.Trim());
        }

        Console.WriteLine();
        Console.WriteLine($"You listed {_items.Count} items.");

        DisplayEndingMessage();
    }
}