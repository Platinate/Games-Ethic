using GamesEthic.Server.Services.Interfaces;
using GamesEthic.Server.Services.Mappings;

namespace GamesEthic.Server.Services
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddBusinessLogic(this IServiceCollection services)
        {
            services.AddScoped<IGameService, GameService>();
            services.AddScoped<IUserService, UserService>();
            return services;
        }
    }
}
