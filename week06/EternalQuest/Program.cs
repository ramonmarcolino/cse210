// Additional features 
// Leveling System: Users gain levels as they earn points

using System;

public class Program
{
    private static readonly QuestManager _quest = new QuestManager();

    public static void Main(string[] args)
    {

        Console.WriteLine("          ETERNAL QUEST");


        _quest.Load();

        bool running = true;

        while (running)
        {
            DisplayStatus();

            Console.WriteLine("\nMAIN MENU");
            Console.WriteLine("1. Show all goals");
            Console.WriteLine("2. Create a new goal");
            Console.WriteLine("3. Record goal progress");
            Console.WriteLine("4. Show achievements");
            Console.WriteLine("5. Save goals");
            Console.WriteLine("6. Load goals");
            Console.WriteLine("7. Exit");
            Console.Write("Choose an option: ");

            string choice = Console.ReadLine() ?? "";

            switch (choice)
            {
                case "1":
                    _quest.DisplayGoals();
                    break;

                case "2":
                    CreateGoal();
                    break;

                case "3":
                    RecordGoal();
                    break;

                case "4":
                    DisplayAchievements();
                    break;

                case "5":
                    _quest.Save();
                    break;

                case "6":
                    _quest.Load();
                    break;

                case "7":
                    _quest.Save();
                    running = false;
                    Console.WriteLine(
                        "Your quest has been saved. Keep going!");
                    break;

                default:
                    Console.WriteLine("Invalid option. Try again.");
                    break;
            }
        }
    }

    private static void DisplayStatus()
    {
        Console.WriteLine($"\nScore: {_quest.Score} points");
        Console.WriteLine(
            $"Level: {_quest.Level} - {_quest.LevelTitle}");
    }

    private static void CreateGoal()
    {
        Console.WriteLine("\nCREATE A NEW GOAL");
        Console.WriteLine("1. Simple goal");
        Console.WriteLine("2. Eternal goal");
        Console.WriteLine("3. Checklist goal");
        Console.WriteLine("4. Negative goal");

        string type = ReadRequiredText("Choose goal type: ");

        if (type != "1" && type != "2"
            && type != "3" && type != "4")
        {
            Console.WriteLine("Invalid goal type.");
            return;
        }

        string name = ReadRequiredText("Goal name: ");

        Console.Write("Goal description: ");
        string description = Console.ReadLine() ?? "";

        int points = ReadInt(
            type == "4"
                ? "Points lost when the habit occurs: "
                : "Points gained per completion: ",
            1);

        Goal goal;

        switch (type)
        {
            case "1":
                goal = new SimpleGoal(name, description, points);
                break;

            case "2":
                goal = new EternalGoal(name, description, points);
                break;

            case "3":
                int target = ReadInt(
                    "How many completions are required? ", 1);

                int bonus = ReadInt(
                    "Bonus points for reaching the target: ", 0);

                goal = new ChecklistGoal(
                    name, description, points, target, bonus);
                break;

            default:
                goal = new NegativeGoal(name, description, points);
                break;
        }

        _quest.AddGoal(goal);

        Console.WriteLine("Goal created successfully!");
        _quest.Save();
    }

    private static void RecordGoal()
    {
        _quest.DisplayGoals();

        if (_quest.Goals.Count == 0)
        {
            return;
        }

        int number = ReadInt("Enter the goal number: ", 1);

        if (number > _quest.Goals.Count)
        {
            Console.WriteLine("That goal number does not exist.");
            return;
        }

        Goal goal = _quest.Goals[number - 1];

        bool success = _quest.RecordEvent(goal, out int pointsChange);

        if (!success)
        {
            Console.WriteLine(
                "This goal is already complete or cannot be recorded.");
            return;
        }

        if (pointsChange > 0)
        {
            Console.WriteLine(
                $"Congratulations! You earned {pointsChange} points.");
        }
        else if (pointsChange < 0)
        {
            Console.WriteLine(
                $"You lost {Math.Abs(pointsChange)} points.");
        }

        Console.WriteLine($"Current score: {_quest.Score}");
        Console.WriteLine(
            $"Current level: {_quest.Level} - {_quest.LevelTitle}");

        DisplayAchievements();

        _quest.Save();
    }

    private static void DisplayAchievements()
    {
        Console.WriteLine("\nYOUR ACHIEVEMENTS");

        string[] achievements =
        {
            "First Steps: 100 points",
            "Faithful Disciple: 500 points",
            "Quest Champion: 1,000 points",
            "Celestial Explorer: 5,000 points"
        };

        int[] milestones = { 100, 500, 1000, 5000 };

        for (int i = 0; i < milestones.Length; i++)
        {
            string status = _quest.Score >= milestones[i]
                ? "[UNLOCKED]"
                : "[LOCKED]";

            Console.WriteLine($"{status} {achievements[i]}");
        }
    }

    private static string ReadRequiredText(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string value = Console.ReadLine() ?? "";

            if (!string.IsNullOrWhiteSpace(value))
            {
                return value.Trim();
            }

            Console.WriteLine("This field cannot be empty.");
        }
    }

    private static int ReadInt(string prompt, int minimum)
    {
        while (true)
        {
            Console.Write(prompt);

            if (int.TryParse(Console.ReadLine(), out int value)
                && value >= minimum)
            {
                return value;
            }

            Console.WriteLine(
                $"Enter a whole number of at least {minimum}.");
        }
    }
}


