using Microsoft.EntityFrameworkCore;
using StarWars.Domain.Interfaces;
using StarWars.Domain.Services;
using StarWars.Infra.Data;
using StarWars.Infra.Data.Context;
using StarWars.Infra.Data.Repositories;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("SqliteConnectionString");

// Add services to the container.
builder.Services.AddDbContext<StarWarsContext>(x => x.UseSqlite(connectionString));
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    options.JsonSerializerOptions.WriteIndented = true;
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<SeedDataBase>();

builder.Services.AddScoped<IClimateRepository, ClimateRepository>();
builder.Services.AddScoped<IFilmRepository, FilmRepository>();
builder.Services.AddScoped<IPlanetRepository, PlanetRepository>();
builder.Services.AddScoped<ITerrainRepository, TerrainRepository>();
builder.Services.AddScoped<IPlanetService, PlanetService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // SeedDataBase(app);

    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

void SeedDataBase(IHost app)
{
    var scopedFactory = app.Services.GetService<IServiceScopeFactory>();

    using (var scope = scopedFactory.CreateScope())
    {
        var service = scope.ServiceProvider.GetService<SeedDataBase>();
        service.SeedClimates();
        service.SeedFilms();
        service.SeedTerrains();
        service.SeedPlanets();
    }
}