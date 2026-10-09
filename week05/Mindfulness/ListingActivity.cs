using System;
using System.Collections.Generic;

namespace Mindfulness
{
    public class ListingActivity : Activity
    {
        private string[] _prompts;

        public ListingActivity()
            : base(
                "Listing Activity",
                "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
        {
            _prompts = new string[]
            {
                "Who are people that you appreciate?",
                "What are personal strengths you have?",
                "Who have you helped this week?",
                "When have you felt the Holy Ghost this month?",
                "What are things you are grateful for?",
                "What are things that make you happy?"
            };
        }

        protected override void PerformActivity()
        {
            Random random = new Random();

            string prompt = _prompts[random.Next(_prompts.Length)];

            Console.WriteLine("List as many responses as you can to the following prompt:");
            Console.WriteLine();
            Console.WriteLine($"--- {prompt} ---");
            Console.WriteLine();
            Console.Write("You may begin in: ");

            ShowCountDown(5);
            Console.WriteLine();
            Console.WriteLine();

            List<string> responses = new List<string>();
            DateTime endTime = DateTime.UtcNow.AddSeconds(Duration);

            while (DateTime.UtcNow < endTime)
            {
                Console.Write("> ");

                string response = Console.ReadLine() ?? "";

                if (DateTime.UtcNow <= endTime &&
                    !string.IsNullOrWhiteSpace(response))
                {
                    responses.Add(response.Trim());
                }
            }

            Console.WriteLine();
            Console.WriteLine($"You listed {responses.Count} item(s)!");
        }
    }
}