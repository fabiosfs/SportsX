using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SportsX.Repository.Context;
using SportsX.Repository.Interfaces;
using SportsX.Repository.Services;
using SportsX.Domain.Interfaces;
using SportsX.Domain.Services;
using AutoMapper;

namespace SportsX.Common.Configuration
{
    public static class DependencyInjectionConfiguration
    {
        // Classe para configuração das injeções de depêndencia
        public static void ConfigureDependencies(this IServiceCollection services)
        {
            // Context
            services.AddScoped<DbContext, SportsXDbContext>();

            //// Mapper
            services.AddScoped<IMapper, Mapper>(); 

            //// Repository
            services.AddScoped(typeof(IBaseRepository<,>), typeof(BaseRepository<,>));
            services.AddScoped(typeof(IClientTypeRepository), typeof(ClientTypeRepository));
            services.AddScoped(typeof(IClassificationRepository), typeof(ClassificationRepository));
            services.AddScoped(typeof(IClientRepository), typeof(ClientRepository));


            //// Domain
            services.AddScoped(typeof(IClientTypeDomain), typeof(ClientTypeDomain));
            services.AddScoped(typeof(IClassificationDomain), typeof(ClassificationDomain));
            services.AddScoped(typeof(IClientDomain), typeof(ClientDomain));
        }
    }
}
