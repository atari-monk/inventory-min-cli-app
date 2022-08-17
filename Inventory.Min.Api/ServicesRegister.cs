using Inventory.Min.Data;
using Inventory.Min.Data.Context.Prod;
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
        var server = builder.Configuration["DbServer"] ?? "localhost";
        var port = builder.Configuration["DbPort"] ?? "1443";
        var user = builder.Configuration["DbUser"] ?? "SA";
        var password = builder.Configuration["DbPassword"] ?? "Pa$$w0rd2019";
        var database = builder.Configuration["Database"] ?? "InventoryMinData";

        builder.Services.AddDbContext<InventoryDbContextApi>(options => 
            options.UseSqlServer($"Server={server},{port};Initial Catalog={database};User ID ={user};Password={password}"));
        
        builder.Services.AddScoped<IItemRepo, ItemRepo<InventoryDbContextApi>>();
        builder.Services.AddScoped<IInventoryUnitOfWork, InventoryUnitOfWork<InventoryDbContextApi>>();
    }
}