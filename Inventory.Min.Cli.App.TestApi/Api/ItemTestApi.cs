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
        Assert.Equal(expected.PurchaseDate, actual?.PurchaseDate);
        Assert.Equal(expected.CurrencyId, actual?.CurrencyId);
        Assert.Equal(expected.PurchasePrice, actual?.PurchasePrice);
        Assert.Equal(expected.SellPrice, actual?.SellPrice);
        Assert.Equal(expected.ImagePath, actual?.ImagePath);
        Assert.Equal(expected.LengthUnitId, actual?.LengthUnitId);
        Assert.Equal(expected.Length, actual?.Length);
        Assert.Equal(expected.Heigth, actual?.Heigth);
        Assert.Equal(expected.Depth, actual?.Depth);
        Assert.Equal(expected.Diameter, actual?.Diameter);
        Assert.Equal(expected.VolumeUnitId, actual?.VolumeUnitId);
        Assert.Equal(expected.Volume, actual?.Volume);
        Assert.Equal(expected.TagId, actual?.TagId);
        Assert.Equal(expected.StateId, actual?.StateId);
    }
}