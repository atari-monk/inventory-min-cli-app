using Inventory.Min.Data;

namespace Inventory.Min.Cli.App.Tests;

public class ItemUpdateData
{
    public static IEnumerable<object[]> Insert01 =>
        new List<object[]>
        {
            new object[] 
            {
                new string[] {"item", "ins", "insert"} 
            }
        };
    
    public static IEnumerable<object[]> Update01 =>
        new List<object[]>
        {
            new object[] 
            {
                GetItem((item) => item.Name = "update") 
                , new string[] {"item", "upd", "itemid", "-n", "update"} 
            }
            , new object[] 
            {
                GetItem((item) => item.Name = "update"
                    , (item) => item.Description = "descUpd") 
                , new string[] {"item", "upd", "itemid", "-d", "descUpd"} 
            }
        };
    
    private static Item GetItem()
    {
        return new Item {
            Name = "insert"
            , CurrencyId = 1
            , LengthUnitId = 1
            , VolumeUnitId = 1
            , MassUnitId = 3 };
    }

    private static Item GetItem(Action<Item> action)
    {
        var item = GetItem();
        action(item);
        return item;
    }

    private static Item GetItem(params Action<Item>[] actions)
    {
        var item = GetItem();
        foreach (var action in actions)
        {
            action(item);
        }
        return item;
    }
}