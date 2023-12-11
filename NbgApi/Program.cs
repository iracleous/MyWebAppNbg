using DomainProject.Data;
using DomainProject.Services;
using Microsoft.EntityFrameworkCore;

using NbgApi.Services;

var builder = WebApplication.CreateBuilder(args);

//cors 1 
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";


// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddScoped<IWeatherForcastService, WeatherForcastService>();
builder.Services.AddScoped<ICustomerServices, CustomerServices>();
builder.Services.AddScoped<IProductServices, ProductServices>();

builder.Services.AddDbContext<EshopDbContext>(options =>
        options.UseSqlServer(builder.Configuration
           .GetConnectionString("MyConn")));

 


//cors 2 
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


var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

//cors 3
app.UseCors(MyAllowSpecificOrigins);

app.Run();
