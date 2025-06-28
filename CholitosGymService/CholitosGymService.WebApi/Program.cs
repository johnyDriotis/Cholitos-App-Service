using CholitosGymService.Core.Interfaces;
using CholitosGymService.Core.UseCases;
using CholitosGymService.Core.UseCases.Interfaces;
using CholitosGymService.Infrastructure.Repository;

var builder = WebApplication.CreateBuilder(args);



#region Contenedor de servicios e inyeccion de dependencias.

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Get configuration of appsettings.json
IConfiguration configuration = builder.Configuration;

//Properties properties = new Properties(configuration);

// Other services
//builder.Services.AddScoped<IProperties, Properties>();
//builder.Services.AddAutoMapper(typeof(MapProfile));

// Repository services
//builder.Services.AddScoped<IConnectionManagerRepository, ConnectionManagerRepository>();
//builder.Services.AddScoped<IClientRepository, ClientRepository>();

// UseCases services
builder.Services.AddScoped<IClientUseCase, ClientUseCase>();

#endregion

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
