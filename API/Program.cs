using Application;
using Infrastructure;
using Microsoft.OpenApi.Models;
using Presentation;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpContextAccessor();

ConfigureEndpointDiscoverability(builder);

ConfigureSwaggerGenSetup(builder);

builder.Services
    .AddApplicationServices()
    .AddInfrastructureServices()
    .AddPresentation();

var app = builder.Build();

ConfigureSwaggerUISetup(app);

app.UseHttpsRedirection();
app.MapControllers();

app.Run();

return;


void ConfigureEndpointDiscoverability(WebApplicationBuilder webApplicationBuilder)
{
    // For minimal APIs - SEE: https://stackoverflow.com/questions/71932980/what-is-addendpointsapiexplorer-in-asp-net-core-6/71933535#71933535
    webApplicationBuilder.Services.AddEndpointsApiExplorer();
    webApplicationBuilder.Services.AddControllers();
}

void ConfigureSwaggerGenSetup(WebApplicationBuilder webApplicationBuilder)
{
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    webApplicationBuilder.Services.AddSwaggerGen(options =>
    {
        options.SwaggerDoc("v1", new OpenApiInfo
        {
            Title = ".NET Forum - Clean Architecture",
            Version = "v3",
            Description = "The following are the API endpoints for the .NET Forum - Clean Architecture presentation - now with tests"
        });
        options.EnableAnnotations();
    });
}

void ConfigureSwaggerUISetup(WebApplication webApplication)
{
    if (!webApplication.Environment.IsDevelopment())
    {
        return;
    }

    webApplication.UseSwagger();
    webApplication.UseSwaggerUI();
}