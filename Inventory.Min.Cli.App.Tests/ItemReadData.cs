using Inventory.Min.Data;

namespace Inventory.Min.Cli.App.Tests;

public class ItemReadData
{
    protected const string MainCmd = "item";
    protected const string Cmd = "ins";
    protected const string Name = "Name";
    protected const string Description = "Description";

    public static IEnumerable<object[]> Insert01 =>
        new List<object[]>
        {
            new object[] 
            {
                0
                , GetItem((item) => item.Description = Description) 
                , GetInsCmd("-d", Description)
            }
        };

    public static IEnumerable<object[]> Read01 =>
        new List<object[]>
        {
            new object[] 
            {
                0
                , GetReadCmd()
                , " Id{white} | Name | Description | Category | CategoryId |\r\n"
                +      " {id} | Name | Description |          |            |\r\n"
            }
        };

    protected static Item GetItem()
    {
        return new Item { Name = Name
            , CurrencyId = 1
            , LengthUnitId = 1
            , VolumeUnitId = 1
            , MassUnitId = 3 };
    }

    protected static Item GetItem(params Action<Item>[] actions)
    {
        var item = GetItem();
        foreach (var action in actions)
        {
            action(item);
        }
        return item;
    }

    protected static string[] GetInsCmd()
    {
        return new string[] { MainCmd, Cmd, Name };
    }

    protected static string[] GetInsCmd(params string[] args)
    {
        var list = new List<string>(GetInsCmd());
        list.AddRange(args);
        return list.ToArray();
    }

    protected static string[] GetReadCmd(params string[] args)
    {
        var list = new List<string>(new string[] { MainCmd });
        list.AddRange(args);
        return list.ToArray();
    }
}