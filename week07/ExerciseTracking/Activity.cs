public class Activity
{
  private DateTime date;
  private int minutes;

  public Activity(DateTime date, int minutes)
  {
    this.date = date;
    this.minutes = minutes;
  }

  public virtual double GetDistance()
  {
    return 0;
  }

  public virtual double GetSpeed()
  {
    return 0;
  }
  
  public virtual double GetPace()
  {
    return 0;
  }

  public string GetSummary()
  {
    return $"{date.ToString("dd MMM yyyy")} {GetType().Name} ({minutes} min): Distance {GetDistance():F2} km, Speed: {GetSpeed():F2} kph, Pace: {GetPace():F2} min per km";
  }

  public DateTime Date
  {
    get { return date; }
    set { date = value; }
  }

  public int Minutes
  {
    get { return minutes; }
    set { minutes = value; }
  }
}