using Cinema.Filmes.Api;
using Cinema.Filmes.Application;
using Cinema.Filmes.Domain.Services;
using Cinema.Filmes.TMDBAdapter;
using Cinema.Filmes.TMDBAdapter.Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);
ConfigurationManager configuration = builder.Configuration;

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Service
builder.Services.AddScoped<IFilmesService, FilmesService>();

//Adapter
builder.Services.AddIMDbAdapter(configuration.
    SafeGet<TmdbAdapterConfiguration>());

builder.Services.AddAutoMapperConfig();

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
