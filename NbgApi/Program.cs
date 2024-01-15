// Program.cs for a Web API

using DemoJwt.Models;
using DomainProject.Data;
using DomainProject.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using NbgApi.Services;
using System.Security.AccessControl;
using System.Text;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
 
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions
         .ReferenceHandler = ReferenceHandler.Preserve;
    });

//cors 1/3 
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

// swagger step 1/2
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// adding services
builder.Services.AddScoped<IWeatherForcastService, WeatherForcastService>();
builder.Services.AddScoped<ICustomerServices, CustomerServices>();
builder.Services.AddScoped<IProductServices, ProductServices>();
builder.Services.AddScoped<IBasketServices, BasketServices>();

var optionsCon =  builder.Configuration.GetConnectionString("MyConn");

// Apply pending migrations and create/update the database
var optionsBuilder = new DbContextOptionsBuilder<EshopDbContext>();
optionsBuilder.UseSqlServer(optionsCon);
using (var dbContext = new EshopDbContext(optionsBuilder.Options))
{
    dbContext.Database.Migrate();
}

builder.Services.AddDbContext<EshopDbContext>(options =>
        options.UseSqlServer(optionsCon));

//cors 2/3 
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("https://localhost:7077")
                                 .AllowAnyHeader()
                                 .AllowAnyMethod();
                      });
});

//security 1/2
// adding authentication
/**
 * ASP.NET Core middleware that enables an application to 
 * receive an OpenID Connect bearer token.
 * // reading the header from a request and parsing it
 * */

builder.Services.AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    }).AddJwtBearer(options =>
    {
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = "your-issuer",  // Replace with your issuer
        ValidAudience = "your-audience",  // Replace with your audience
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SecurityInfo.SecretKey))  // Replace with your secret key
    };
});

var app = builder.Build();

//swagger step 2/2
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Configure the HTTP request pipeline.
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

//security 2/2
app.UseAuthentication();

//cors 3/3
app.UseCors(MyAllowSpecificOrigins);

app.Run();