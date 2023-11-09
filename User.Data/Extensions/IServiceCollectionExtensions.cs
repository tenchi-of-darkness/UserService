using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using User.Data.DbContext;
using User.Data.Mappings;
using User.Data.Repositories;
using User.UseCases.Repositories.Interfaces;

namespace User.Data.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddData(this IServiceCollection collection, IConfiguration configuration)
    {
        collection.AddTransient<IUserRepository, UserRepository>();
        collection.AddAutoMapper(typeof(ActivityDataMapping));
        collection.AddDbContext<ApplicationDbContext>(builder =>
        {
            builder.UseMySql(configuration.GetConnectionString("Default"), ServerVersion.AutoDetect(configuration.GetConnectionString("NoDatabase")),
                options =>
                {
                    options.UseNetTopologySuite();
                });
        });
        collection.AddTransient<IUserRepository, UserRepository>();
        return collection;
    }
}