using AutoMapper;
using SportsX.Common.ProfileConfiguration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace SportsX.Common.Configuration
{
    public static class MappingProfileConfiguration
    {
        // Classe para mapeamento do automapper
        public static void ConfigureProfilers(this IServiceCollection services, Type type)
        {
            services.AddAutoMapper(x =>
            {
                x.AddProfile(new ClientTypeProfile());
                x.AddProfile(new ClassificationProfile());
                x.AddProfile(new ClientProfile());
                x.AddProfile(new TelephoneProfile());
            }, type);
        }
    }
}
