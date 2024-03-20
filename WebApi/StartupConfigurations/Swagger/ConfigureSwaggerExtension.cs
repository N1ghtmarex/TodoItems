using Microsoft.OpenApi.Models;

namespace WebApi.StartupConfigurations.Swagger
{
    public static class ConfigureSwaggerExtension
    {
        public static void ConfigureOwnSwagger(this IServiceCollection services)
        {
            var serviceProvider = services.BuildServiceProvider();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("admin", new OpenApiInfo { Title = "Todo.Admin.API", Version = "v1" });

                c.SupportNonNullableReferenceTypes();
            });
        }

        public static void ConfigureSwaggerUi(this IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();
            var env = serviceScope.ServiceProvider.GetRequiredService<IWebHostEnvironment>();

            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/admin/swagger.json", "Todo.Admin.API");
            });
        }
    }
}
