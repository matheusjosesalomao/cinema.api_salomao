using Api;
using Application;
using Domain.Services;
using IMDbAdapter.Mongo;

var builder = WebApplication.CreateBuilder(args);
ConfigurationManager configuration = builder.Configuration;

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Service
builder.Services.AddScoped<ICheckInService, CheckInService>();

//Adapter
//builder.Services.AddIMDbAdapter(configuration.
//    SafeGet<TmdbAdapterConfiguration>());

builder.Services.AddMongo(configuration.
    SafeGet<MongoDbAdpterConfiguration>());

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
