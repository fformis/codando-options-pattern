using Microsoft.Extensions.Options;

namespace CodandoOptionsPattern;

public class ConfigurationOptionsProvider(IOptions<ConfigurationOptions> options)
{
    private readonly IOptions<ConfigurationOptions> _options = options;

    public ConfigurationOptions GetOptions()
    {
        return _options.Value;
    }
}
