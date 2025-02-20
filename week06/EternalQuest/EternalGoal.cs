public class EternalGoal : Goal
{
  public EternalGoal(string name, string description, int points) : base(name, description, points) { }

  public override void RecordEvent() { }

  public override bool IsComplete() { return false; }

  public override string GetDetailsString()
  {
    return $"[ ] {GetShortName()} ({GetPoints()} points)";
  }

  public override string GetStringRepresentation()
  {
    return $"EternalGoal:{GetShortName()},{_description},{GetPoints()}";
  }
}