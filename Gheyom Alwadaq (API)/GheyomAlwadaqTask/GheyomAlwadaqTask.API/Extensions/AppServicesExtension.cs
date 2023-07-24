using AutoMapper;
using GheyomAlwadaqTask.API.Helpers;
using GheyomAlwadaqTask.BLL.Interfaces;
using GheyomAlwadaqTask.BLL.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace GheyomAlwadaqTask.API.Extensions
{
    public static class AppServicesExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<ISubscriberRepository, SubscriberRepository>();
            services.AddScoped<ISubscribtionRepository, SubscribtionRepository>();
            services.AddScoped<IRreal_Estate_Repository, Rreal_Estate_Repository>();
            services.AddScoped<IInvoicesRepository, InvoicesRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddAutoMapper(typeof(MappingProfiles)); 
            services.AddScoped(provider => new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfiles(provider.GetService<IUnitOfWork>()));
            }).CreateMapper());
            return services;
        }
    }
}