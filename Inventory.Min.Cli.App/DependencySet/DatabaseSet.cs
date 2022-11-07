using DIHelper.Unity;
using Inventory.Min.Data;
using Unity;

namespace Inventory.Min.Cli.App;

public class DatabaseSet 
    : UnityDependencySet
{
    public DatabaseSet(
        IUnityContainer container) 
            : base(container)
    {
    }

    public override void Register()
    {
        Container
            .RegisterSingleton<InventoryDbContext>()
            .RegisterSingleton<ICategoryRepo, CategoryRepo<InventoryDbContext>>()
            .RegisterSingleton<ICurrencyRepo, CurrencyRepo<InventoryDbContext>>()
            .RegisterSingleton<IStateRepo, StateRepo<InventoryDbContext>>()
            .RegisterSingleton<ITagRepo, TagRepo<InventoryDbContext>>()
            .RegisterSingleton<IUnitRepo, UnitRepo<InventoryDbContext>>()
            .RegisterSingleton<IItemRepo, ItemRepo<InventoryDbContext>>()
            .RegisterSingleton<IItemRepoAsync, ItemRepoAsync<InventoryDbContext>>()
            .RegisterSingleton<IInventoryUnitOfWork, InventoryUnitOfWork<InventoryDbContext>>();
    }
}