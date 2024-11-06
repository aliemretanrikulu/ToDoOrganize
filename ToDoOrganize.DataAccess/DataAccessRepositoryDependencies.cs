using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using ToDoOrganize.DataAccess.Abstracts;
using ToDoOrganize.DataAccess.Concretes;
using ToDoOrganize.DataAccess.Contexts;

namespace ToDoOrganize.DataAccess;

public static class DataAccessRepositoryDependencies
{
    public static IServiceCollection AddDataAccessDependencies(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IToDoRepository, EfToDoRepository>();
        services.AddScoped<ICategoryRepository, EfCategoryRepository>();
        services.AddDbContext<BaseDbContext>(opt => {
            opt.UseSqlServer(configuration.GetConnectionString("SqlConnection"), options =>
            {
                options.MigrationsAssembly(Assembly.GetAssembly(typeof(BaseDbContext)).GetName().Name);
            });


        });
        return services;
    }
}