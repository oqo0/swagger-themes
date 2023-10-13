using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace SwaggerThemes;

public static class SwaggerTheme
{
    private const string ThemesNamespace = "SwaggerThemes.Themes.";
    private const string VariablesFile = "_variables.css";

    public static void UseSwaggerTheme(this WebApplication app, Theme theme)
    {
        UseSwaggerThemes(app, theme.Value);
    }
    
    public static void UseSwaggerThemes(this WebApplication app, string themeFile)
    {
        string varsCssPath = "/themes/" + VariablesFile;
        string themeCssPath = "/themes/" + themeFile;
        
        string varsCss = GetResourceText(VariablesFile);
        string themeCss = GetResourceText(themeFile);
        
        app.MapGet(varsCssPath, () => Results.Content(varsCss, "text/css"))
            .ExcludeFromDescription();
        app.MapGet(themeCssPath, () => Results.Content(themeCss, "text/css"))
            .ExcludeFromDescription();
        
        app.UseSwaggerUI(options =>
        {
            options.InjectStylesheet(varsCssPath);
            options.InjectStylesheet(themeCssPath);
        });
    }

    private static string GetResourceText(string fileName)
    {
        var currentAssembly = Assembly.GetExecutingAssembly();
        var resource = string.Concat(ThemesNamespace, fileName);

        using var stream = currentAssembly.GetManifestResourceStream(resource);
        
        if (stream is null)
        {
            throw new NullReferenceException("Can't find theme resource.");
        }

        using var reader = new StreamReader(stream);
        
        return reader.ReadToEnd();
    }
}