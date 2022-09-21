using AdoteUmPet.Core.CQRS.Mediator;
using AdoteUmPet.Domain.Interfaces;
using AdoteUmPet.Domain.Users;
using AdoteUmPet.Infrastructure.Contexts;
using AdoteUmPet.Infrastructure.Repositories;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using PetSavior.Core.Identity;
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
            services.AddScoped<IApplicationUserService<User>, ApplicationUserService<User>>();

            services.AddDbContext<ApplicationDbContext>();

            services.AddMediatR(AppDomain.CurrentDomain.Load("PetSavior.Application"));

            return services;
        }
    }
}
