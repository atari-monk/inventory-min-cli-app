using CLIHelper.Unity;
using Unity;

namespace Inventory.Min.Cli.App;

public class TestCliSuite 
    : CommandCliSuite
{
    public TestCliSuite(
        IUnityContainer container)
        : base(container)
    {
    }

    protected override void RegisterConsoleInput() => 
        RegisterSet<CliIODebugSet>();
}