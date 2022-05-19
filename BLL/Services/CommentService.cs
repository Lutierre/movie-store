using AutoMapper;
using BLL.Abstractions.Interfaces;
using Core.Models;
using DAL;
using Entities;

namespace BLL.Services;

public class CommentService : ICommentService
{
    private readonly UnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CommentService(UnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<List<CommentModel>> GetByMovieAsync(Guid movieId)
    {
        var movieDto = await _unitOfWork.MovieRepository.GetAsync(movieId);
        var movie = _mapper.Map<MovieModel>(movieDto);
        
        var comments = movie.Comments.ToList();

        return comments;
    }
    
    public async Task<CommentModel> CreateAsync(CommentModel entity)
    {
        var commentDto = _mapper.Map<Comment>(entity);
        commentDto = await _unitOfWork.CommentRepository.CreateAsync(commentDto);
        await _unitOfWork.SaveAsync();

        var comment = _mapper.Map<CommentModel>(commentDto);
        
        return comment;    
    }

    public async Task<List<CommentModel>> GetAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<CommentModel?> GetAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<CommentModel?> UpdateAsync(Guid id, CommentModel entity)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteAsync(Guid id)
    {
        throw new NotImplementedException();
    }
}
