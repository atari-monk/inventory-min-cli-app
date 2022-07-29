using CommandDotNet;
using Config.Wrapper;
using CRUDCommandHelper;
using Inventory.Min.Lib;

namespace Inventory.Min.Cli.App;

[Command(MainCommand)]
public class ItemCommands
    : Commands
{
    private const string MainCommand = "item";

    private readonly IInsertCommand<ItemInsertArgs> insert;

    public ItemCommands(
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