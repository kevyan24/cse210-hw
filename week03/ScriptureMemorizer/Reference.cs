using System;

public class Reference
{
  private string _book;
  public string Book { get { return _book; } }

  private int _chapter;
  public int Chapter { get { return _chapter; } }

  private int _verse;
  public int Verse { get { return _verse; } }

  private int? _endVerse;
  public int? EndVerse { get { return _endVerse; } }

  public Reference(string book, int chapter, int verse)
  {
    _book = book;
    _chapter = chapter;
    _verse = verse;
    _endVerse = null;
  }

  public Reference(string book, int chapter, int startVerse, int endVerse)
  {
    _book = book;
    _chapter = chapter;
    _verse = startVerse;
    _endVerse = endVerse;
  }

  public string GetDisplayText()
  {
    return _endVerse.HasValue ? $"{_book} {_chapter}:{_verse}-{_endVerse}" : $"{_book} {_chapter}:{_verse}";
  }
}