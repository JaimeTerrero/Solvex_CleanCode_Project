using Microsoft.EntityFrameworkCore;
using System.Reflection;
using VirtPlatform.Application.Users.Interfaces.Assignments;
using VirtPlatform.Application.Users.Interfaces.Forums;
using VirtPlatform.Application.Users.Interfaces.Subjects;
using VirtPlatform.Application.Users.Interfaces.Users;
using VirtPlatform.Application.Users.Services.Assignments;
using VirtPlatform.Application.Users.Services.Forums;
using VirtPlatform.Application.Users.Services.Subjects;
using VirtPlatform.Application.Users.Services.Users;
using VirtPlatform.Domain.Interfaces.Repositories.Assignments;
using VirtPlatform.Domain.Interfaces.Repositories.Forums;
using VirtPlatform.Domain.Interfaces.Repositories.Subjects;
using VirtPlatform.Domain.Interfaces.Repositories.Users;
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

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddScoped<IAssignmentRepository, AssignmentRepository>();
builder.Services.AddScoped<IAssignmentService, AssignmentService>();

builder.Services.AddScoped<ISubjectRepository, SubjectRepository>();
builder.Services.AddScoped<ISubjectService, SubjectService>();

builder.Services.AddScoped<IForumRepository, ForumRepository>();
builder.Services.AddScoped<IForumService, ForumService>();

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
