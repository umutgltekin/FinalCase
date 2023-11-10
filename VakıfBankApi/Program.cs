using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System;
using System.Reflection;
using Vk.Api.Midleware;
using Vk.Data.Context;
using Vk.Data.Uow;
using Vk.Operation.Cqrs;
using Vk.Operation.Mapper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
string connectionstring = builder.Configuration.GetConnectionString("PostgreSqlConnection");
builder.Services.AddDbContext<VkContext>(opts => opts.UseNpgsql(connectionstring));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddMediatR(typeof(CreateUserCommand).GetTypeInfo().Assembly);

var configserilog=new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
Log.Logger= new LoggerConfiguration().ReadFrom.Configuration(configserilog).CreateLogger();
Log.Information("App setting");

var config = new MapperConfiguration(cfg =>
{
    cfg.AddProfile(new MapperConfig());

});
builder.Services.AddSingleton(config.CreateMapper());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseMiddleware<HartBeatMiddleware>();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
