using Inventory.Min.Data;

namespace Inventory.Min.Cli.App.Tests.ItemTests;

public static class DataUtil
{
    private const string MainCmd = "item";
    private const string InsCmd = "ins";
    private const string UpdCmd = "upd";
    private const string DelCmd = "del";
    private const string ItemId = "itemid";
    public const string Name = "Nikola Tesla";
    public const string Description = "Electrical Engineer";
    public const string NameUpd = "Joscha Bach";
    public const string DescriptionUpd = "Computer Scientist";

    public static string[] GetReadCmd(params string[] args)
    {
        var list = new List<string>(new string[] { MainCmd });
        list.AddRange(args);
        return list.ToArray();
    }

    public static string[] GetInsCmd()
    {
        return new string[] { MainCmd, InsCmd, Name };
    }

    public static string[] GetDelCmd()
    {
        return new string[] { MainCmd, DelCmd, ItemId };
    }

    public static string[] GetInsCmd(params string[] args)
    {
        var list = new List<string>(GetInsCmd());
        list.AddRange(args);
        return list.ToArray();
    }

    public static string[] GetUpdCmd()
    {
        return new string[] { MainCmd, UpdCmd, ItemId };
    }

    public static string[] GetUpdCmd(params string[] args)
    {
        var list = new List<string>(GetUpdCmd());
        list.AddRange(args);
        return list.ToArray();
    }

    public static Item GetItem()
    {
        return new Item {
            Name = Name 
        };
    }

    public static Item GetItem(Action<Item> action)
    {
        var item = GetItem();
        action(item);
        return item;
    }

    public static Item GetItem(params Action<Item>[] actions)
    {
        var item = GetItem();
        foreach (var action in actions)
        {
            action(item);
        }
        return item;
    }
}