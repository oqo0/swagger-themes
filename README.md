<h1>
    <img height="32" src="SwaggerThemes/package-logo.png" alt="Logo">
    Swagger themes
</h1>

[![github publish workflow](https://github.com/oqo0/swagger-themes/actions/workflows/main.yml/badge.svg)](https://github.com/oqo0/swagger-themes/actions/workflows/main.yml)
[![github issues](https://img.shields.io/github/issues/oqo0/swagger-themes?&color=E0AF18)]()
[![github last commits](https://img.shields.io/github/last-commit/oqo0/swagger-themes)]()

Change Swagger documentation theme easily.

## 💾 Install
With NuGet CLI:
```
nuget install oqo0.SwaggerThemes
```
Using NuGet Package Manager:
https://www.nuget.org/packages/oqo0.SwaggerThemes/

## 📚 Usage
Select any theme from [themes list](#-themes) and apply it using following ways:
#### 📖 Using with Swashbuckle
```csharp
app.UseSwagger();
app.UseSwaggerUI(Theme.UniversalDark);
```

#### 📖 Using with NSwag
```csharp
app.UseOpenApi();
app.UseSwaggerUi(options =>
{
    options.CustomInlineStyles = SwaggerTheme.GetSwaggerThemeCss(Theme.UniversalDark);
});
```

#### 🔧 Adding custom CSS
```csharp
string customCss = "body {" +
                   "    background-color: red;" +
                   "}";

app.UseSwaggerUI(Theme.UniversalDark, customCss );
```

## 🎨 Themes

<table>

<tr>
<td>

<h3>Dracula</h3>

![alt text](assets/dracula.png)  

```csharp
Theme.Dracula
```

</td>

<td>

<h3>Gruvbox</h3>

![alt text](assets/gruvbox.png)  

```csharp
Theme.Gruvbox
```

</td>
</tr>

<tr>
<td>

<h3>Monokai</h3>

![alt text](assets/monokai.png)  

```csharp
Theme.Monokai
```

</td>

<td>

<h3>Nord Dark</h3>

![alt text](assets/nord-dark.png)  

```csharp
Theme.NordDark
```

</td>
</tr>

<tr>
<td>

<h3>One Dark</h3>

![alt text](assets/one-dark.png)  

```csharp
Theme.OneDark
```

</td>

<td>

<h3>Universal Dark</h3>

![alt text](assets/universal-dark.png)  

```csharp
Theme.UniversalDark
```

</td>
</tr>

<tr>
<td>

<h3>X-Code Light</h3>

![alt text](assets/x-code-light.png)  

```csharp
Theme.XCodeLight
```

</td>
<td>

<h3>Sepia</h3>

![alt text](assets/sepia.png)

```csharp
Theme.Sepia
```

</td>
</tr>

</table>

## 💡 Creating your own themes

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
dotnet build -c Release
```
6. Package `.nupkg` file is going to appear in `./bin/Release`