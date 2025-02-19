using System;
using System.Threading;

namespace MindfulnessProgram
{
  public class Activity
  {
    protected string _name;
    protected string _description;
    protected int _duration;

    public Activity(string name, string description)
    {
      _name = name;
      _description = description;
    }

    public int Duration
    {
      get { return _duration; }
    }

    public void DisplayStartingMessage()
    {
      Console.WriteLine($"Welcome to the {_name} Activity.");
      Console.WriteLine(_description);
      Console.Write("How long, in seconds, would you like your session? ");
      _duration = int.Parse(Console.ReadLine());
      Console.WriteLine("Get ready to begin...");
      ShowSpinner(3);
    }

    public void DisplayEndingMessage()
    {
      Console.WriteLine("Well done!!");
      ShowSpinner(3);
      Console.WriteLine($"You have completed another {_duration} seconds of the {_name} Activity.");
      ShowSpinner(3);
    }

    public void ShowSpinner(int seconds)
    {
      char[] spinnerChars = { '|', '/', '-', '\\' };
      int charIndex = 0;
      DateTime endTime = DateTime.Now.AddSeconds(seconds);

      while (DateTime.Now < endTime)
      {
        Console.Write(spinnerChars[charIndex]);
        Thread.Sleep(250);
        Console.Write("\b \b");
        charIndex = (charIndex + 1) % spinnerChars.Length;
      }
    }

    public void ShowCountDown(int seconds)
    {
      for (int i = seconds; i > 0; i--)
      {
        Console.Write(i);
        Thread.Sleep(1000);
        Console.Write("\b \b");
      }
    }
  }
}