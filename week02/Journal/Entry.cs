// Added the get and set auto-property

using System;

namespace JournalApp
{
    public class Entry
    {
        public string Date { get; set; }
        public string PromptText { get; set; }
        public string EntryText { get; set; }

        public Entry(string date, string promptText, string entryText)
        {
            Date = date;
            PromptText = promptText;
            EntryText = entryText;
        }

        public void Display()
        {
            Console.WriteLine($"Date: {Date} - Prompt: {PromptText}");
            Console.WriteLine($"Response: {EntryText}");
            Console.WriteLine(new string('-', 50));
        }

        public string ToFileFormat()
        {
            return $"{Date}~{PromptText}~{EntryText}";
        }
    }
}
