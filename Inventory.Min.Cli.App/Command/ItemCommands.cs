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
    private readonly IReadCommand<ItemFilterArgs> read;
    private readonly IInsertCommand<ItemInsertArgs> insert;

    public ItemCommands(
        IReadCommand<ItemFilterArgs> read
        , IInsertCommand<ItemInsertArgs> insert
        , IConfigReader config)
            : base(config)
    {
        this.read = read;
        this.insert = insert;
    }

    [DefaultCommand()]
    public void Read(ItemFilterArgs model)
    {
        read.Read(model);
    }

    [Command(InsertCmd)]
    public void Insert(ItemInsertArgs model)
    {
        insert.Insert(model);
        ReadAfterChange(GetReadTask(read, new ItemFilterArgs()));
    }
}