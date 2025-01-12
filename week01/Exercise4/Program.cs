using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        List<int> numbers = new List<int>();

        int number; 
        
        do {
            Console.Write("Enter a number: ");
            number = int.Parse(Console.ReadLine());
            if (number != 0)
                numbers.Add(number);
        }
        while (number != 0);

        float sum = 0;
        foreach (int num in numbers) {
            sum += num;
        }

        float sumAverage = sum / numbers.Count;

        int maxNumber = numbers[0];
        foreach (int num in numbers) {
            if (maxNumber < num) {
                maxNumber = num;
            }   
        }

        int minNumber = numbers[0];
        foreach (int num in numbers) {
            if (minNumber > num && num > 0) {
                minNumber = num; 
            }
        }

        Console.WriteLine($"The sum is: {sum}");
        Console.WriteLine($"The average is: {sumAverage:F2}");
        Console.WriteLine($"The maximum number is: {maxNumber}");
        Console.WriteLine($"The minimum positive number is: {minNumber}");

        numbers.Sort();
        foreach (int num in numbers) {
            Console.WriteLine($"{num}");
        }
    }
}