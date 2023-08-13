using Equifinance.Mock.API.Repository;
using Equifinance.Mock.API.Services;
using Equifinance.Mock.Core.Interfaces;
using Equifinance.Mock.Core.Interfaces.IRepository;
using Equifinance.Mock.Core.Interfaces.IService;
using Equifinance.Mock.Infrastructure.Data;
using Equifinance.Mock.Infrastructure.Helper;
using Equifinance.Mock.Infrastructure.Repository;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

namespace Equifinance.Mock.API.ServiceConfig
{
    public static class ServiceConfig
    {
        public static void AddCustomServices(this IServiceCollection services, string connectionString)
        {
            services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

            services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });

            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddMemoryCache();

            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddScoped<IAuthenticationRepository, AuthenticationRepository>();
            services.AddScoped<IProblemService, ProblemService>();
            services.AddScoped<IProblemRepository, ProblemRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            services.AddAutoMapper(typeof(MappingProfiles));

            services.AddFluentValidation();
            services.AddValidatorsFromAssemblyContaining<IAssemblyMarker>();
        }
    }
}
