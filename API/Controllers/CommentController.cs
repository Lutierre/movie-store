using API.ActionFilters;
using BLL.Abstractions.Interfaces;
using Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[ServiceFilter(typeof(TimerFilterAttribute))]
[Route("Comments")]
public class CommentController : ControllerBase
{
    private readonly ICommentService _commentService;

    public CommentController(ICommentService commentService)
    {
        _commentService = commentService;
    }

    [HttpPost]
    public async Task<Comment> Post([FromBody] Comment comment) => await _commentService.CreateAsync(comment);

    [HttpGet("{movieId}")]
    public async Task<List<Comment>> Get(Guid movieId) => await _commentService.GetByMovieAsync(movieId);
}
