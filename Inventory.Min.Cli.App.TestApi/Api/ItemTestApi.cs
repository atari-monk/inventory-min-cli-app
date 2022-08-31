using Inventory.Min.Data;
using Xunit;

namespace Inventory.Min.Cli.App.TestApi;

public abstract class ItemTestApi
    : AppTestApi
{
    private readonly Dictionary<string, Action<Item, Item>> asserts;

    public ItemTestApi()
    {
        asserts = GetAsserts();
    }

    private Dictionary<string, Action<Item, Item>> GetAsserts()
    {
        return new Dictionary<string, Action<Item, Item>>
        {
              { nameof(Item.Id), (e, a) => Assert.True(a?.Id > 0) }
            , { nameof(Item.Name), (e, a) => Assert.Equal(e.Name, a?.Name) }
            , { nameof(Item.Description), (e, a) => Assert.Equal(e.Description, a?.Description) }
            , { nameof(Item.CategoryId), (e, a) => Assert.Equal(e.CategoryId, a?.CategoryId) }
            , { nameof(Item.InitialCount), (e, a) => Assert.Equal(e.InitialCount, a?.InitialCount) }
            , { nameof(Item.CurrentCount), (e, a) => Assert.Equal(e.CurrentCount, a?.CurrentCount) }
            , { nameof(Item.PurchaseDate), (e, a) => Assert.Equal(e.PurchaseDate, a?.PurchaseDate) }
            , { nameof(Item.CurrencyId), (e, a) => Assert.Equal(e.CurrencyId, a?.CurrencyId) }
            , { nameof(Item.PurchasePrice), (e, a) => Assert.Equal(e.PurchasePrice, a?.PurchasePrice) }
            , { nameof(Item.SellPrice), (e, a) => Assert.Equal(e.SellPrice, a?.SellPrice) }
            , { nameof(Item.ImagePath), (e, a) => Assert.Equal(e.ImagePath, a?.ImagePath) }
            , { nameof(Item.LengthUnitId), (e, a) => Assert.Equal(e.LengthUnitId, a?.LengthUnitId) }
            , { nameof(Item.Length), (e, a) => Assert.Equal(e.Length, a?.Length) }
            , { nameof(Item.Heigth), (e, a) => Assert.Equal(e.Heigth, a?.Heigth) }
            , { nameof(Item.Depth), (e, a) => Assert.Equal(e.Depth, a?.Depth) }
            , { nameof(Item.Diameter), (e, a) => Assert.Equal(e.Diameter, a?.Diameter) }
            , { nameof(Item.VolumeUnitId), (e, a) => Assert.Equal(e.VolumeUnitId, a?.VolumeUnitId) }
            , { nameof(Item.Volume), (e, a) => Assert.Equal(e.Volume, a?.Volume) }
            , { nameof(Item.Mass), (e, a) => Assert.Equal(e.Mass, a?.Mass) }
            , { nameof(Item.MassUnitId), (e, a) => Assert.Equal(e.MassUnitId, a?.MassUnitId) }
            , { nameof(Item.TagId), (e, a) => Assert.Equal(e.TagId, a?.TagId) }
            , { nameof(Item.StateId), (e, a) => Assert.Equal(e.StateId, a?.StateId) }
            , { nameof(Item.ParentId), (e, a) => Assert.Equal(e.ParentId, a?.ParentId) }
        };
    }

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
        foreach (var assert in asserts.Values)
        {
            assert(expected, actual);       
        }       
    }

    public void AssertItem(
        Item expected
        , Item actual
        , string key)
    {
        asserts[key](expected, actual);       
    }
}