
using System.Text.Json.Serialization;

public class SimpleGoal : Goal
{
    private bool _isComplete;

    [JsonInclude]
    public bool IsComplete
    {
        get => _isComplete;
        private set => _isComplete = value;
    }

    public SimpleGoal() : base()
    {
        _isComplete = false;
    }

    public SimpleGoal(
        string name,
        string description,
        int points)
        : base(name, description, points)
    {
        _isComplete = false;
    }

    public override int RecordEvent()
    {
        if (_isComplete)
        {
            return 0;
        }

        _isComplete = true;
        return Points;
    }

    public override bool CanRecord()
    {
        return !_isComplete;
    }

    public override string GetStatus()
    {
        return _isComplete ? "[X]" : "[ ]";
    }
}
