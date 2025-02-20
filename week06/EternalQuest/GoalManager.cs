using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
  private List<Goal> _goals = new List<Goal>();
  private int _score;
  private string _filename = "goals.txt";

  public void Start()
  {
    LoadGoals();

    while (true)
    {
      Console.WriteLine("\nMenu Options:");
      Console.WriteLine("1. Create New Goal");
      Console.WriteLine("2. List Goals");
      Console.WriteLine("3. Save Goals");
      Console.WriteLine("4. Load Goals");
      Console.WriteLine("5. Record Event");
      Console.WriteLine("6. Display User Info");
      Console.WriteLine("7. Exit");
      Console.Write("Select a choice from the menu: ");
      string choice = Console.ReadLine();

      switch (choice)
      {
        case "1":
          CreateGoal();
          break;
        case "2":
          ListGoalDetails();
          break;
        case "3":
          SaveGoals();
          break;
        case "4":
          LoadGoals();
          break;
        case "5":
          RecordEvent();
          break;
        case "6":
          DisplayUserInfo(); 
          break;
        case "7": 
          return;
        default:
          Console.WriteLine("Invalid choice.");
          break;
      }
    }
  }

  public void DisplayUserInfo() 
  {
    Console.WriteLine($"\nYou have {_score} points.");
  }

  public void ListGoalDetails()
  {
    Console.WriteLine("\nThe goals are:");
    for (int i = 0; i < _goals.Count; i++)
    {
      Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
    }
  }

  public void CreateGoal()
  {
    Console.WriteLine("\nThe types of Goals are:");
    Console.WriteLine("1. Simple Goal");
    Console.WriteLine("2. Eternal Goal");
    Console.WriteLine("3. Checklist Goal");
    Console.Write("Which type of goal would you like to create? ");
    string goalType = Console.ReadLine();

    Console.Write("What is the name of your goal? ");
    string name = Console.ReadLine();
    Console.Write("What is a short description of it? ");
    string description = Console.ReadLine();

    int points;
    Console.Write("What is the amount of points associated with this goal? ");
    string pointsInput = Console.ReadLine();

    if (!int.TryParse(pointsInput, out points))
    {
      Console.WriteLine("Invalid points input. Please enter a valid number.");
      return;
    }

    switch (goalType)
    {
      case "1":
        _goals.Add(new SimpleGoal(name, description, points));
        break;
      case "2":
        _goals.Add(new EternalGoal(name, description, points));
        break;
      case "3":
        int target;
        Console.Write("How many times does this goal need to be accomplished for a bonus? ");
        string targetInput = Console.ReadLine();
        if (!int.TryParse(targetInput, out target))
        {
          Console.WriteLine("Invalid target input. Please enter a valid number.");
          return;
        }

        int bonus;
        Console.Write("What is the bonus for accomplishing it that many times? ");
        string bonusInput = Console.ReadLine();
        if (!int.TryParse(bonusInput, out bonus))
        {
          Console.WriteLine("Invalid bonus input. Please enter a valid number.");
          return;
        }
        _goals.Add(new ChecklistGoal(name, description, points, target, bonus));
        break;
      default:
        Console.WriteLine("Invalid goal type.");
        break;
    }
  }

  public void RecordEvent()
  {
    ListGoalDetails();
    Console.Write("Which goal did you accomplish? ");
    int goalIndex = int.Parse(Console.ReadLine()) - 1;

    if (goalIndex >= 0 && goalIndex < _goals.Count)
    {
      _goals[goalIndex].RecordEvent();
      if (_goals[goalIndex].IsComplete())
      {
        if (_goals[goalIndex] is ChecklistGoal checklistGoal)
        {
          _score += checklistGoal.GetPoints() + checklistGoal.GetBonus();
        }
        else
        {
          _score += _goals[goalIndex].GetPoints();
        }
      }
      else
      {
        _score += _goals[goalIndex].GetPoints();
      }
      Console.WriteLine("Event recorded!");
    }
    else
    {
      Console.WriteLine("Invalid goal index.");
    }
  }

  public void SaveGoals()
  {
    using (StreamWriter outputFile = new StreamWriter(_filename))
    {
      outputFile.WriteLine(_score);
      foreach (Goal goal in _goals)
      {
        outputFile.WriteLine(goal.GetStringRepresentation());
      }
    }
    Console.WriteLine("Goals saved!");
  }

  public void LoadGoals()
  {
    if (File.Exists(_filename))
    {
      string[] lines = File.ReadAllLines(_filename);
      _score = int.Parse(lines[0]);
      _goals.Clear();

      for (int i = 1; i < lines.Length; i++)
      {
        string[] parts = lines[i].Split(':');
        string[] goalData = parts[1].Split(',');

        switch (parts[0])
        {
          case "SimpleGoal":
            SimpleGoal simpleGoal = new SimpleGoal(goalData[0], goalData[1], int.Parse(goalData[2]));
            simpleGoal.SetIsComplete(bool.Parse(goalData[3]));
            _goals.Add(simpleGoal);
            break;
          case "EternalGoal":
            _goals.Add(new EternalGoal(goalData[0], goalData[1], int.Parse(goalData[2])));
            break;
          case "ChecklistGoal":
            ChecklistGoal checklistGoal = new ChecklistGoal(goalData[0], goalData[1], int.Parse(goalData[2]), int.Parse(goalData[3]), int.Parse(goalData[4]));
            checklistGoal.SetAmountCompleted(int.Parse(goalData[5]));
            _goals.Add(checklistGoal);
            break;
        }
      }
      Console.WriteLine("Goals loaded!");
    }
    else
    {
      Console.WriteLine("No saved goals found.");
    }
  }
}