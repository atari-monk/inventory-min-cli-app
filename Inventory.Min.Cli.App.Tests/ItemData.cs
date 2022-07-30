using Inventory.Min.Data;

namespace Inventory.Min.Cli.App.Tests;

public class ItemData
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
                , GetItem((item) => item.CategoryId = 1)
                , GetCmds("-c", "1")
            }
            ,
            new object[] 
            {
                3
                , GetItem((item) => item.PurchaseDate = new DateTime(2022, 7, 30)) 
                , GetCmds("-p", "30.07.2022")
            }
            ,
            new object[] 
            {
                4
                , GetItem((item) => item.CurrencyId = 1)
                , GetCmds("--currencyId", "1")
            }
            ,
            new object[] 
            {
                5
                , GetItem((item) => item.PurchasePrice = 10)
                , GetCmds("-u", "10")
            }
            ,
            new object[] 
            {
                6
                , GetItem((item) => item.SellPrice = 5)
                , GetCmds("-s", "5")
            }
        };

        private static Item GetItem()
        {
            return new Item { Name = Name, CurrencyId = 1 };
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