using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Swashbuckle.AspNetCore.SwaggerUI;
using System.Text;

namespace SwaggerThemes;

public static class SwaggerTheme
{
    /// <summary>
    /// Returns a CSS string for a specified Swagger theme.
    /// </summary>
    /// <param name="theme">The theme to be applied.</param>
    public static string GetSwaggerThemeCss(Theme theme)
    {
        var sb = new StringBuilder();

        sb.Append(Theme.Base.Text);
        sb.Append('\n');
        sb.Append(theme.Text);
        
        return sb.ToString();
    }

    /// <summary>
    /// Configures the Swagger UI with custom themes.
    /// </summary>
    /// <param name="app">The web application to which the Swagger UI is added.</param>
    /// <param name="theme">The theme to be applied to the Swagger UI.</param>
    /// <param name="customStyles">Optional custom styles to be applied to the Swagger UI.</param>
    /// <param name="setupAction">Additional swagger setup options</param>
    public static void UseSwaggerUI(
        this WebApplication app, Theme theme, string? customStyles = null, Action<SwaggerUIOptions>? setupAction = null)
    {
        string baseCssPath = "/themes/" + Theme.Base.FileName;
        string themeCssPath = "/themes/" + theme.FileName;
        string customCssPath = "/themes/" + "custom.css";

        AddGetEndpoint(app, baseCssPath, Theme.Base.Text);
        AddGetEndpoint(app, themeCssPath, theme.Text);
        
        if (customStyles is not null)
            AddGetEndpoint(app, customCssPath, customStyles);
        
        app.UseSwaggerUI(options =>
        {
            options.InjectStylesheet(baseCssPath);
            options.InjectStylesheet(themeCssPath);

            if (customStyles is not null)
                options.InjectStylesheet(customCssPath);

            setupAction?.Invoke(options);
        });
    }

    private static void AddGetEndpoint(WebApplication app, string cssPath, string styleText)
    {
        // MapGet always returns a RouteHandlerBuilder
        RouteHandlerBuilder builder = (RouteHandlerBuilder)app.MapGet(cssPath, (HttpContext context) =>
        {
            context.Response.Headers["Cache-Control"] = "public, max-age=3600";
            context.Response.Headers["Expires"] = DateTime.UtcNow.AddDays(2).ToString("R");
            return Results.Content(styleText, "text/css").ExecuteAsync(context);
        });
        builder.ExcludeFromDescription();
    }
}