namespace CodandoOptionsPattern;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        IHostEnvironment env = builder.Environment;

        builder.Configuration.Sources.Clear();
        builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true)
                                .AddEnvironmentVariables();

        builder.Services.Configure<ConfigurationOptions>(builder.Configuration.GetSection("ConfigurationOptions"));
        builder.Services.ConfigureOptions<ConfigurationOptionsSetup>();
        builder.Services.AddSingleton<ConfigurationOptionsProvider>();
        builder.Services.AddScoped<ConfigurationOptionsSnapshotProvider>();
        builder.Services.AddSingleton<ConfigurationOptionsMonitorProvider>();
        builder.Services.AddHostedService<ConfigurationOptionsHostedService>();


        builder.Services.AddControllers();

        var app = builder.Build();

        app.MapControllers();

        app.Run();
    }
}
