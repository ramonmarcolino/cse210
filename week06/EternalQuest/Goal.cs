
using System.Text.Json.Serialization;

[JsonPolymorphic(TypeDiscriminatorPropertyName = "$goalType")]
[JsonDerivedType(typeof(SimpleGoal), "simple")]
[JsonDerivedType(typeof(EternalGoal), "eternal")]
[JsonDerivedType(typeof(ChecklistGoal), "checklist")]
[JsonDerivedType(typeof(NegativeGoal), "negative")]
public abstract class Goal
{
    private string _name;
    private string _description;
    private int _points;

    public string Name => _name;
    public string Description => _description;
    public int Points => _points;

    protected Goal()
    {
        _name = "";
        _description = "";
        _points = 0;
    }

    protected Goal(string name, string description, int points)
    {
        _name = name;
        _description = description;
        _points = points;
    }

    public abstract int RecordEvent();

    public virtual bool CanRecord()
    {
        return true;
    }

    public virtual string GetStatus()
    {
        return "[ ]";
    }

    public virtual string GetDetails()
    {
        return $"{_name} - {_description} ({_points} points)";
    }
}
