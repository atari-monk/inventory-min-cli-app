using Inventory.Min.Data;
using Xunit;

namespace Inventory.Min.Cli.App.TestApi;

public abstract class ItemTestApi
    : AppTestApi
{
    protected static IEnumerable<Item>? GetItem(
        IInventoryUnitOfWork? unitOfWork)
    {
        return unitOfWork?.Item?.Get();
    }

    public void AssertItemCount(
        IInventoryUnitOfWork? repo
        , int expected)
    {
        var actual = GetItem(repo)?.Count();
        Assert.True(expected == actual);
    }

    public Item GetItem(
        IInventoryUnitOfWork? repo
        , int elementIndex)
    {
        var data = GetItem(repo)?.ElementAt(elementIndex);
        ArgumentNullException.ThrowIfNull(data);
        return data;
    }

    public void AssertInventory(
        Item expected
        , Item acctual)
    {
        Assert.True(acctual?.Id > 0);
        Assert.True(acctual?.Name == expected.Name);
        Assert.True(acctual?.Description == expected.Description);
    }
}