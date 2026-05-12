using Microsoft.Extensions.Options;

namespace CodandoOptionsPattern;

public class ConfigurationOptionsMonitorProvider(IOptionsMonitor<ConfigurationOptions> options)
{
    private readonly IOptionsMonitor<ConfigurationOptions> _options = options;

    public ConfigurationOptions GetOptions()
    {
        return _options.CurrentValue;
    }
}