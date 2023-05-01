using Clean.Application.Interfaces;
using Clean.Application.Mappings;
using Clean.Application.Services;
using Clean.Domain.Account;
using Clean.Domain.Interfaces;
using Clean.Infra.Data.Context;
using Clean.Infra.Data.Identity;
using Clean.Infra.Data.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Clean.Infra.IoC
{
    public static class DependencyInjectionAPI
    {
        public static IServiceCollection AddInfrastructureAPI(
        this IServiceCollection services,
        IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(
        options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")
        , o => o.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();

            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IProductService, ProductService>();
            var myHanlders = AppDomain.CurrentDomain.Load("Clean.Application");
            services.AddMediatR((MediatRServiceConfiguration o) => o.RegisterServicesFromAssembly(myHanlders));

            services.AddAutoMapper(typeof(DomainToDTOMappingProfile).Assembly);

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.AddScoped<IAuthenticate, AuthenticateService>();

        

            return services;
        }
    }
}
