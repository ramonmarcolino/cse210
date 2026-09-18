using System;
using System.Collections.Generic;
using System.IO;

namespace JournalApp
{
    public class Journal // class
    {
        private List<Entry> _entries = new List<Entry>(); // new object(list)

        public void AddEntry(Entry newEntry) // method
        {
            _entries.Add(newEntry);  
        }

        public void DisplayAll() // method
        {
            if (_entries.Count == 0)
            {
                Console.WriteLine("\nThe journal is currently empty.");
                return;
            }

            Console.WriteLine("\n--- JOURNAL ENTRIES ---");

            foreach (Entry entry in _entries)
            {
                entry.Display();
            }
        }

        public void SaveToFile(string filename) // method
        {
            using (StreamWriter writer = new StreamWriter(filename))
            {
                foreach (Entry entry in _entries)
                {
                    writer.WriteLine(entry.ToFileFormat());
                }
            }

            Console.WriteLine("Journal saved successfully!");
        }

        public void LoadFromFile(string filename) // method
        {
            if (!File.Exists(filename))
            {
                Console.WriteLine("File not found.");
                return;
            }

            _entries.Clear();

            string[] lines = File.ReadAllLines(filename);

            foreach (string line in lines)
            {
                string[] parts = line.Split('~');

                if (parts.Length == 3)
                {
                    Entry entry = new Entry(
                        parts[0],
                        parts[1],
                        parts[2]
                    );

                    _entries.Add(entry);
                }
            }

            Console.WriteLine("Journal loaded successfully!");
        }
    }
}
