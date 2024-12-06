using System.Reflection;

namespace SwaggerThemes;

public class Theme
{
    private Theme(string fileName)
    {
        FileName = fileName;
    }

    public string FileName { get; private set; }

    internal string Text => GetEmbeddedResourceText(FileName);

    internal static Theme Base => new("_base.css");

    public static Theme Dracula => new ("dracula.css");
    
    public static Theme Gruvbox => new ("gruvbox.css");
    
    public static Theme Monokai => new ("monokai.css");
    
    public static Theme NordDark => new ("nord-dark.css");
    
    public static Theme OneDark => new ("one-dark.css");
    
    public static Theme UniversalDark => new ("universal-dark.css");
    
    public static Theme Vs2022 => new("vs2022.css");
    
    public static Theme XCodeLight => new ("x-code-light.css");
    
    public static Theme Sepia => new ("sepia.css");

    public override string ToString()
    {
        return FileName;
    }

    private static string GetEmbeddedResourceText(string embeddedResourcePath)
    {
        const string ThemesNamespace = "SwaggerThemes.Themes.";

        var currentAssembly = Assembly.GetExecutingAssembly();
        var resource = string.Concat(ThemesNamespace, embeddedResourcePath);

        using var stream = currentAssembly.GetManifestResourceStream(resource)
            ?? throw new ArgumentException($"Can't find embedded resource: {embeddedResourcePath}");

        using var reader = new StreamReader(stream);

        return reader.ReadToEnd();
    }
}