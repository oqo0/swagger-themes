using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace SwaggerThemes;

public static class SwaggerTheme
{
    private const string ThemesNamespace = "SwaggerThemes.Themes.";
    private const string BaseStylesFile = "_base.css";

    public static void UseSwaggerThemes(this WebApplication app, Theme theme, string? customStyles = null)
    {
        UseSwaggerThemes(app, theme.Value, customStyles);
    }
    
    public static void UseSwaggerThemes(this WebApplication app, string themeFile, string? customStyles = null)
    {
        string baseCssPath = "/themes/" + BaseStylesFile;
        string themeCssPath = "/themes/" + themeFile;
        string customCssPath = "/themes/custom.css";
        
        string baseCss = GetResourceText(BaseStylesFile);
        string themeCss = GetResourceText(themeFile);
        
        AddGetEndpoint(app, baseCssPath, baseCss);
        AddGetEndpoint(app, themeCssPath, themeCss);
        
        if (customStyles is not null)
            AddGetEndpoint(app, customCssPath, customStyles);
        
        app.UseSwaggerUI(options =>
        {
            options.InjectStylesheet(baseCssPath);
            options.InjectStylesheet(themeCssPath);

            if (customStyles is not null)
                options.InjectStylesheet(customCssPath);
        });
    }

    private static void AddGetEndpoint(WebApplication app, string cssPath, string styleText)
    {
        app.MapGet(cssPath, (HttpContext context) =>
            {
                context.Response.Headers["Cache-Control"] = "public, max-age=3600";
                context.Response.Headers["Expires"] = DateTime.UtcNow.AddDays(2).ToString("R");
                
                return Results.Content(styleText, "text/css");
            })
            .ExcludeFromDescription();
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