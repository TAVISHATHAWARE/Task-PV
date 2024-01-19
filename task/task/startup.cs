using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using task.DAL;

public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddDbContext<EventDbContext>(options =>
            options.UseInMemoryDatabase("EventDatabase"));

        services.AddControllers();

        // Swagger
        services.AddSwaggerGen();
    }

    public void Configure(IApplicationBuilder app)
    {
        app.UseRouting();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });

        // Swagger
        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "Event API V1");
        });
    }
}
