namespace Inventory.Min.Cli.App.Tests;

public class ItemReadBetterTablesData
    : ItemReadData
{
    public new static IEnumerable<object[]> Insert01 =>
        new List<object[]>
        {
            new object[] 
            {
                0
                , GetItem((item) => item.Description = Description) 
                , GetInsCmd("-d", Description)
            }
        };

    public new static IEnumerable<object[]> Read01 =>
        new List<object[]>
        {
            new object[] 
            {
                0
                , GetReadCmd()
                , "┌─────┐\r\n│ \u001b[38;2;255;0;255m Id\u001b[0m │\r\n├─────┤"
                +        "\r\n│ \u001b[38;2;255;255;0m{id}\u001b[0m │\r\n└─────┘\r\n"
            }
        };
}