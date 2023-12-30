using Microsoft.Extensions.DependencyInjection;
using User.UseCases.Mappings;
using User.UseCases.Services;
using User.UseCases.Services.Interfaces;

namespace User.UseCases.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddLogic(this IServiceCollection collection)
    {
        collection.AddAutoMapper(typeof(ActivityMapping));
        collection.AddTransient<IUserService, UserService>();
        return collection;
    }
}