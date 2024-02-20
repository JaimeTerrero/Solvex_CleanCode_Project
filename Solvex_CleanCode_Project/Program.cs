using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Reflection;
using System.Text;
using VirtPlatform.Application;
using VirtPlatform.Application.Assignments.Interfaces;
using VirtPlatform.Application.Assignments.Services;
using VirtPlatform.Application.Forums.Interfaces;
using VirtPlatform.Application.Forums.Services;
using VirtPlatform.Application.Subjects.Interfaces;
using VirtPlatform.Application.Subjects.Services;
using VirtPlatform.Application.Users.Interfaces;
using VirtPlatform.Application.Users.Services;
using VirtPlatform.Domain.Interfaces.Repositories.Assignments;
using VirtPlatform.Domain.Interfaces.Repositories.Forums;
using VirtPlatform.Domain.Interfaces.Repositories.Subjects;
using VirtPlatform.Domain.Interfaces.Repositories.Users;
using VirtPlatform.Infrastructure;
using VirtPlatform.Infrastructure.Context;
using VirtPlatform.Infrastructure.Repositories.Assignments;
using VirtPlatform.Infrastructure.Repositories.Forums;
using VirtPlatform.Infrastructure.Repositories.Subjects;
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

// Add services to the container
builder.Services
    .AddRepositories()
    .AddServices();

// For Token Implementation
builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("this is my custom Secret key for authentication")),
        ValidateAudience = false,
        ValidateIssuer = false
    };
});

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
