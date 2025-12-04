using Microsoft.EntityFrameworkCore;
using PetEcommerce.Core;
using PetEcommerce.Core.Middleware;
using PetEcommerce.Infrastrcure;
using PetEcommerce.Service;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//builder.Services.AddDbContext<ApplicationDbContext>(options => 
//options.UseLazyLoadingProxies().UseSqlServer(builder.Configuration.GetConnectionString)));

builder.Services.AddInfrastructureDependencies(builder.Configuration)
    .AddServiceDependencyInjection()
    .AddCoreDependencyInjection();

builder.Services.AddControllers();
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

app.UseAuthorization();

app.UseMiddleware<GlobalExceptionMiddleware>();

app.MapControllers();

app.Run();
