using CholitosAppFront.Infrastructure.Repository;
using CholitosGymService.Core.Interfaces.Configuration;
using CholitosGymService.Core.Interfaces.FingerPrint;
using CholitosGymService.Core.Interfaces.Repository;
using CholitosGymService.Core.UseCases;
using CholitosGymService.Core.UseCases.Interfaces;
using CholitosGymService.Infrastructure.FingerPrintBackground;
using CholitosGymService.Infrastructure.Repository;
using CholitosGymService.WebApi.Configuration;
using System.Data;
using System.Data.SqlClient;

var builder = WebApplication.CreateBuilder(args);

#region Inyeccion de servicios generales para la aplicacion
// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
#endregion

#region Inicializacion de configuraciones
// Get configuration of appsettings.json
IConfiguration configuration = builder.Configuration;

Properties properties = new Properties(configuration);
#endregion

#region Inyeccion de dependencias.

// Other services
builder.Services.AddScoped<IProperties, Properties>();
builder.Services.AddScoped<IFingerPrintProcess, FingerPrintProcess>();

// Register Sql connection with IdbConnection
builder.Services.AddScoped<IDbConnection, SqlConnection>(sp =>
{
    var connection = new SqlConnection(properties.ConnectionString);
    return connection;
});

// Repository
builder.Services.AddScoped<IConnectionManagerRepository, ConnectionManagerRepository>();
builder.Services.AddScoped<IClientRepository, ClientRepository>();

// UseCases
builder.Services.AddScoped<IClientUseCase, ClientUseCase>();
builder.Services.AddScoped<IFingerPrintUseCase, FingerPrintUseCase>();

#endregion

#region Middlewares
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
#endregion
