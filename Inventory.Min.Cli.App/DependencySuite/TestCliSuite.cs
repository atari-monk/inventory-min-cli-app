using CLIHelper.Unity;
using Serilog.Wrapper.Unity;
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

    protected override void RegisterAppData()
    {
        RegisterSet<TestSerilogSet>();
    }

    protected override void RegisterConsoleInput() => 
        RegisterSet<CliIOInMemSet>();
}