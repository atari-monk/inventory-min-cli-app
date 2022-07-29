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

    public void AssertItem(
        Item expected
        , Item actual)
    {
        Assert.True(actual?.Id > 0);
        Assert.Equal(expected.Name, actual?.Name);
        Assert.Equal(expected.Description, actual?.Description);
    }
}