using GheyomAlwadaqTask.API.Extensions;
using GheyomAlwadaqTask.DAL.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using GheyomAlwadaqTask.DAL.Entities;
using GheyomAlwadaqTask.DAL.Data.SeedData.JSONFilesDataTypes;
using AutoMapper;
using GheyomAlwadaqTask.API.Helpers;
using GheyomAlwadaqTask.BLL.Interfaces;

var builder = WebApplication.CreateBuilder(args);
var Configuration = builder.Configuration;

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddDbContext<GheyomAlwadaqContext>(options =>
{
    options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddApplicationServices();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", policy =>
    {
        policy.AllowAnyHeader().AllowAnyMethod().WithOrigins("https://localhost:4200", "http://localhost:4200");
    });
});
var app = builder.Build();

#region GetRequiredServices

var host = app;
using var scope = host.Services.CreateScope();
var serviceProvider = scope.ServiceProvider;
var loggerFactory = serviceProvider.GetRequiredService<ILoggerFactory>();
try
{
    var context = serviceProvider.GetRequiredService<GheyomAlwadaqContext>();
    await DataInitialization.Data_Initialize_Async(context, loggerFactory);
}
catch (Exception ex)
{
    var logger = loggerFactory.CreateLogger<Program>();
    logger.LogError(ex, "An error occurred during migration");
}
#endregion

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseRouting();
app.UseStaticFiles();
app.UseCors("CorsPolicy"); 
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
