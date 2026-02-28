using ButtaLoveAspire.ServiceDefaults;
using Typesense.Setup;

namespace SearchSvc;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.AddServiceDefaults();

        // Add services to the container.
        builder.Services.AddAuthorization();

        builder.Services.AddOpenApi();

        ////typesense uri string value from resource env vars
        //var typesenseUri = builder.Configuration["services:typesense:typesense:0"];
        //if (string.IsNullOrEmpty(typesenseUri))
        //    throw new InvalidOperationException("Typesense URI not found in config");
        //Uri? uri = new(typesenseUri);

        ////typesense api key
        //var typesenseApiKey = builder.Configuration["typesense-api-key"];
        //if (string.IsNullOrEmpty(typesenseApiKey))
        //    throw new InvalidOperationException("Typesense API key not found in config");

        ////typesense configuring api and uri nodes for use
        //builder.Services.AddTypesenseClient(config =>
        //{
        //    config.ApiKey = typesenseApiKey;
        //    config.Nodes =
        //    [
        //        new(uri.Host, uri.Port.ToString(), uri.Scheme)
        //    ];
        //});
        var app = builder.Build();

        app.MapDefaultEndpoints();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.Run();
    }
}
