using AutoMapper;
using BLL.Abstractions.Interfaces;
using Core.Models;
using DAL.Abstractions.Interfaces;
using Entities;

namespace BLL.Services;

internal class CommentService : CommonService<CommentModel, Comment>, ICommentService
{
    public CommentService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
    {
    }

    public async Task<List<CommentModel>> GetByMovieAsync(Guid movieId)
    {
        var comments =
            await _unitOfWork.CommentRepository.GetFilteredAsync(comment => comment.Movie.Id == movieId);
        var commentModels = _mapper.Map<List<CommentModel>>(comments);

        return commentModels;
    }

    public async Task<Comment?> GetEntityAsync(Guid commentId) => await _unitOfWork.CommentRepository.GetAsync(commentId);
}
