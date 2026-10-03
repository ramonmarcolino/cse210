using System;
using System.Collections.Generic;
class Program
{
static void Main(string[] args)
{
// Create videos
Video video1 = new Video(
"Learn C# in 10 Minutes",
"Programming Academy",
600
);

    Video video2 = new Video(
        "How to Make Homemade Pizza",
        "Chef Mike",
        845
    );

    Video video3 = new Video(
        "Top 10 Travel Destinations",
        "Travel World",
        720
    );

    Video video4 = new Video(
        "Introduction to Photography",
        "Photo Pro",
        950
    );

    // Add comments to video 1
    video1.AddComment(new Comment(
        "Alice",
        "This was a really helpful introduction to C#!"
    ));

    video1.AddComment(new Comment(
        "Bob",
        "The examples were easy to understand."
    ));

    video1.AddComment(new Comment(
        "Carlos",
        "I learned a lot from this video."
    ));

    // Add comments to video 2
    video2.AddComment(new Comment(
        "David",
        "That pizza looks delicious!"
    ));

    video2.AddComment(new Comment(
        "Emma",
        "I am definitely going to try this recipe."
    ));

    video2.AddComment(new Comment(
        "Frank",
        "Great cooking tips!"
    ));

    video2.AddComment(new Comment(
        "Grace",
        "How long should I bake it for a crispy crust?"
    ));

    // Add comments to video 3
    video3.AddComment(new Comment(
        "Henry",
        "I really want to visit Japan someday."
    ));

    video3.AddComment(new Comment(
        "Isabella",
        "These destinations look amazing!"
    ));

    video3.AddComment(new Comment(
        "Jack",
        "I have already visited two of these places."
    ));

    // Add comments to video 4
    video4.AddComment(new Comment(
        "Karen",
        "The photography tips were very useful."
    ));

    video4.AddComment(new Comment(
        "Liam",
        "I just bought my first camera."
    ));

    video4.AddComment(new Comment(
        "Maria",
        "The explanation of lighting was excellent."
    ));

    video4.AddComment(new Comment(
        "Nathan",
        "Looking forward to practicing these techniques."
    ));

    // Put all videos into a list
    List<Video> videos = new List<Video>
    {
        video1,
        video2,
        video3,
        video4
    };

    // Display information about each video
    foreach (Video video in videos)
    {
        Console.WriteLine($"Title: {video.Title}");
        Console.WriteLine($"Author: {video.Author}");
        Console.WriteLine($"Length: {video.Length} seconds");
        Console.WriteLine($"Number of comments: {video.GetCommentCount()}");
        Console.WriteLine("Comments:");

        foreach (Comment comment in video.GetComments())
        {
            Console.WriteLine($"{comment.Name}: {comment.Text}");
        }

        Console.WriteLine();
        Console.WriteLine("----------------------------------------");
        Console.WriteLine();
    }
}

}