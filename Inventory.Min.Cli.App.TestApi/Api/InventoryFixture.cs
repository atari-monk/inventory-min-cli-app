using Inventory.Min.Data;
using Microsoft.EntityFrameworkCore.Storage;

namespace Inventory.Min.Cli.App.TestApi;

public class InventoryFixture
    : ItemTestApi
        , IDisposable
{
    public Bootstraper Booter { get; private set; }

    public IInventoryUnitOfWork Uow { get; private set; }

    public IDbContextTransaction Transaction { get; private set; }

    public bool KeepData { get; set; } = false;

    public Guid FixtureId { get; private set; }

    public InventoryFixture()
    {
        Booter = GetBooter();
        Uow = GetUnitOfWork(Booter);
        Transaction = Uow.BeginTransaction();
        FixtureId = Guid.NewGuid();
    }

    public void Dispose()
    {
        if(KeepData == false)
            Transaction.Rollback();
        else
            Transaction.Commit();
    }
}