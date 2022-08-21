namespace Inventory.Min.Cli.App.TestApi;

public class InventoryBetterTablesFixture
    : InventoryFixture
{
    protected override Bootstraper GetBooter()
    {
        var booter = new TestBetterTablesBootstraper();
        booter.CreateApp();
        return booter;
    }
}
