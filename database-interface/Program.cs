using System.Threading;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

using DatabaseInterface.Controllers;
using DatabaseInterface.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers()
                .AddNewtonsoftJson(options => {
                  options.SerializerSettings.Converters.Add(new Newtonsoft.Json.Converters.StringEnumConverter());
                });
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddLogging();
builder.Services.AddCors(options =>
{
  options.AddPolicy("AllowLocalhostDebugging", builder =>
    builder
      .WithOrigins("http://localhost:5173")
      .AllowAnyMethod()
      .AllowAnyHeader()
      .AllowCredentials());
});

builder.Services.AddSingleton<IntegrityController>();
builder.Services.AddSingleton<NodeController>();

builder.Services.AddSingleton<IntegrityService>();
builder.Services.AddSingleton<MongoService>();

var app = builder.Build();

var dataIntegrityThread = new Thread(() =>
{
  app.Services
    .GetRequiredService<IntegrityService>()
    .StartDataMonitor();
});
dataIntegrityThread.Start();

app.UseSwagger();
app.UseSwaggerUI();

app.UseCors("AllowLocalhostDebugging");
app.UseAuthorization();
app.MapControllers();
app.Run("http://*:25052/");
