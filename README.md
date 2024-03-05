<p align="left">
    <img width="10%" src="SwaggerThemes/package-logo.png">
    <h1>Swagger themes</h1>
</p>

[![github issues](https://img.shields.io/github/issues/oqo0/swagger-themes?&color=E0AF18)]()
[![github last commits](https://img.shields.io/github/last-commit/oqo0/swagger-themes)]()

Change Swagger documentation theme easily.

## Install
With NuGet CLI:
```
nuget install oqo0.SwaggerThemes
```
Using NuGet Package Manager:
https://www.nuget.org/packages/oqo0.SwaggerThemes/

## Usage
Select any theme from [themes list](#themes) and apply it using following ways:
#### Using with Swashbuckle
```csharp
app.UseSwagger();
app.UseSwaggerThemes(Theme.UniversalDark);
app.UseSwaggerUI();
```

> [!IMPORTANT] 
> Don't use `UseSwaggerUI()` before `UseSwaggerThemes()` or themes are not going to get installed.

#### Using with NSwag
```csharp
app.UseOpenApi();
app.UseSwaggerUi(options =>
{
    options.CustomInlineStyles = SwaggerTheme.GetSwaggerThemeCss(Theme.UniversalDarkx);
});
```

#### Adding custom CSS
```csharp
string customCss = "body {" +
                   "    background-color: red;" +
                   "}";

app.UseSwaggerThemes(Theme.UniversalDark, customCss );
```

## Themes
#### Dracula
![alt text](assets/dracula.png)
```csharp
Theme.Dracula
```

#### Gruvbox
![alt text](assets/gruvbox.png)
```csharp
Theme.Gruvbox
```

#### Monokai
![alt text](assets/monokai.png)
```csharp
Theme.Monokai
```

#### Nord Dark
![alt text](assets/nord-dark.png)
```csharp
Theme.NordDark
```

#### One Dark
![alt text](assets/one-dark.png)
```csharp
Theme.OneDark
```

#### Universal Dark
![alt text](assets/universal-dark.png)
```csharp
Theme.UniversalDark
```

#### X-Code Light
![alt text](assets/x-code-light.png)
```csharp
Theme.XCodeLight
```

## Creating your own themes

1. Create theme `.css` in `Themes` directory.
2. Add a placeholder for filename in `Theme.cs`:
```csharp
public static Theme YourTheme => new("your-theme.css");
```
3. Add an embedded resource for your `.css` file:
```xml
    ...
    <EmbeddedResource Include="Themes\your-theme.css" />
</ItemGroup>
```
4. Use any other complete theme as a template.
5. Build project:  
```
dotnet build --configuration Release
```