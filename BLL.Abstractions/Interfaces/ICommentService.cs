using Core.Models;

namespace BLL.Abstractions.Interfaces;

public interface ICommentService : ICommonService<CommentModel>
{
    Task<List<CommentModel>> GetByMovieAsync(Guid movieId);
}
