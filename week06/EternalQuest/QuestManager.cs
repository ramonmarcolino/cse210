
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

public class QuestManager
{
    private readonly List<Goal> _goals = new();
    private int _score;

    private const string SaveFile = "eternal_quest.json";

    public IReadOnlyList<Goal> Goals => _goals.AsReadOnly();

    public int Score => _score;

    public int Level => Math.Max(1, (_score / 500) + 1);

    public string LevelTitle
    {
        get
        {
            if (Level >= 11) return "Celestial Master";
            if (Level >= 6) return "Quest Champion";
            if (Level >= 3) return "Faithful Adventurer";

            return "Novice Seeker";
        }
    }

    public void AddGoal(Goal goal)
    {
        if (goal == null)
        {
            throw new ArgumentNullException(nameof(goal));
        }

        _goals.Add(goal);
    }

    public bool RecordEvent(Goal goal, out int pointsChange)
    {
        pointsChange = 0;

        if (goal == null ||
            !_goals.Contains(goal) ||
            !goal.CanRecord())
        {
            return false;
        }

        pointsChange = goal.RecordEvent();
        _score += pointsChange;

        return true;
    }

    public void DisplayGoals()
    {
        Console.WriteLine("\nYOUR QUEST GOALS");

        if (_goals.Count == 0)
        {
            Console.WriteLine(
                "No goals yet. Create one to begin your quest!");
            return;
        }

        for (int i = 0; i < _goals.Count; i++)
        {
            Goal goal = _goals[i];

            Console.WriteLine(
                $"{i + 1}. {goal.GetStatus()} {goal.GetDetails()}");
        }
    }

    public void Save()
    {
        try
        {
            SaveData data = new SaveData
            {
                Score = _score,
                Goals = _goals
            };

            JsonSerializerOptions options = new JsonSerializerOptions
            {
                WriteIndented = true
            };

            string json = JsonSerializer.Serialize(data, options);

            File.WriteAllText(SaveFile, json);

            Console.WriteLine("Quest saved successfully!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Could not save quest: {ex.Message}");
        }
    }

    public void Load()
    {
        if (!File.Exists(SaveFile))
        {
            Console.WriteLine(
                "No save file found. Starting a new quest.");
            return;
        }

        try
        {
            string json = File.ReadAllText(SaveFile);

            SaveData? data =
                JsonSerializer.Deserialize<SaveData>(json);

            if (data == null || data.Goals == null)
            {
                Console.WriteLine("The save file is invalid.");
                return;
            }

            if (data.Goals.Any(goal => goal == null))
            {
                Console.WriteLine("The saved goals are invalid.");
                return;
            }


            _goals.Clear();
            _goals.AddRange(data.Goals);
            _score = data.Score;

            Console.WriteLine("Quest loaded successfully!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Could not load quest: {ex.Message}");
        }
    }
}
