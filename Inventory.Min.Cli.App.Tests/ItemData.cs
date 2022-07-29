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
                , new Item { Name = Name } 
                , new string[] { MainCmd, Cmd, Name }
            }
            ,
            new object[]
            {
                1
                , new Item { Name = Name, Description = Description } 
                , new string[] { MainCmd, Cmd, Name, "-d", Description }
            }
            ,
            new object[] 
            {
                2
                , new Item { Name = Name, CategoryId = 1 } 
                , new string[] { MainCmd, Cmd, Name, "-c", "1" }
            }
        };
}