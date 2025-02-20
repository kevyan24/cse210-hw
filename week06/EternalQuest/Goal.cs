public abstract class Goal
{
  private string _shortName;
  protected string _description;
  private int _points;

  public Goal(string name, string description, int points)
  {
    _shortName = name;
    _description = description;
    _points = points;
  }

  public abstract void RecordEvent();
  public abstract bool IsComplete();
  public abstract string GetDetailsString();
  public abstract string GetStringRepresentation();

  public string GetShortName()
  {
    return _shortName;
  }

  public int GetPoints()
  {
    return _points;
  }
}