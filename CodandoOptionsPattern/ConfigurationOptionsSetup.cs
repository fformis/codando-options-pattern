using Microsoft.Extensions.Options;

namespace CodandoOptionsPattern;

public class ConfigurationOptionsSetup : IConfigureOptions<ConfigurationOptions>
{
    private readonly IConfiguration _configuration;

    public ConfigurationOptionsSetup(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public void Configure(ConfigurationOptions options)
    {
        _configuration.GetSection("ConfigurationOptions").Bind(options);
    }
}
