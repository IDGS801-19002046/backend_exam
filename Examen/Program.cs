using Examen.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Obtener la cadena de conexion 
var connectionString = builder.Configuration.GetConnectionString("cadenaSQL");
// Agregamos la configuracion para SQL Server
builder.Services.AddDbContext<MotoGhostContext>(options =>
    options.UseSqlServer(connectionString));
// Definimos la nueva politica Cross-origin Resource Sharing
// (CORS o Uso compartido de recursos entre origenes) para que
// la API's sea accesible para cualquier aplicacion
builder.Services.AddCors(options =>
{
    options.AddPolicy("NuevaPolitica", app =>
    {
        app.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Activamos la nueva politica
app.UseCors("NuevaPolitica");

app.UseAuthorization();

app.MapControllers();

app.Run();
