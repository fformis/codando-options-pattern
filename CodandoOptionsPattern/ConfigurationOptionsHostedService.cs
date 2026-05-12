namespace CodandoOptionsPattern;

public class ConfigurationOptionsHostedService : BackgroundService
{
    private readonly ConfigurationOptionsProvider _optionsProvider;
    private readonly ConfigurationOptionsMonitorProvider _optionsMonitorProvider;
    public ConfigurationOptionsHostedService(ConfigurationOptionsProvider optionsProvider, ConfigurationOptionsMonitorProvider optionsMonitorProvider)
    {
        _optionsProvider = optionsProvider;
        _optionsMonitorProvider = optionsMonitorProvider;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {

            Console.WriteLine("Simulando mudança nas opções...");
            ConfigurationOptions options = _optionsProvider.GetOptions();
            Console.WriteLine(new
            {
                StringOption = options.StringOption,
                IntOption = options.IntOption,
                EnumOption = options.EnumOption,
                BoolOption = options.BoolOption
            });

            ConfigurationOptions optionsb = _optionsMonitorProvider.GetOptions();
            Console.WriteLine(new
            {
                StringOption = optionsb.StringOption,
                IntOption = optionsb.IntOption,
                EnumOption = optionsb.EnumOption,
                BoolOption = optionsb.BoolOption
            });

            await Task.Delay(1_000, stoppingToken);
        }
    }
}
