using System;
using System.Collections.Generic;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words;
    private Random _random;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();
        _random = new Random();

        string[] words = text.Split(' ');

        foreach (string word in words)
        {
            _words.Add(new Word(word));
        }
    }

    public void HideRandomWords(int amount)
    {
        List<Word> availableWords = new List<Word>();

        foreach (Word word in _words)
        {
            if (word.GetDisplayText() == word.GetText())
            {
                availableWords.Add(word);
            }
        }

        for (int i = 0; i < amount && availableWords.Count > 0; i++)
        {
            int number = _random.Next(availableWords.Count);

            availableWords[number].Hide();
            availableWords.RemoveAt(number);
        }
    }

    public string GetRenderedText()
    {
        string result = _reference.GetDisplayText() + "\n";

        foreach (Word word in _words)
        {
            result += word.GetDisplayText() + " ";
        }

        return result;
    }

    public bool IsCompletelyHidden()
    {
        foreach (Word word in _words)
        {
            if (word.GetDisplayText() == word.GetText())
            {
                return false;
            }
        }

        return true;
    }
}
