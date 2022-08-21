using DIHelper;
using Inventory.Min.Data;

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

    public void RunCmd(
        IBootstraper booter
        , params string[] cmd)
    {
        booter.RunApp(cmd);
    }   
}