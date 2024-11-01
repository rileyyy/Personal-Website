using System.Threading;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

using database_interface.Controllers;
using database_interface.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddLogging();

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

app.UseAuthorization();
app.MapControllers();
app.Run("http://*:25052/");
