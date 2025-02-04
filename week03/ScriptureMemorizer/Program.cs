//A file with the essays was added and the program works with that file to display each of the essays before ending the program.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class Program
{
  static List<Scripture> scriptures = new List<Scripture>();

  public static void Main(string[] args)
  {
    LoadScriptures("scriptures.txt");

    if (scriptures.Count == 0)
    {
      Console.WriteLine("No scriptures were found. Please ensure that the 'scriptures.txt' file exists and is in the correct format.");
      return;
    }

    foreach (var scripture in scriptures)
    {
      Scripture currentScripture = scripture;
      while (true)
      {
        Console.Clear();
        Console.WriteLine(currentScripture.GetDisplayText());

        Console.WriteLine("\nPress Enter to hide words or type 'exit' to finish.");
        string input = Console.ReadLine();

        if (input.ToLower() == "exit")
        {
          return;
        }

        if (!currentScripture.IsCompletelyHidden())
        {
          currentScripture.HideRandomWords(3);
        }
        else
        {
          Console.WriteLine("Congratulations! You have memorized the scriptures.");
          Console.ReadKey(); 

          break;
        }
      }
    }

    Console.WriteLine("\nYou have completed all the essays. Thank you for participating!");
    Console.ReadKey();
  }

  static void LoadScriptures(string filename)
  {
    try
    {
      string[] lines = File.ReadAllLines(filename);

      for (int i = 0; i < lines.Length; i += 2)
      {
        string referenceLine = lines[i];
        string text = lines[i + 1];

        string[] referenceParts = referenceLine.Split(' ');
        string book = referenceParts[0];
        string chapterAndVerse = referenceParts[1];

        int chapter = 0;
        int startVerse = 0;
        int? endVerse = null;

        if (chapterAndVerse.Contains('-'))
        {
          string[] verses = chapterAndVerse.Split([':', '-']);
          if (int.TryParse(verses[0], out chapter) &&
              int.TryParse(verses[1], out startVerse))
          {
            int parsedEndVerse;
            if (int.TryParse(verses[2], out parsedEndVerse))
            {
              endVerse = parsedEndVerse;
            }
            else
            {
              Console.WriteLine($"Error: Invalid verse range format: {chapterAndVerse}");
              continue;
            }
          }
          else
          {
            Console.WriteLine($"Error: Invalid chapter or start verse format: {chapterAndVerse}");
            continue;
          }
        }
        else
        {
          string[] verses = chapterAndVerse.Split(':');
          if (int.TryParse(verses[0], out chapter) &&
              int.TryParse(verses[1], out startVerse))
          {
      
          }
          else
          {
            Console.WriteLine($"Error: Invalid chapter or verse format: {chapterAndVerse}");
            continue; 
          }
        }

        Reference referenceObj = endVerse.HasValue
            ? new Reference(book, chapter, startVerse, endVerse.Value)
            : new Reference(book, chapter, startVerse);

        Scripture scripture = new Scripture(referenceObj, text);
        scriptures.Add(scripture);
      }
    }
    catch (FileNotFoundException)
    {
      Console.WriteLine($"Error: File not found '{filename}'.");
    }
    catch (Exception ex)
    {
      Console.WriteLine($"Error loading the scriptures: {ex.Message}");
    }
  }
}