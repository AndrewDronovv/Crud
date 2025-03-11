using Crud.BusinessLogic.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Crud.BusinessLogic;

public static class Extensions
{
    public static IServiceCollection AddBusinessLogic(this IServiceCollection services)
    {
        services.AddScoped<INoteService, NoteService>();
        return services;
    }
}
