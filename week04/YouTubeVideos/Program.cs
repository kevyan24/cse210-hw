using System;
using System.Collections.Generic;

public class Program
{
  public static void Main(string[] args)
  {
    List<Video> videos = new List<Video>();

    Video video1 = new Video { Title = "Funny Cat Video", Author = "John Doe", Length = 120 };
    video1.Comments.Add(new Comment { CommenterName = "Alice", CommentText = "LOL!" });
    video1.Comments.Add(new Comment { CommenterName = "Bob", CommentText = "So cute!" });
    video1.Comments.Add(new Comment { CommenterName = "Charlie", CommentText = "Made my day." });
    videos.Add(video1);

    Video video2 = new Video { Title = "Coding Tutorial", Author = "Jane Smith", Length = 300 };
    video2.Comments.Add(new Comment { CommenterName = "David", CommentText = "Very helpful!" });
    video2.Comments.Add(new Comment { CommenterName = "Eve", CommentText = "Thanks for sharing." });
    videos.Add(video2);

    Video video3 = new Video { Title = "Travel Vlog", Author = "Mike Johnson", Length = 180 };
    video3.Comments.Add(new Comment { CommenterName = "Frank", CommentText = "Amazing place!" });
    video3.Comments.Add(new Comment { CommenterName = "Grace", CommentText = "I want to go there." });
    video3.Comments.Add(new Comment { CommenterName = "Henry", CommentText = "Beautiful scenery." });
    videos.Add(video3);

    Video video4 = new Video { Title = "Cooking Show", Author = "Sarah Lee", Length = 240 };
    video4.Comments.Add(new Comment { CommenterName = "Ivy", CommentText = "Yummy!" });
    video4.Comments.Add(new Comment { CommenterName = "Jack", CommentText = "I'll try this recipe." });
    videos.Add(video4);

    foreach (Video video in videos)
    {
      Console.WriteLine($"Title: {video.Title}");
      Console.WriteLine($"Author: {video.Author}");
      Console.WriteLine($"Length: {video.Length} seconds");
      Console.WriteLine($"Number of Comments: {video.GetNumberOfComments()}");
      Console.WriteLine("Comments:");
      foreach (Comment comment in video.Comments)
      {
        Console.WriteLine($"- {comment.CommenterName}: {comment.CommentText}");
      }
      Console.WriteLine();
    }

    Console.ReadKey();

  }
}