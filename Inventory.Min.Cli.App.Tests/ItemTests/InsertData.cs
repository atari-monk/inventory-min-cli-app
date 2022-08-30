using Inventory.Min.Data;

namespace Inventory.Min.Cli.App.Tests.ItemTests;

public class InsertData
{
    private const string MainCmd = "item";
    private const string Cmd = "ins";
    private const string Name = "Name";
    private const string Description = "Description";

    public static IEnumerable<object[]> Insert01 =>
        new List<object[]>
        {
            new object[] 
            {
                0
                , GetItem() 
                , GetCmds()
            }
            ,
            new object[]
            {
                1
                , GetItem((item) => item.Description = Description) 
                , GetCmds("-d", Description)
            }
            ,
            new object[] 
            {
                2
                , GetItem((item) => item.PurchaseDate = new DateTime(2022, 7, 30)) 
                , GetCmds("-p", "30.07.2022")
            }
            ,
            new object[] 
            {
                3
                , GetItem((item) => item.PurchasePrice = 10)
                , GetCmds("-u", "10")
            }
            ,
            new object[] 
            {
                4
                , GetItem((item) => item.SellPrice = 5)
                , GetCmds("-s", "5")
            }
            ,
            new object[] 
            {
                5
                , GetItem((item) => item.ImagePath = 
                    @"C:\kmazanek.gmail.com\Image\Inventory")
                , GetCmds("-i", @"C:\kmazanek.gmail.com\Image\Inventory")
            }
            ,
            new object[] 
            {
                6
                , GetItem((item) => item.Length = 99)
                , GetCmds("-l", "99")
            }
            ,
            new object[] 
            {
                7
                , GetItem((item) => item.Heigth = 56)
                , GetCmds("-e", "56")
            }
            ,
            new object[] 
            {
                8
                , GetItem((item) => item.Depth = 44)
                , GetCmds("--depth", "44")
            }
            ,
            new object[] 
            {
                9
                , GetItem((item) => item.Diameter = 66)
                , GetCmds("--diameter", "66")
            }
            ,
            new object[] 
            {
                10
                , GetItem((item) => item.Volume = 116)
                , GetCmds("--volume", "116")
            }
            ,
            new object[] 
            {
                11
                , GetItem((item) => item.InitialCount = 66)
                , GetCmds("-q", "66")
            }
            ,
             new object[] 
            {
                12
                , GetItem((item) => item.CurrentCount = 62)
                , GetCmds("--currentCount", "62")
            }
            ,
            new object[] 
            {
                13
                , GetItem((item) => item.Mass = 400)
                , GetCmds("--mass", "400")
            }
        };

    public static IEnumerable<object[]> Insert02 =>
        new List<object[]>
        {
            new object[] 
            {
                14
                , GetItem((item) => item.CategoryId = 1)
                , GetCmds("-c", "1")
            }
            ,
            new object[] 
            {
                15
                , GetItem((item) => item.CurrencyId = 1)
                , GetCmds("--currencyId", "1")
            }
            // ,
            // new object[] 
            // {
            //     2
            //     , GetItem((item) => item.LengthUnitId = 1)
            //     , GetCmds("--lengthUnitId", "1")
            // }
            // ,
            // new object[] 
            // {
            //     3
            //     , GetItem((item) => item.VolumeUnitId = 1)
            //     , GetCmds("--volumeUnitId", "1")
            // }
            // ,
            // new object[] 
            // {
            //     4
            //     , GetItem((item) => item.TagId = 2)
            //     , GetCmds("-t", "2")
            // }
            // ,
            // new object[] 
            // {
            //     5
            //     , GetItem((item) => item.StateId = 1)
            //     , GetCmds("-a", "1")
            // }
            // ,
            // new object[] 
            // {
            //     6
            //     , GetItem((item) => item.MassUnitId = 4)
            //     , GetCmds("--massUnitId", "4")
            // }
        };

    public static IEnumerable<object[]> Insert03 =>
        new List<object[]>
        {
            new object[]
            {
                GetItem((item) => item.Description = "test self ref") 
                , GetCmds("-d", "test self ref", "-r", "parentId")
            }
        };

    private static Item GetItem()
    {
        return new Item { 
            Name = Name
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

    private static string[] GetCmds()
    {
        return new string[] { MainCmd, Cmd, Name };
    }

    private static string[] GetCmds(params string[] args)
    {
        var list = new List<string>(GetCmds());
        list.AddRange(args);
        return list.ToArray();
    }
}