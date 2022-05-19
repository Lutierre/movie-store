using API.ActionFilters;
using BLL.Abstractions.Interfaces;
using Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[ServiceFilter(typeof(TimerFilterAttribute))]
[Route("Movies")]
public class MovieController : ControllerBase
{
    private readonly IService<MovieModel> _movieService;

    public MovieController(IService<MovieModel> movieService)
    {
        _movieService = movieService;
    }

    [HttpPost]
    public async Task<MovieModel> Post([FromBody]MovieModel movieModel) => await _movieService.CreateAsync(movieModel);

    [HttpGet]
    public async Task<List<MovieModel>> Get() => await _movieService.GetAsync();

    [HttpGet("{id}")]
    public async Task<MovieModel?> Get(Guid id) => await _movieService.GetAsync(id);

    [HttpPatch("{id}")]
    public async Task<MovieModel> Patch([FromBody]MovieModel? movie, Guid id) => await _movieService.UpdateAsync(id, movie);

    [HttpDelete("{id}")]
    public async Task Delete(Guid id) => await _movieService.DeleteAsync(id);
}
