using System;
using System.Collections.Generic;

public class Comment
{
    private string _commenterName;
    private string _commentText;

    public Comment(string commenterName, string commentText)
    {
        _commenterName = commenterName;
        _commentText = commentText;
    }

    public string CommenterName => _commenterName;
    public string CommentText => _commentText;
}

public class Video
{
    private string _title;
    private string _author;
    private int _lengthInSeconds;
    private List<Comment> _comments;

    public Video(string title, string author, int lengthInSeconds)
    {
        _title = title;
        _author = author;
        _lengthInSeconds = lengthInSeconds;
        _comments = new List<Comment>();
    }

    public string Title => _title;
    public string Author => _author;
    public int LengthInSeconds => _lengthInSeconds;
    public List<Comment> Comments => _comments;

    public void AddComment(Comment comment)
    {
        _comments.Add(comment);
    }

    public int GetNumberOfComments()
    {
        return _comments.Count;
    }
}

class Program
{
    static void Main()
    {
        // Create video objects
        Video video1 = new Video("How to Learn C#", "Programming Guru", 3600);
        video1.AddComment(new Comment("JIMBOY", "Great video, thanks!"));
        video1.AddComment(new Comment("MARITESS", "Very helpful."));
        video1.AddComment(new Comment("PANDECOCO", "Please make more of these."));

        Video video2 = new Video("Understanding Data Structures", "Dev Insights", 5400);
        video2.AddComment(new Comment("BANGUS21", "Clear and concise!"));
        video2.AddComment(new Comment("DANJESS08", "Liked the examples used here."));
        video2.AddComment(new Comment("EMAW", "Looking forward to the next part."));

        Video video3 = new Video("Intro to Algorithms", "Tech Teach", 4800);
        video3.AddComment(new Comment("UONG22", "This was a bit fast for me."));
        video3.AddComment(new Comment("BobMARS", "Well explained!"));

        // Store videos in a list
        List<Video> videos = new List<Video> { video1, video2, video3 };

        // Display information about each video
        foreach (Video video in videos)
        {
            Console.WriteLine($"Title: {video.Title}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Length: {video.LengthInSeconds} seconds");
            Console.WriteLine($"Number of Comments: {video.GetNumberOfComments()}");
            Console.WriteLine("Comments:");
            foreach (Comment comment in video.Comments)
            {
                Console.WriteLine($"\t{comment.CommenterName}: {comment.CommentText}");
            }
            Console.WriteLine();  
    }
}
}