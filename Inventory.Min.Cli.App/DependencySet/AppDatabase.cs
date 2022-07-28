using DIHelper.Unity;
using Inventory.Min.Data;
using Unity;

namespace Inventory.Min.Cli.App;

public class AppDatabase 
    : UnityDependencySet
{
    public AppDatabase(
        IUnityContainer container) 
            : base(container)
    {
    }

    public override void Register()
    {
        Container
            .RegisterSingleton<InventoryDbContext>()
            .RegisterSingleton<IItemRepo, ItemRepo>()
            .RegisterSingleton<IInventoryUnitOfWork, InventoryUnitOfWork>();
    }
}