using API.ActionFilters;
using API.Middlewares;
using BLL.Abstractions.Interfaces;
using BLL.Automapper.MappingProfiles;
using BLL.Services;
using Core.Models;
using DAL;
using DAL.Abstractions.Interfaces;
using DAL.Context;
using DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<MovieStoreContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
        optionsBuilder => optionsBuilder.MigrationsAssembly(typeof(MovieStoreContext).Assembly.FullName)));
builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddScoped<TimerFilterAttribute>();
builder.Services.AddScoped<IService<Movie>, MovieService>();
builder.Services.AddScoped<IService<Director>, DirectorService>();
builder.Services.AddScoped<UnitOfWork>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<GenreRepository>();

builder.Services.AddControllers().AddNewtonsoftJson(options =>
{
    options.SerializerSettings.ContractResolver = new DefaultContractResolver
    {
        NamingStrategy = new SnakeCaseNamingStrategy()
    };
});

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

app.UseMiddleware<ApiKeyMiddleware>();

app.MapControllers();

app.Run();
