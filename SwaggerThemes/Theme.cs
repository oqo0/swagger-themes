namespace SwaggerThemes;

public class Theme
{
    private Theme(string value)
    {
        Value = value;
    }

    public string Value { get; private set; }

    public static Theme Dark => new ("dark.css");

    public override string ToString()
    {
        return Value;
    }
}