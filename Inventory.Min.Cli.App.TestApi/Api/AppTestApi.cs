using DataToTable;
using DIHelper;
using Inventory.Min.Data;
using Inventory.Min.Table;

namespace Inventory.Min.Cli.App.TestApi;

public abstract class AppTestApi
{
    protected virtual Bootstraper GetBooter()
    {
        var booter = new Bootstraper();
        booter.CreateApp();
        return booter;
    }

    protected IInventoryUnitOfWork GetUnitOfWork(
        Bootstraper booter)
    {
        var unitOfWork = booter.MainSuite?.Resolve<IInventoryUnitOfWork>();
        ArgumentNullException.ThrowIfNull(unitOfWork);
        return unitOfWork;
    }

    protected ItemTable GetItemTable(
        Bootstraper booter)
    {
        var table = booter.MainSuite?.Resolve<IDataToText<Item>>();
        ArgumentNullException.ThrowIfNull(table);
        return (ItemTable)table;
    }

    public void RunCmd(
        IBootstraper booter
        , params string[] cmd)
    {
        booter.RunApp(cmd);
    }   
}