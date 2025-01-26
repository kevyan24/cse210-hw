using System;

public class Program
{
  public static void Main(string[] args)
  {
    Journal journal = new Journal();
    PromptGenerator promptGenerator = new PromptGenerator();

    bool running = true;
    while (running)
    {
      Console.WriteLine("\nJournal Menu:");
      Console.WriteLine("1. Write a new entry");
      Console.WriteLine("2. Display all entries");
      Console.WriteLine("3. Save the journal to a file");
      Console.WriteLine("4. Load the journal from a file");
      Console.WriteLine("5. Exit");

      Console.Write("Choose an option: ");
      string choice = Console.ReadLine();

      switch (choice)
      {
        case "1":
          string prompt = promptGenerator.GetRandomPrompt();
          Console.WriteLine($"\nPrompt: {prompt}");
          Console.Write("Response: ");
          string response = Console.ReadLine();
          Console.Write("Mood: "); 
          string mood = Console.ReadLine();
          string date = DateTime.Now.ToShortDateString();
          Entry newEntry = new Entry(date, prompt, response, mood);
          journal.AddEntry(newEntry);
          break;
        case "2":
          journal.DisplayAll();
          break;
        case "3":
          Console.Write("File name: ");
          string filenameToSave = Console.ReadLine();
          journal.SaveToFile(filenameToSave);
          Console.WriteLine("Journal saved successfully.");
          break;
        case "4":
          Console.Write("File name: ");
          string filenameToLoad = Console.ReadLine();
          journal.LoadFromFile(filenameToLoad);
          Console.WriteLine("Journal saved successfully.");
          break;
        case "5":
          running = false;
          break;
        default:
          Console.WriteLine("Invalid option.");
          break;
      }
    }
  }
}