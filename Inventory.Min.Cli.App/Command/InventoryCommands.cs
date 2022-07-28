using CommandDotNet;
using Config.Wrapper;
using CRUDCommandHelper;
using Inventory.Min.Lib;

namespace Inventory.Min.Cli.App;

[Command(MainCommand)]
public class InventoryCommands
    : Commands
{
    private const string MainCommand = "Inventory";

    private readonly IInsertCommand<ItemInsertArgs> insert;

    public InventoryCommands(
        IInsertCommand<ItemInsertArgs> insert
        , IConfigReader config)
            : base(config)
    {
        this.insert = insert;
    }

    [Command(InsertCmd)]
    public void Insert(ItemInsertArgs model)
    {
        insert.Insert(model);
    }
}