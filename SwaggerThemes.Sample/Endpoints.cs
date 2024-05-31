namespace SwaggerThemes.Sample;

public static class Endpoints
{
    public static WebApplication AddEndpoints(this WebApplication app)
    {
        app.MapGet("/get", () => "Result")
            .WithSampleInfo();
        app.MapPost("/post", () => "Result")
            .WithSampleInfo();
        app.MapPut("/put", () => "Result")
            .WithSampleInfo();
        app.MapDelete("/delete", () => "Result")
            .WithSampleInfo();
        app.MapPatch("/patch", () => "Result")
            .WithSampleInfo();
        
        return app;
    }

    private static RouteHandlerBuilder WithSampleInfo(this RouteHandlerBuilder routeHandlerBuilder)
    {
        routeHandlerBuilder
            .WithSummary("Method summary")
            .WithDescription("Sample description")
            .WithTags("Sample tag")
            .WithOpenApi();
        
        return routeHandlerBuilder;
    }
}