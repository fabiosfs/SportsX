using AutoMapper;
using SportsX.Common.ProfileConfiguration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace SportsX.Common.Configuration
{
    public static class MappingProfileConfiguration
    {
        public static void ConfigureProfilers(this IServiceCollection services, Type type)
        {
            services.AddAutoMapper(x =>
            {
                x.AddProfile(new ClientTypeProfile());
                x.AddProfile(new ClassificationProfile());
            }, type);
        }
    }
}
