using CLIHelper;
using CommandDotNet.Helper;
using Config.Wrapper;
using DIHelper;
using Unity;

namespace Inventory.Min.Cli.App;

public class SettingSuite
{
    private readonly IConfigReader configReader;

    public SettingSuite(
        IConfigReader configReader)
    {
        this.configReader = configReader;
    }

    public IDependencySuite GetSuite(IUnityContainer unity)
    {
        var settings = configReader.GetConfigSection<CommandDotNetSettings>(
            nameof(CommandDotNetSettings));
        ArgumentNullException.ThrowIfNull(settings);
        var runMode = configReader.GetConfigSection<RunMode>(nameof(RunMode));
        ArgumentNullException.ThrowIfNull(runMode);
        if(runMode.Test)
            return new TestSuite(unity);
        if(settings.UseRepl)
            return new ReplSuite(unity);
        else
            return new CmdSuite(unity);
    }
}