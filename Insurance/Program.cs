using FluentValidation;
using Insurance.Data;
using Insurance.Models;
using Microsoft.EntityFrameworkCore;
using Yodiwo.FEMP.ASP.Service.InfrastructureManagement.Validators;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
IConfiguration Configuration ; 

builder.Services.AddControllers();
builder.Services.AddScoped<IValidator<Customer>, CustomerRules>();

builder.Services.AddDbContext<InsuranceDbContext>(options => options.UseNpgsql(
builder.Configuration.GetConnectionString("InsuranceDatabase")));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
