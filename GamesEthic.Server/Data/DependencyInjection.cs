using GamesEthic.Server.Data.Repositories;
using GamesEthic.Server.Data.Repositories.Interfaces;

namespace GamesEthic.Server.Data
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDataLayer(this IServiceCollection services)
        {
            services.AddScoped<IGameRepository, GameRepository>();
            return services;
        }
    }
}
