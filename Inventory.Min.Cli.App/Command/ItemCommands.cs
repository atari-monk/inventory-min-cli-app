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
    private readonly IDeleteCommand<DeleteArgs> delete;

    public ItemCommands(
        IReadCommand<ItemFilterArgs> read
        , IInsertCommand<ItemInsertArgs> insert
        , IUpdateCommand<ItemUpdateArgs> update
        , IDeleteCommand<DeleteArgs> delete
        , IConfigReader config)
            : base(config)
    {
        this.read = read;
        this.insert = insert;
        this.update = update;
        this.delete = delete;
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

    [Command(DeleteCmd)]
    public void Delete(DeleteArgs model)
    {
        delete.Delete(model);
        ReadAfterChange(GetReadTask(read, new ItemFilterArgs()));
    }
}