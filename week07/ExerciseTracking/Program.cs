using System;
using System.Collections.Generic;

public class Program
{
    public static void Main(string[] args)
    {
        List<Activity> activities = new List<Activity>();

        activities.Add(new Running(new DateTime(2023, 10, 26), 30, 5.0));
        activities.Add(new Cycling(new DateTime(2023, 10, 27), 45, 25.0));
        activities.Add(new Swimming(new DateTime(2023, 10, 28), 60, 50));

        foreach (var activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}