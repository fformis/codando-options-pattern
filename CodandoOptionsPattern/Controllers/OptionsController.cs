using Microsoft.AspNetCore.Mvc;

namespace CodandoOptionsPattern.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OptionsController : ControllerBase
{
    private readonly ConfigurationOptionsProvider _optionsProvider;
    private readonly ConfigurationOptionsSnapshotProvider _optionsSnapshotProvider;
    private readonly ConfigurationOptionsMonitorProvider _optionsMonitorProvider;

    public OptionsController(ConfigurationOptionsProvider optionsProvider, ConfigurationOptionsSnapshotProvider optionsSnapshotProvider, ConfigurationOptionsMonitorProvider optionsMonitorProvider)
    {
        _optionsProvider = optionsProvider;
        _optionsSnapshotProvider = optionsSnapshotProvider;
        _optionsMonitorProvider = optionsMonitorProvider;
    }

    [HttpGet("provider")]
    public IActionResult Get()
    {
        ConfigurationOptions options = _optionsProvider.GetOptions();
        return Ok(new
        {
            StringOption = options.StringOption,
            IntOption = options.IntOption,
            EnumOption = options.EnumOption,
            BoolOption = options.BoolOption
            });
        }

    [HttpGet("snapshot")]
    public IActionResult GetSnapshot()
    {
        ConfigurationOptions options = _optionsSnapshotProvider.GetOptions();
        return Ok(new
        {
            StringOption = options.StringOption,
            IntOption = options.IntOption,
            EnumOption = options.EnumOption,
            BoolOption = options.BoolOption
        });
    }

    [HttpGet("monitor")]
    public IActionResult GetMonitor()
    {
        ConfigurationOptions options = _optionsMonitorProvider.GetOptions();
        return Ok(new
        {
            StringOption = options.StringOption,
            IntOption = options.IntOption,
            EnumOption = options.EnumOption,
            BoolOption = options.BoolOption
        });
    }

}
