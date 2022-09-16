using AdoteUmPet.Core.CQRS.Mediator;
using AdoteUmPet.Domain.Interfaces;
using AdoteUmPet.Infrastructure.Contexts;
using AdoteUmPet.Infrastructure.Repositories;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Reflection;

namespace AdoteUmPet.API.Configurations
{
    public static class ServicesConfiguration
    {
        public static IServiceCollection AddServicesConfiguration(this IServiceCollection services)
        {
            services.AddScoped<IMediatorHandler, MediatorHandler>();
            services.AddScoped<IPetRepository, PetRepository>();
            
            services.AddDbContext<ApplicationDbContext>();

            services.AddMediatR(AppDomain.CurrentDomain.Load("AdoteUmPet.Application"));

            return services;
        }
    }
}
