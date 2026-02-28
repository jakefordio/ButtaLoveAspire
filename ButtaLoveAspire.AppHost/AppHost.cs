using DotNetEnv;

//Load the .env.local file
Env.Load(".env.local");

//Get ready to build the distributed application
var builder = DistributedApplication.CreateBuilder(args);

//Retrieve values from the environment
string? stripeSecret = Environment.GetEnvironmentVariable("STRIPE_SECRET_KEY");
string? postgresPwd = Environment.GetEnvironmentVariable("POSTGRES_PASSWORD");
string? bdayDiscountCode = Environment.GetEnvironmentVariable("BIRTHDAY_DISCOUNT_CODE");
string? adminEmailJake = Environment.GetEnvironmentVariable("ADMIN_EMAIL_JAKE");
string? adminEmailAnnessia = Environment.GetEnvironmentVariable("ADMIN_EMAIL_ANNESSIA");

//Keycloak Service for Authentication
IResourceBuilder<KeycloakResource> keycloak = builder.AddKeycloak("keycloak", 11001)
    .WithDataVolume("keycloak-volume");

//TypeSense Service for lightweight search
IResourceBuilder<ContainerResource> typesense = builder.AddContainer("typesense", "typesense/typesense", "30.1")
    .WithArgs("--data-dir", "/data", "--api-key", "xyz", "--enable-cors")
    .WithVolume("typesense-data", "/data")
    .WithEndpoint(8108, 8108, name: "typesense");

//TypeSense Container for search service
var typesenseCtr = typesense.GetEndpoint("typesense");
//PostgreSQL Service for Database
IResourceBuilder<PostgresServerResource> pgService = builder.AddPostgres("postgres")
    .WithDataVolume("postgres-volume")
    .WithPgAdmin();

//PostgreSQL Database from above service
IResourceBuilder<PostgresDatabaseResource> pgDatabase = pgService.AddDatabase("ButtaLoveDb");

//Combine all services into the main API project
IResourceBuilder<ProjectResource> api = builder.AddProject<Projects.API>("api")
    .WithReference(keycloak)
    .WithReference(pgDatabase)
    .WithEnvironment("STRIPE_SECRET_KEY", stripeSecret)
    .WithEnvironment("POSTGRES_PASSWORD", postgresPwd)
    .WithEnvironment("BIRTHDAY_DISCOUNT_CODE", bdayDiscountCode)
    .WithEnvironment("ADMIN_EMAIL_JAKE", adminEmailJake)
    .WithEnvironment("ADMIN_EMAIL_ANNESSIA", adminEmailAnnessia)
    .WaitFor(keycloak)
    .WaitFor(pgDatabase);

//add another project for typesense, which is external
builder.AddProject<Projects.SearchSvc>("search-svc")
    .WithReference(typesenseCtr)
    .WaitFor(typesense);

//add frontend JavaScript web pageContent to the Aspire orchestration (technically "external" since it is not .net... just a folder)
//IResourceBuilder<Aspire.Hosting.JavaScript.JavaScriptAppResource> webapp = builder.AddJavaScriptApp("webapp", "../webapp")
//    .WithReference(api) // Injects 'services__api__http__0'
//    .WithHttpEndpoint(env: "PORT", port: 13001)
//    .WithExternalHttpEndpoints();

builder.Build().Run();
