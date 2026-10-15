
using System.Text.Json.Serialization;

public class EternalGoal : Goal
{
    private int _timesCompleted;

    [JsonInclude]
    public int TimesCompleted
    {
        get => _timesCompleted;
        private set => _timesCompleted = value;
    }

    public EternalGoal() : base()
    {
        _timesCompleted = 0;
    }

    public EternalGoal(
        string name,
        string description,
        int points)
        : base(name, description, points)
    {
        _timesCompleted = 0;
    }

    public override int RecordEvent()
    {
        _timesCompleted++;
        return Points;
    }

    public override string GetStatus()
    {
        return $"[ETERNAL: {_timesCompleted} times]";
    }
}
