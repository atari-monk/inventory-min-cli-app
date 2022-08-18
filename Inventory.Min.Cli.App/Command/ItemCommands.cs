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
    private readonly IUpdateCommand<ItemUpdateArgs> update;

    public ItemCommands(
        IReadCommand<ItemFilterArgs> read
        , IInsertCommand<ItemInsertArgs> insert
        , IUpdateCommand<ItemUpdateArgs> update
        , IConfigReader config)
            : base(config)
    {
        this.read = read;
        this.insert = insert;
        this.update = update;
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

    [Command(UpdateCmd)]
    public void Update(ItemUpdateArgs model)
    {
        update.Update(model);
        ReadAfterChange(GetReadTask(read, new ItemFilterArgs()));
    }
}