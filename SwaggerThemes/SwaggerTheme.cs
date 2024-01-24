using System.Reflection;
using System.Text;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace SwaggerThemes;

public static class SwaggerTheme
{
    private const string ThemesNamespace = "SwaggerThemes.Themes.";
    private const string BaseStylesFile = "_base.css";

    /// <summary>
    /// Returns a CSS string for a specified Swagger theme.
    /// </summary>
    /// <param name="theme">The theme to be applied.</param>
    public static string GetSwaggerThemeCss(Theme theme)
    {
        var sb = new StringBuilder();

        string baseCss = GetEmbeddedResourceText(BaseStylesFile);
        string themeCss = GetEmbeddedResourceText(theme.FileName);

        sb.Append(baseCss);
        sb.Append('\n');
        sb.Append(themeCss);
        
        return sb.ToString();
    }

    /// <summary>
    /// Configures the Swagger UI with custom themes.
    /// </summary>
    /// <param name="app">The web application to which the Swagger UI is added.</param>
    /// <param name="theme">The theme to be applied to the Swagger UI.</param>
    /// <param name="customStyles">Optional custom styles to be applied to the Swagger UI.</param>
    public static void UseSwaggerThemes(this WebApplication app, Theme theme, string? customStyles = null)
    {
        string baseCssPath = "/themes/" + BaseStylesFile;
        string themeCssPath = "/themes/" + theme.FileName;
        string customCssPath = "/themes/" + "custom.css";
        
        string baseCss = GetEmbeddedResourceText(BaseStylesFile);
        string themeCss = GetEmbeddedResourceText(theme.FileName);
        
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
    
    private static string GetEmbeddedResourceText(string embeddedResourcePath)
    {
        var currentAssembly = Assembly.GetExecutingAssembly();
        var resource = string.Concat(ThemesNamespace, embeddedResourcePath);

        using var stream = currentAssembly.GetManifestResourceStream(resource);
        
        if (stream is null)
        {
            throw new ArgumentException($"Can't find embedded resource: {embeddedResourcePath}");
        }

        using var reader = new StreamReader(stream);
        
        return reader.ReadToEnd();
    }
}