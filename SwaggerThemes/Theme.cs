namespace SwaggerThemes;

public class Theme
{
    private Theme(string value)
    {
        Value = value;
    }

    public string Value { get; private set; }

    public static Theme UniversalDark => new ("universal-dark.css");

    public static Theme Monokai => new("monokai.css");
    
    public static Theme Dracula => new("dracula.css");
    
    public static Theme OneDark => new("one-dark.css");
    
    public static Theme XCodeLight => new("x-code-light.css");
    
    public static Theme NordDark => new("nord-dark.css");

    public override string ToString()
    {
        return Value;
    }
}