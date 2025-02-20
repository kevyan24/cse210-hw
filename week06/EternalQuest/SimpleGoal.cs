public class SimpleGoal : Goal
{
  protected bool _isComplete;

  public SimpleGoal(string name, string description, int points) : base(name, description, points)
  {
    _isComplete = false;
  }

  public override void RecordEvent()
  {
    if (!_isComplete)
    {
      _isComplete = true;
    }
  }

  public override bool IsComplete()
  {
    return _isComplete;
  }

  public override string GetDetailsString()
  {
    return $"[{(IsComplete() ? "X" : " ")}] {GetShortName()} ({GetPoints()} points)";
  }

  public override string GetStringRepresentation()
  {
    return $"SimpleGoal:{GetShortName()},{_description},{GetPoints()},{_isComplete}";
  }

  public void SetIsComplete(bool isComplete)
  {
    _isComplete = isComplete;
  }
}