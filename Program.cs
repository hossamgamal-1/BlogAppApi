using BlogAppApi.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using BlogAppApi.Core;
using BlogAppApi.Features.Auth.Models;
using BlogAppApi.Features.Auth.Services;
using BlogAppApi.Features.Auth.Helpers;

var builder = WebApplication.CreateBuilder(args);

// Configure Identity
builder.Services.AddIdentity<AppUser,IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

// Add connection string to the database
string connectionStr = builder.Configuration.GetConnectionString("DefaultConnection")!;
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionStr));

// Configure Jwt
builder.Services.Configure<JWT>(builder.Configuration.GetSection("JWT"));
JwtConfigurator.Configure(builder);

// Configure Dependency Injection
builder.Services.AddScoped<IAuthService,AuthService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors();

var app = builder.Build();

// Configure the HTTP request pipeline.
if(app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(opt => opt.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();