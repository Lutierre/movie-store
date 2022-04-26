using MovieStore.Abstractions;
using MovieStore.Middlewares;
using MovieStore.ActionFilters;
using MovieStore.Models;
using MovieStore.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IService<Movie>, Service>();
builder.Services.AddTransient<TimerFilterAttribute>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseApiKey();

app.MapControllers();

app.Run();
