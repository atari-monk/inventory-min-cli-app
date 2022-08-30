using XUnit.Helper;

namespace Inventory.Min.Cli.App.Tests.ItemTests;

public abstract class InventoryTest
    : OrderTest
{
    protected void SetValue(
        List<string> cmd
        , string key
        , string value)
    {
        cmd[GetIndex(cmd, key)] = value;
    }

    protected int GetIndex(List<string> cmd, string value)
    {
        return cmd.IndexOf(value);
    }    
}