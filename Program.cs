// using Microsoft.EntityFrameworkCore;
// using Microsoft.AspNetCore.Mvc;
// using CustomerBalancePlatform.Data;
// using NSwag;
// using NSwag.Generation.Processors.Security;

// var builder = WebApplication.CreateBuilder(args);

// // Add services to the container.
// builder.Services.AddControllers()
//     .AddNewtonsoftJson();

// // Entity Framework and Database Context
// builder.Services.AddDbContext<AppDbContext>(options =>
//     options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// // Register Swagger
// builder.Services.AddOpenApiDocument(config =>
// {
//     config.Title = "Customer Balance Platform API";
//     config.OperationProcessors.Add(new OperationSecurityScopeProcessor("JWT"));
//     config.AddSecurity("JWT", Enumerable.Empty<string>(), new OpenApiSecurityScheme
//     {
//         Type = OpenApiSecuritySchemeType.ApiKey,
//         Name = "Authorization",
//         In = OpenApiSecurityApiKeyLocation.Header,
//         Description = "Enter 'Bearer {your JWT token}'"
//     });
// });

// var app = builder.Build();

// // Correct Swagger setup
// if (app.Environment.IsDevelopment())
// {
//     app.UseDeveloperExceptionPage();
//     app.UseSwagger();
//     app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Customer Balance Platform API v1"));
// }

// app.UseHttpsRedirection();
// app.UseAuthorization();
// app.MapControllers();
// app.Run();

using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using CustomerBalancePlatform.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers()
    .AddNewtonsoftJson();

// Entity Framework and Database Context
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register Swagger
builder.Services.AddSwaggerDocument(configure =>
{
    configure.PostProcess = document =>
    {
        document.Info.Title = "Customer Balance Platform API";
        document.Info.Version = "v1";
    };
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseOpenApi(); // Serves the OpenAPI/Swagger JSON
app.UseSwaggerUi(); // Serves the Swagger UI at /swagger

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();


