using API.Data;
using ButtaLoveAspire.ServiceDefaults;
using Microsoft.EntityFrameworkCore;

namespace API;

public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.AddServiceDefaults();

        // Add services to the container.

        builder.Services.AddControllersWithViews();

        builder.Services.AddOpenApi();

        //keycloak authentication
        builder.Services.AddAuthentication().AddKeycloakJwtBearer(serviceName: "keycloak", realm: "buttalove", options =>
        {
            options.RequireHttpsMetadata = false;
            options.Audience = "buttalove";
        });

        //postgresql and entity database context
        builder.AddNpgsqlDbContext<ButtaLoveDbContext>("ButtaLoveDb");

        //Query String configurations
        builder.Services.Configure<RouteOptions>(options =>
        {
            options.LowercaseUrls = true;
            options.LowercaseQueryStrings = true;
        });

        var app = builder.Build();

        app.MapDefaultEndpoints();

        // Essential for Vanilla JS/HTML/CSS
        app.UseDefaultFiles(); // Automatically serves index.html
        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
        }
        app.UseStaticFiles(); // This is required to serve the images from wwwroot

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Use(async (context, next) =>
        {
            var request = context.Request;
            if (request.QueryString.HasValue)
            {
                // Check if any characters in the query string are uppercase
                if (request.QueryString.Value!.Any(char.IsUpper))
                {
                    var lowercaseQuery = request.QueryString.Value.ToLowerInvariant();
                    var newUrl = $"{request.Path}{lowercaseQuery}";

                    // Redirect to the lowercase version (Permanent 301 is best for SEO)
                    context.Response.Redirect(newUrl, permanent: true);
                    return;
                }
            }
            await next();
        });

        //seed data
        using var scope = app.Services.CreateScope();
        var services = scope.ServiceProvider;
        try
        {
            var context = services.GetRequiredService<ButtaLoveDbContext>();
            await context.Database.MigrateAsync();

        }
        catch (Exception ex)
        {
            var logger = services.GetRequiredService<ILogger<Program>>();
            logger.LogError(ex, "An error occurred migrating or seeding the database");
        }
        await app.RunAsync();
    }
}
