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
    private readonly IService<Movie> _movieService;

    public MovieController(IService<Movie> movieService)
    {
        _movieService = movieService;
    }

    [HttpPost]
    public async Task<Movie> Post([FromBody]Movie movie) => await _movieService.CreateAsync(movie);

    [HttpGet]
    public async Task<List<Movie>> Get() => await _movieService.GetAsync();

    [HttpGet("{id}")]
    public async Task<Movie?> Get(Guid id) => await _movieService.GetAsync(id);

    [HttpPatch("{id}")]
    public async Task<Movie> Patch([FromBody]Movie? movie, Guid id) => await _movieService.UpdateAsync(id, movie);

    [HttpDelete("{id}")]
    public async Task Delete(Guid id) => await _movieService.DeleteAsync(id);
}
