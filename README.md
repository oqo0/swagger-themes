# Swagger themes

[![github issues](https://img.shields.io/github/issues/oqo0/swagger-themes?&color=E0AF18)]()
[![github last commits](https://img.shields.io/github/last-commit/oqo0/swagger-themes)]()

Change Swagger documentation theme easily.

## Install
With NuGet CLI:
```
nuget install oqo0.SwaggerThemes
```
Using NuGet Package Manager:

## Usage
```csharp
app.UseSwagger();
app.UseSwaggerTheme(Theme.UniversalDark);
app.UseSwaggerUI();
```

> [!WARNING]  
> `UseSwaggerTheme()` should be placed prior to `UseSwaggerUI()`.

#### Adding custom CSS
```csharp
string customCss = "body {" +
                   "    background-color: red;" +
                   "}";

app.UseSwaggerTheme(Theme.UniversalDark, customCss );
```

## Themes
#### Dracula
![alt text](assets/dracula.png)
```csharp
app.UseSwaggerTheme(Theme.Dracula);
```

#### Monokai
![alt text](assets/monokai.png)
```csharp
app.UseSwaggerTheme(Theme.Monokai);
```

#### One Dark
![alt text](assets/one-dark.png)
```csharp
app.UseSwaggerTheme(Theme.OneDark);
```

#### Universal Dark
![alt text](assets/universal-dark.png)
```csharp
app.UseSwaggerTheme(Theme.UniversalDark);
```

#### X-Code Light
![alt text](assets/x-code-light.png)
```csharp
app.UseSwaggerTheme(Theme.XCodeLight);
```

> [!NOTE]  
> Create an issue if you have a suggestion for a theme.