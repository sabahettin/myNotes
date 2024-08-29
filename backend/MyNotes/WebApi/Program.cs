using Application;
using DefaultCorsPolicyNugetPackage;
using Domain.Entities;
using Infrastructure;
using Microsoft.AspNetCore.Identity;
using WebApi.Helpers;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDefaultCors();
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();


CreateUserHelper.CreateUserAsync(app).Wait();

app.Run();
