public static class DependencyInjection
{
    public static IServiceCollection AddInfraestructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDatabase(configuration).AddServices();
        return services;
    }

    private static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<DatabaseOptions>(configuration.GetSection(DatabaseOptions.ConnectionStrings));
        services.Configure<DatabaseOptions>(configuration.GetSection(DatabaseOptions.DataStorageType));

        var databaseOptions = configuration.GetSection("DataStorageType").Get<DatabaseOptions>();

        if (databaseOptions.UseInMemoryStorage)
        {
            services.AddScoped<IPollRepository, PollRepositoryMemory>();
            services.AddScoped<IOptionsRepository, OptionsRepositoryMemory>();
        }
        else
        {
            services.AddScoped<IDatabaseConnection, DatabaseConnection>();
            services.AddScoped<IPollRepository, PollRepositoryDB>();
            services.AddScoped<IOptionsRepository, OptionsRepositoryDB>();
        }
        
        services.AddScoped<IDbInitializer, DbInitializer>();
        return services;
    }

    private static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<IPollService, PollService>();
        services.AddScoped<IOptionsService, OptionsService>();

        return services;
    }
}