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
    public async Task<CommentModel> Post([FromBody] CommentModel commentModel) => await _commentService.CreateAsync(commentModel);

    [HttpGet("{movieId}")]
    public async Task<List<CommentModel>> Get(Guid movieId) => await _commentService.GetByMovieAsync(movieId);
}
