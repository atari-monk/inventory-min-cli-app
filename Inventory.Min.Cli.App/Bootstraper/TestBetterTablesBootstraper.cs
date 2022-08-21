using DIHelper;

namespace Inventory.Min.Cli.App;

public class TestBetterTablesBootstraper
    : Bootstraper
{
    protected override IDependencySuite GetMainAppSuite()
    {
        return new TestMode.BetterTableSuite(Container);
    }
}