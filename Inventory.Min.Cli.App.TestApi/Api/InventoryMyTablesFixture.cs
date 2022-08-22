using Inventory.Min.Table;

namespace Inventory.Min.Cli.App.TestApi;

public class InventoryMyTablesFixture
    : InventoryFixture
{
    public ItemTable ItemTable { get; private set; }
    
    public InventoryMyTablesFixture()
    {
        ItemTable = GetItemTable(Booter);
    }
}