public class Swimming : Activity
{
  private int laps;

  public Swimming(DateTime date, int minutes, int laps) : base(date, minutes)
  {
    this.laps = laps;
  }

  public override double GetDistance()
  {
    return laps * 50.0 / 1000.0;
  }

  public override double GetSpeed()
  {
    return (GetDistance() / Minutes) * 60;
  }

  public override double GetPace()
  {
    return Minutes / GetDistance();
  }
}