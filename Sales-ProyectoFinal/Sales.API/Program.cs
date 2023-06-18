using Microsoft.EntityFrameworkCore;
using Sales.Domain.Repository;
using Sales.Infrastructure.Context;
using Sales.Infrastructure.Interfaces;
using Sales.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//Registro de dependencia base de de datos //
builder.Services.AddDbContext<SaleContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("SaleContext")));


// Repositories //
builder.Services.AddTransient<IUsuarioRepository, UsuarioRepository>();

builder.Services.AddTransient<IRolRepository, RolRepository>();



// Registros de app services //

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
