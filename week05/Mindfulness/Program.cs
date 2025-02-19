using System;
using System.Collections.Generic;
using System.IO;

namespace MindfulnessProgram
{
  class Program
  {
    static void Main(string[] args)
    {
      // Additional feature: Activity log
      // We implement a log that saves the activities performed with dates and durations.
      List<string> activityLog = new List<string>();

      while (true)
      {
        Console.WriteLine("Menu:");
        Console.WriteLine("1. Breathing Activity");
        Console.WriteLine("2. Reflection Activity");
        Console.WriteLine("3. Listing Activity");
        Console.WriteLine("4. Exit");
        Console.Write("Choose an option: ");

        string choice = Console.ReadLine();

        switch (choice)
        {
          case "1":
            BreathingActivity breathingActivity = new BreathingActivity();
            breathingActivity.Run();
            LogActivity(activityLog, "Breathing", breathingActivity.Duration);
            break;
          case "2":
            ReflectionActivity reflectionActivity = new ReflectionActivity();
            reflectionActivity.Run();
            LogActivity(activityLog, "Reflection", reflectionActivity.Duration);
            break;
          case "3":
            ListingActivity listingActivity = new ListingActivity();
            listingActivity.Run();
            LogActivity(activityLog, "Listing", listingActivity.Duration);
            break;
          case "4":
            SaveLogToFile(activityLog);
            return; // Exit the program
          default:
            Console.WriteLine("Invalid option.");
            break;
        }

        Console.WriteLine();
      }
    }

    static void LogActivity(List<string> log, string activityName, int duration)
    {
      string logEntry = $"{DateTime.Now}: {activityName} - {duration} seconds";
      log.Add(logEntry);
      Console.WriteLine("Activity logged.");
    }

    static void SaveLogToFile(List<string> log)
    {
      try
      {
        File.WriteAllLines("activity_log.txt", log);
        Console.WriteLine("Log saved to activity_log.txt");
      }
      catch (Exception ex)
      {
        Console.WriteLine($"Error saving log: {ex.Message}");
      }
    }
  }
}