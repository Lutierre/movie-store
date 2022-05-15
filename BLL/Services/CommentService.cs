using AutoMapper;
using BLL.Abstractions.Interfaces;
using Core.Models;
using DAL;
using DTO.Entities;

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

    public async Task<List<Comment>> GetByMovieAsync(Guid movieId)
    {
        var movieDto = await _unitOfWork.MovieRepository.GetAsync(movieId);
        var movie = _mapper.Map<Movie>(movieDto);
        
        var comments = movie.Comments.ToList();

        return comments;
    }
    
    public async Task<Comment> CreateAsync(Comment entity)
    {
        var commentDto = _mapper.Map<CommentDto>(entity);
        commentDto = await _unitOfWork.CommentRepository.CreateAsync(commentDto);
        await _unitOfWork.Save();

        var comment = _mapper.Map<Comment>(commentDto);
        
        return comment;    
    }

    public async Task<List<Comment>> GetAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<Comment?> GetAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<Comment?> UpdateAsync(Guid id, Comment entity)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteAsync(Guid id)
    {
        throw new NotImplementedException();
    }
}
