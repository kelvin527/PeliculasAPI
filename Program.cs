using Microsoft.EntityFrameworkCore;
using PeliculasAPI.Entidades;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connection = builder.Configuration.GetConnectionString("connection");

builder.Services.AddDbContext<ContextDb>(x=> x.UseSqlServer(connection));
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
