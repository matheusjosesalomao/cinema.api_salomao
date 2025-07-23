using Cinema.Bff.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient<UsuarioService>();
builder.Services.AddHttpClient<FilmesService>();
builder.Services.AddHttpClient<BilhetesService>();

builder.Services.AddControllers();
builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer("Bearer", options =>
    {
        options.Authority = "https://localhost:7240/";
        options.Audience = "cinema_api";
    });
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthorization();

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
