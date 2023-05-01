using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace Clean.Infra.IoC
{
    public static class DependencyInjectionSwagger
    {
        public static IServiceCollection AddInfrastructureSwagger(this IServiceCollection services)
        {

            services.AddSwaggerGen(opt =>
            {
                opt.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = Microsoft.OpenApi.Models.SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = Microsoft.OpenApi.Models.ParameterLocation.Header
                });
                opt.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme ()
                        {
                            Reference = new OpenApiReference(){Type = ReferenceType.SecurityScheme,Id = "Bearer"}
                        },
                        new string[] { }
                    }
                });
            });


            return services;
        }
    }
}
