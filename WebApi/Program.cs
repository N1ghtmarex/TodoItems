using Application;
using Domain;
using WebApi.StartupConfigurations.Swagger;

var builder = WebApplication.CreateBuilder(args);

builder.Services.RegisterDataAccessServices(builder.Configuration);

builder.Services.AddControllers();

builder.Services.RegisterUseCasesServices();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.ConfigureOwnSwagger();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyHeader();
        policy.AllowAnyMethod();
        policy.AllowAnyOrigin();
    });

});

var app = builder.Build();

app.ConfigureSwaggerUi();

app.MapControllers();

app.UseCors("AllowAll");

app.UseStaticFiles();

app.Run();
