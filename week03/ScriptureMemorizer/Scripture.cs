using System;

public class Scripture
{
  private Reference _reference;
  public Reference Reference { get { return _reference; } }

  private List<Word> _words;
  public List<Word> Words { get { return _words; } }

  public Scripture(Reference reference, string text)
  {
    _reference = reference;
    _words = text.Split(' ').Select(word => new Word(word)).ToList();
  }

  public void HideRandomWords(int numberToHide)
  {
    // More efficient way to hide random words
    var unhiddenWords = _words.Where(w => !w.IsHiddenCheck()).ToList();
    if (unhiddenWords.Count <= numberToHide)
    {
      foreach (var word in unhiddenWords)
      {
        word.Hide();
      }
    }
    else
    {
      Random random = new Random();
      for (int i = 0; i < numberToHide; i++)
      {
        int index = random.Next(unhiddenWords.Count);
        unhiddenWords[index].Hide();
        unhiddenWords.RemoveAt(index);
      }
    }
  }

  public string GetDisplayText()
  {
    return $"{_reference.GetDisplayText()} {string.Join(" ", _words.Select(w => w.GetDisplayText()))}";
  }

  public bool IsCompletelyHidden()
  {
    return _words.All(word => word.IsHiddenCheck());
  }
}