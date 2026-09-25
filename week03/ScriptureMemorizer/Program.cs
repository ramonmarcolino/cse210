//Additional features: added new scriptures in the list with 5 scriptures

using System;
using System.Collections.Generic;

public class Program
{
    public static void Main(string[] args)
    {

        List<Scripture> scriptures = new List<Scripture>();

        scriptures.Add(new Scripture(
            new Reference("1 Nephi", 3, 7),
            "And it came to pass that I Nephi said unto my father " +
            "I will go and do the things which the Lord hath commanded " +
            "for I know that the Lord giveth no commandments unto the " +
            "children of men save he shall prepare a way for them that " +
            "they may accomplish the thing which he commandeth them"
        ));

        scriptures.Add(new Scripture(
            new Reference("2 Nephi", 31, 20),
            "Wherefore ye must press forward with a steadfastness in Christ " +
            "having a perfect brightness of hope and a love of God and of " +
            "all men Wherefore if ye shall press forward feasting upon the " +
            "word of Christ and endure to the end behold thus saith the " +
            "Father Ye shall have eternal life"
        ));

        scriptures.Add(new Scripture(
            new Reference("Mosiah", 2, 17),
            "And behold I tell you these things that ye may learn wisdom " +
            "that ye may learn that when ye are in the service of your " +
            "fellow beings ye are only in the service of your God"
        ));

        scriptures.Add(new Scripture(
            new Reference("Alma", 37, 6),
            "Now ye may suppose that this is foolishness in me but behold " +
            "I say unto you that by small and simple things are great " +
            "things brought to pass"
        ));

        scriptures.Add(new Scripture(
            new Reference("Moroni", 10, 4, 5),
            "And when ye shall receive these things I would exhort you " +
            "that ye would ask God the Eternal Father in the name of " +
            "Christ if these things are not true and if ye shall ask " +
            "with a sincere heart with real intent having faith in " +
            "Christ he will manifest the truth of it unto you by the " +
            "power of the Holy Ghost"
        ));

        Random random = new Random();

        int randomNumber = random.Next(scriptures.Count);

        Scripture scripture = scriptures[randomNumber];

        while (!scripture.IsCompletelyHidden())
        {
            Console.Clear();

            Console.WriteLine(scripture.GetRenderedText());
            Console.WriteLine();

            Console.Write("Press Enter to continue or type 'quit': ");
            string input = Console.ReadLine();

            if (input != null && input.ToLower() == "quit")
            {
                return;
            }

            scripture.HideRandomWords(3);
        }

        Console.Clear();

        Console.WriteLine(scripture.GetRenderedText());
        Console.WriteLine();
        Console.WriteLine("Congratulations! You memorized the scripture!");
    }
}
