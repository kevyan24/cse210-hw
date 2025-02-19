using System;

namespace MindfulnessProgram
{
  public class BreathingActivity : Activity
  {
    public BreathingActivity() : base("Breathing", "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
    {
    }

    public void Run()
    {
      DisplayStartingMessage();
      DateTime endTime = DateTime.Now.AddSeconds(_duration);

      while (DateTime.Now < endTime)
      {
        Console.WriteLine("Breathe in...");
        ShowCountDown(4);
        if (DateTime.Now >= endTime) break;

        Console.WriteLine("Breathe out...");
        ShowCountDown(4);
      }

      DisplayEndingMessage();
    }
  }
}