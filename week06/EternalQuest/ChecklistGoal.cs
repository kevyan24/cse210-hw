public class ChecklistGoal : Goal
{
  protected int _amountCompleted;
  private int _target;
  private int _bonus;

  public ChecklistGoal(string name, string description, int points, int target, int bonus) : base(name, description, points)
  {
    _target = target;
    _bonus = bonus;
  }

  public override void RecordEvent()
  {
    if (_amountCompleted < _target)
    {
      _amountCompleted++;
    }
  }

  public override bool IsComplete()
  {
    return _amountCompleted >= _target;
  }

  public override string GetDetailsString()
  {
    return $"[{(IsComplete() ? "X" : " ")}] {GetShortName()} ({_amountCompleted}/{_target}) ({GetPoints()} points + {_bonus} bonus)";
  }

  public override string GetStringRepresentation()
  {
    return $"ChecklistGoal:{GetShortName()},{_description},{GetPoints()},{_target},{_bonus},{_amountCompleted}";
  }

  public int GetBonus()
  {
    return _bonus;
  }

  // Método para establecer _amountCompleted desde GoalManager
  public void SetAmountCompleted(int amountCompleted)
  {
    _amountCompleted = amountCompleted;
  }
}