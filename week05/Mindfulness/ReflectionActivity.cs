using System;

namespace Mindfulness
{
    public class ReflectionActivity : Activity
    {
        private string[] _prompts;
        private string[] _questions;
        private Random _random;

        public ReflectionActivity()
            : base(
                "Reflection Activity",
                "This activity will help you reflect on times in your life when you have shown strength and resilience. Consider each prompt carefully.")
        {
            _prompts = new string[]
            {
                "Think of a time when you stood up for someone else.",
                "Think of a time when you did something difficult.",
                "Think of a time when you helped someone in need.",
                "Think of a time when you overcame a challenge.",
                "Think of a time when you made someone smile."
            };

            _questions = new string[]
            {
                "Why was this experience meaningful to you?",
                "How did you feel when it was over?",
                "What did you learn about yourself?",
                "What made this experience special?",
                "How can you apply what you learned in the future?",
                "Who helped you during this experience?",
                "What would you do differently next time?",
                "How did this experience change your perspective?"
            };

            _random = new Random();
        }

        protected override void PerformActivity()
        {
            Console.WriteLine(
                "Consider the following prompt:");

            Console.WriteLine();
            Console.WriteLine(
                $"--- {_prompts[_random.Next(_prompts.Length)]} ---");

            Console.WriteLine();
            Console.WriteLine(
                "When you have something in mind, press Enter to continue.");

            Console.ReadLine();

            DateTime endTime = DateTime.UtcNow.AddSeconds(Duration);

            while (DateTime.UtcNow < endTime)
            {
                string question =
                    _questions[_random.Next(_questions.Length)];

                Console.WriteLine();
                Console.WriteLine($"> {question}");

                ShowSpinner(5);
            }
        }
    }
}