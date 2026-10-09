using System;
using System.Threading;

namespace Mindfulness
{
    public abstract class Activity
    {
        private string _activityName;
        private string _description;
        private int _duration;

        protected int Duration
        {
            get { return _duration; }
        }

        protected Activity(string activityName, string description)
        {
            _activityName = activityName;
            _description = description;
            _duration = 0;
        }

        public void Run()
        {
            Console.Clear();
            DisplayStartingMessage();

            Console.Write("How long, in seconds, would you like for your session? ");

            while (!int.TryParse(Console.ReadLine(), out _duration) ||
                   _duration <= 0)
            {
                Console.Write("Please enter a positive number of seconds: ");
            }

            Console.WriteLine();
            Console.WriteLine("Prepare to begin...");
            ShowSpinner(3);

            PerformActivity();

            DisplayEndingMessage();
        }

        protected abstract void PerformActivity();

        private void DisplayStartingMessage()
        {
            Console.WriteLine($"Welcome to the {_activityName}.");
            Console.WriteLine();
            Console.WriteLine(_description);
            Console.WriteLine();
        }

        private void DisplayEndingMessage()
        {
            Console.WriteLine();
            Console.WriteLine("Well done!");
            ShowSpinner(2);

            Console.WriteLine();
            Console.WriteLine(
                $"You have completed {_duration} seconds of the {_activityName}.");

            // Extra feature: provide a random motivational message
            // after every activity to encourage continued mindfulness.
            string[] messages =
            {
                "Keep making time for your well-being!",
                "Every mindful moment makes a difference!",
                "Take what you learned into the rest of your day!",
                "Small moments of peace can make a big difference!"
            };

            Random random = new Random();
            Console.WriteLine(messages[random.Next(messages.Length)]);

            ShowSpinner(3);
        }

        protected void ShowSpinner(int seconds)
        {
            char[] symbols = { '|', '/', '-', '\\' };
            DateTime endTime = DateTime.UtcNow.AddSeconds(seconds);
            int index = 0;

            while (DateTime.UtcNow < endTime)
            {
                Console.Write(symbols[index % symbols.Length]);
                Thread.Sleep(250);
                Console.Write("\b \b");
                index++;
            }
        }

        protected void ShowCountDown(int seconds)
        {
            for (int i = seconds; i > 0; i--)
            {
                Console.Write(i);
                Thread.Sleep(1000);
                Console.Write("\b \b");
            }
        }
    }
}