using Microsoft.EntityFrameworkCore;
using System.Reflection;
using VirtPlatform.Application.Users.Interfaces;
using VirtPlatform.Application.Users.Services;
using VirtPlatform.Domain.Interfaces.Repositories.Users;
using VirtPlatform.Infrastructure.Context;
using VirtPlatform.Infrastructure.Repositories.Users;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Establish connection with Database through the DbContext
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();

// For the AutoMapper Configuration
var mapperAssembly = Assembly.Load("VirtPlatform.Infrastructure");
builder.Services.AddAutoMapper(mapperAssembly);

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
