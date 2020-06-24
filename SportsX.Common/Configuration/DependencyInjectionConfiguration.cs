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


            //// Domain
            services.AddScoped(typeof(IClientTypeDomain), typeof(ClientTypeDomain));
            services.AddScoped(typeof(IClassificationDomain), typeof(ClassificationDomain));
        }
    }
}
