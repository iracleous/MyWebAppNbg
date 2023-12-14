using DomainProject.Data;
using DomainProject.Services;
using Microsoft.EntityFrameworkCore;

using NbgApi.Services;

var builder = WebApplication.CreateBuilder(args);

//cors 1 
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";


// Add services to the container.

builder.Services.AddControllers();

// swagger step 1
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();




builder.Services.AddScoped<IWeatherForcastService, WeatherForcastService>();
builder.Services.AddScoped<ICustomerServices, CustomerServices>();
builder.Services.AddScoped<IProductServices, ProductServices>();

var optionsCon =  builder.Configuration
           .GetConnectionString("MyConn");

using (var dbContext = new EshopDbContext( ))
{
    // Apply pending migrations and create/update the database
    dbContext.Database.Migrate();
}

builder.Services.AddDbContext<EshopDbContext>(options =>
        options.UseSqlServer(optionsCon));




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


//swagger step 2
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

//cors 3
app.UseCors(MyAllowSpecificOrigins);

app.Run();
