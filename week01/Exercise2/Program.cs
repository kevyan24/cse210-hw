using System;
using System.Runtime.ConstrainedExecution;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your percentage? ");
        string percentage = Console.ReadLine();
        int percentageInt = int.Parse(percentage);

        string letter;

        if (percentageInt >= 90) {
            letter = "A";
        }
        else if (percentageInt >= 80) {
            letter = "B";
        }
        else if (percentageInt >= 70) {
            letter = "C";
        }
        else if (percentageInt >= 60) {
            letter = "D";
        }
        else {
            letter = "F";
        }

        string gradeSign;

        if (percentageInt % 10 >= 7 && !(letter == "A" || letter == "F")) {
            gradeSign = "+";
        }
        else if (percentageInt % 10 < 3 && !(letter == "F")) {
            gradeSign = "-";
        }
        else {
            gradeSign = "";
        }

        Console.WriteLine($"Your grade is {letter}{gradeSign}");
        
        if (percentageInt >= 70) {
            Console.WriteLine("You passed");
        }
        else {
            Console.WriteLine("Better luck next time!");
        }
    }
}