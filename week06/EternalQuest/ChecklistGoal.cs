
using System.Text.Json.Serialization;

public class ChecklistGoal : Goal
{
    private int _target;
    private int _completedCount;
    private int _bonus;
    private bool _bonusAwarded;

    [JsonInclude]
    public int Target
    {
        get => _target;
        private set => _target = value;
    }

    [JsonInclude]
    public int CompletedCount
    {
        get => _completedCount;
        private set => _completedCount = value;
    }

    [JsonInclude]
    public int Bonus
    {
        get => _bonus;
        private set => _bonus = value;
    }

    [JsonInclude]
    public bool BonusAwarded
    {
        get => _bonusAwarded;
        private set => _bonusAwarded = value;
    }

    public ChecklistGoal() : base()
    {
        _target = 1;
        _completedCount = 0;
        _bonus = 0;
        _bonusAwarded = false;
    }

    public ChecklistGoal(
        string name,
        string description,
        int points,
        int target,
        int bonus)
        : base(name, description, points)
    {
        if (target < 1)
        {
            throw new ArgumentOutOfRangeException(nameof(target));
        }

        if (bonus < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(bonus));
        }

        _target = target;
        _completedCount = 0;
        _bonus = bonus;
        _bonusAwarded = false;
    }

    public override int RecordEvent()
    {
        if (!CanRecord())
        {
            return 0;
        }

        _completedCount++;

        int earnedPoints = Points;

        if (_completedCount == _target && !_bonusAwarded)
        {
            earnedPoints += _bonus;
            _bonusAwarded = true;
        }

        return earnedPoints;
    }

    public override bool CanRecord()
    {
        return _completedCount < _target;
    }

    public override string GetStatus()
    {
        return _completedCount >= _target ? "[X]" : "[ ]";
    }

    public override string GetDetails()
    {
        string details =
            $"{base.GetDetails()} - Completed {_completedCount}/{_target} times";

        if (_bonusAwarded)
        {
            details += $" (Bonus of {_bonus} earned)";
        }

        return details;
    }
}
