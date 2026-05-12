using Microsoft.Extensions.Options;

namespace CodandoOptionsPattern;

public class ConfigurationOptionsSnapshotProvider(IOptionsSnapshot<ConfigurationOptions> options)
{
    private readonly IOptionsSnapshot<ConfigurationOptions> _options = options;

    public ConfigurationOptions GetOptions()
    {
        return _options.Value;
    }
}
