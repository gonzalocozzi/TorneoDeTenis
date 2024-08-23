using Microsoft.EntityFrameworkCore;
using TorneoDeTenis.WebApi.Infraestructure.Data;
using TorneoDeTenis.WebApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Custom services
builder.Services.AddScoped<IEnfrentamientoStrategyFactory, EnfrentamientoStrategyFactory>();
builder.Services.AddSingleton<IRandomProvider, RandomProvider>();
builder.Services.AddScoped<ITorneoService, TorneoService>();

// Connect to the Database context and repositories
builder.Services.AddDbContext<TorneoDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<ITorneoRepository, TorneoRepository>();
builder.Services.AddScoped<IJugadorRepository, JugadorRepository>();

var app = builder.Build();

// Apply migrations automatically on startup
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<TorneoDbContext>();
    dbContext.Database.Migrate();
}

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
