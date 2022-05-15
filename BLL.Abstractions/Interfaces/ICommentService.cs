using Core.Models;

namespace BLL.Abstractions.Interfaces;

public interface ICommentService : IService<Comment>
{
    Task<List<Comment>> GetByMovieAsync(Guid movieId);
}
