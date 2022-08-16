using Inventory.Min.Data;
using Microsoft.EntityFrameworkCore;

namespace Inventory.Min.Api;

public class ServicesRegister
{
    private readonly WebApplicationBuilder builder;

    public ServicesRegister(WebApplicationBuilder builder)
    {
        this.builder = builder;
    }

    public void RegisterServices()
    {
        builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        builder.Services.AddDbContext<InventoryDbContext>(options => 
            options.UseSqlServer(
                builder.Configuration.GetConnectionString("InventoryConnection")));
        builder.Services.AddScoped<IItemRepo, ItemRepo>();
        builder.Services.AddScoped<IInventoryUnitOfWork, InventoryUnitOfWork>();
    }
}