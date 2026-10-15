
using System.Text.Json.Serialization;

public class NegativeGoal : Goal
{
    private int _timesRecorded;

    [JsonInclude]
    public int TimesRecorded
    {
        get => _timesRecorded;
        private set => _timesRecorded = value;
    }

    public NegativeGoal() : base()
    {
        _timesRecorded = 0;
    }

    public NegativeGoal(
        string name,
        string description,
        int penalty)
        : base(name, description, penalty)
    {
        _timesRecorded = 0;
    }

    public override int RecordEvent()
    {
        _timesRecorded++;
        return -Points;
    }

    public override string GetStatus()
    {
        return $"[RECORDED: {_timesRecorded} times]";
    }

    public override string GetDetails()
    {
        return $"{Name} - {Description} (Penalty: {Points} points)";
    }
}
