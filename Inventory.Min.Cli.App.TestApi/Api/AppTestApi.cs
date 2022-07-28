using DIHelper;
using Inventory.Min.Data;

namespace Inventory.Min.Cli.App.TestApi;

public abstract class AppTestApi
{
    protected InventoryBootstraper GetBooter()
    {
        var booter = new InventoryBootstraper();
        booter.CreateApp();
        return booter;
        throw new NotImplementedException();
    }

    protected IInventoryUnitOfWork GetUnitOfWork(
        InventoryBootstraper booter)
    {
        var unitOfWork = booter.Suite?.Resolve<IInventoryUnitOfWork>();
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