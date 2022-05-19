using Core.Models;

namespace BLL.Abstractions.Interfaces;

public interface ICommentService : IService<CommentModel>
{
    Task<List<CommentModel>> GetByMovieAsync(Guid movieId);
}
