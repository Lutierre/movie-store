using Core.Models;
using Entities;

namespace BLL.Abstractions.Interfaces;

public interface ICommentService : ICommonService<CommentModel>
{
    Task<List<CommentModel>> GetByMovieAsync(Guid movieId);

    Task<Comment?> GetEntityAsync(Guid commentId);
}
