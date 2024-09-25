using DefaultCorsPolicyNugetPackage;
using MarineWebsiteServer.WebAPI.Context;
using MarineWebsiteServer.WebAPI.Mapping;
using MarineWebsiteServer.WebAPI.Models;
using MarineWebsiteServer.WebAPI.Repositories;
using MarineWebsiteServer.WebAPI.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDefaultCors();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer"));
});

builder.Services.AddIdentity<AppUser, IdentityRole<Guid>>(options =>
{
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
    options.Password.RequiredLength = 8;
    options.SignIn.RequireConfirmedEmail = true;
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromSeconds(1);
    options.Lockout.MaxFailedAccessAttempts = 50;
    options.Lockout.AllowedForNewUsers = true;
}).AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();

builder.Services.AddMediatR(configuration =>
{
    configuration.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
});

builder.Services.AddScoped<HomeRepository>();
builder.Services.AddScoped<HomeService>();

builder.Services.AddScoped<HomeImageRepository>();
builder.Services.AddScoped<HomeImageService>();

builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);

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

app.Run();
