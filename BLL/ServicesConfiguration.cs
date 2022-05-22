using BLL.Abstractions.Interfaces;
using BLL.Automapper.MappingProfiles;
using BLL.Services;
using Microsoft.Extensions.DependencyInjection;

namespace BLL;

public static class ServicesConfiguration
{
    public static void AddBllServices(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(MappingProfile));
        
        services.AddScoped<IMovieService, MovieService>();
        services.AddScoped<ICommentService, CommentService>();
        services.AddScoped<IDirectorService, DirectorService>();
        services.AddScoped<IGenreService, GenreService>();
    }
}
