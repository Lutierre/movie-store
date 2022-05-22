using Core.Models;
using Entities;

namespace BLL.Abstractions.Interfaces;

public interface IMovieService: ICommonService<MovieModel>
{
    Task<Movie?> GetEntityAsync(Guid movieId);
}
