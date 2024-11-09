public static class WebApplicationExtension
{
    public static WebApplication InitializeDatabade(this WebApplication app)
    {
        using(var scope = app.Services.CreateScope())
        {
            var dbInitializer = scope.ServiceProvider.GetRequiredService<IDbInitializer>();
            dbInitializer.InitializeDatabase();
            return app;
        }
    }
}