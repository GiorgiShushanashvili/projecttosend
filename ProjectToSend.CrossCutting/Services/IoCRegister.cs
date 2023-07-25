using Microsoft.Extensions.DependencyInjection;
using ProjectToSend.Contracts.Services;
using ProjectToSend.DataAccess.Contracts.Repositories;
using ProjectToSend.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheProjectToSend.Repositories;
using TheProjectToSend.Service;

namespace ProjectToSend.CrossCutting
{
    public static class IoCRegister
    {
        public static IServiceCollection AddCommonServices(this IServiceCollection services)
        {
            Addservies(services);
            AddRepositories(services);
            AddCorsService(services);
            return services;
        }

        private static IServiceCollection Addservies(IServiceCollection services)
        {
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IPersonService, PersonService>();
            return services;
        }
        private static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IGenderRepository, GenderRepository>();
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IPersonRepository, PersonRepository>();
            services.AddScoped<IUnitOfWorkRepository, UnitOfWorkRepository>();
            return services;
        }
        private static IServiceCollection AddCorsService(IServiceCollection services)
        {
            services.AddCors((opt) =>
            {
                opt.AddPolicy("DevCors", (corsBuilder) =>
                {
                    corsBuilder.WithOrigins("http://localhost:4200", "http://localhost:3000", "http://localhost:8000","http://localhost:7178")
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials();
                });
                opt.AddPolicy("ProdCors", (corsBuilder) =>
                {
                    corsBuilder.WithOrigins("")
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials();
                });
            });
            return services;
        }
    }
}
