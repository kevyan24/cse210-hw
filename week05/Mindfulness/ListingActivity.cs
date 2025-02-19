using System;
using System.Collections.Generic;

namespace MindfulnessProgram
{
  public class ListingActivity : Activity
  {
    private List<string> _prompts = new List<string>
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        };

    public ListingActivity() : base("Listing", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    {
    }

    public void Run()
    {
      DisplayStartingMessage();
      Random random = new Random();
      string prompt = _prompts[random.Next(_prompts.Count)];
      Console.WriteLine(prompt);
      Console.WriteLine("Start listing:");

      DateTime endTime = DateTime.Now.AddSeconds(_duration);
      List<string> items = new List<string>();

      while (DateTime.Now < endTime)
      {
        Console.Write("> ");
        string item = Console.ReadLine();
        items.Add(item);
      }

      Console.WriteLine($"You have listed {items.Count} items.");
      DisplayEndingMessage();
    }
  }
}