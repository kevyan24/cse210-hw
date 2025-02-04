using System;

public class Word
{
  private string _text;
  public string Text { get { return _text; } }

  private bool _isHidden;
  public bool IsHidden { get { return _isHidden; } set { _isHidden = value; } }

  public Word(string text)
  {
    _text = text;
    _isHidden = false;
  }

  public void Hide()
  {
    _isHidden = true;
  }

  public void Show()
  {
    _isHidden = false;
  }

  public bool IsHiddenCheck()
  {
    return _isHidden;
  }

  public string GetDisplayText()
  {
    return _isHidden ? new string('_', _text.Length) : _text;
  }
}
