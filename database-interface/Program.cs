using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

using database_interface.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddLogging();

builder.Services.AddSingleton<MongoService>();

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthorization();
app.MapControllers();
app.Run("http://*:25052/");
