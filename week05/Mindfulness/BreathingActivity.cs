using System;

namespace Mindfulness
{
    public class BreathingActivity : Activity
    {
        public BreathingActivity()
            : base(
                "Breathing Activity",
                "This activity will help you relax by guiding you through slow breathing. Clear your mind and focus on your breathing.")
        {
        }

        protected override void PerformActivity()
        {
            DateTime endTime = DateTime.UtcNow.AddSeconds(Duration);

            while (DateTime.UtcNow < endTime)
            {
                Console.Write("Breathe in...");
                ShowCountDown(4);
                Console.WriteLine();

                if (DateTime.UtcNow >= endTime)
                {
                    break;
                }

                Console.Write("Breathe out...");
                ShowCountDown(4);
                Console.WriteLine();
            }
        }
    }
}