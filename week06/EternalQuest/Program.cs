//    The "Display User Info" option has been added to allow the user to view their current score, enhancing the user experience by providing feedback on their progress.

using System;

public class Program
{
  public static void Main(string[] args)
  {
    GoalManager goalManager = new GoalManager();
    goalManager.Start();
  }
}