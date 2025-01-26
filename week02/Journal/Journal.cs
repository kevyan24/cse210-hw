using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
  private List<Entry> _entries;

  public Journal()
  {
    _entries = new List<Entry>();
  }

  public void AddEntry(Entry newEntry)
  {
    _entries.Add(newEntry);
  }

  public void DisplayAll()
  {
    foreach (Entry entry in _entries)
    {
      entry.Display();
    }
  }

  public void SaveToFile(string filename)
  {
    using (StreamWriter outputFile = new StreamWriter(filename))
    {
      foreach (Entry entry in _entries)
      {
        outputFile.WriteLine($"{entry.Date}|{entry.PromptText}|{entry.EntryText}|{entry.Mood}");
      }
    }
  }

  public void LoadFromFile(string filename)
  {
    _entries.Clear();
    string[] lines = System.IO.File.ReadAllLines(filename);
    foreach (string line in lines)
    {
      string[] parts = line.Split('|');
      Entry entry = new Entry(parts[0], parts[1], parts[2], parts[3]);
      _entries.Add(entry);
    }
  }
}