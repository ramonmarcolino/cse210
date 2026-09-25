public class Word
{
    private string _text;
    private string _displayText;

    public Word(string text)
    {
        _text = text;
        _displayText = text;
    }

    public void Hide()
    {
        _displayText = new string('_', _text.Length);
    }

    public string GetDisplayText()
    {
        return _displayText;
    }

    public string GetText()
    {
        return _text;
    }
}
