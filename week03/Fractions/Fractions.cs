using System;

public class Fractions
{
  private int _numerator;
  private int _denominator;

  public Fractions()
  {
    _numerator = 1;
    _denominator = 1;
  }

  public Fractions(int wholeNumber)
  {
    _numerator = wholeNumber;
    _denominator = 1;
  }

  public Fractions(int numerator, int denominator)
  {
    _numerator = numerator;
    _denominator = denominator;
  }

  public string GetFractionString()
  {
    return $"{_numerator}/{_denominator}";
  }

  public double GetDecimalValue()
  {
    return (double)_numerator / (double)_denominator;
  }
}