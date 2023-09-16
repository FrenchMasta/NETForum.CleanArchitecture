using Application;
using Infrastructure;
using Microsoft.OpenApi.Models;
using Presentation;

var builder = WebApplication.CreateBuilder(args);

ConfigureEndpointDiscoverability(builder);

ConfigureSwaggerGenSetup(builder);

builder.Services
    .AddApplication()
    .AddInfrastructure()
    .AddPresentation();

var app = builder.Build();

ConfigureSwaggerUISetup(app);

app.UseHttpsRedirection();

// NB!! YOU NEED THIS FOR API ENDPOINTS TO BE RESOLVED
app.MapControllers();

app.Run();

return;


void ConfigureEndpointDiscoverability(WebApplicationBuilder builder1)
{
    // For minimal APIs - SEE: https://stackoverflow.com/questions/71932980/what-is-addendpointsapiexplorer-in-asp-net-core-6/71933535#71933535
    builder1.Services.AddEndpointsApiExplorer();
    builder1.Services.AddControllers();
}

void ConfigureSwaggerGenSetup(WebApplicationBuilder webApplicationBuilder)
{
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    webApplicationBuilder.Services.AddSwaggerGen(options =>
    {
        options.SwaggerDoc("v1", new OpenApiInfo
        {
            Title = ".NET Forum - Clean Architecture",
            Version = "v1",
            Description = "The following are the API endpoints for the .NET Forum - Clean Architecture presentation"
        });
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