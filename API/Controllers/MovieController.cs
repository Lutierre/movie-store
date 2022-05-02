using BLL.Abstractions.Interfaces;
using Core.Models;
using Microsoft.AspNetCore.Mvc;
using UI.ActionFilters;

namespace API.Controllers;

[ApiController]
[ServiceFilter(typeof(TimerFilterAttribute))]
[Route("Movies")]
internal class MovieController : ControllerBase
{
    private readonly IService<Movie?> _movieService;

    public MovieController(IService<Movie?> movieService)
    {
        _movieService = movieService;
    }

    [HttpPost]
    public Movie? Post([FromBody] Movie? movie) => _movieService.CreateAsync(movie).Result;

    [HttpGet]
    public IEnumerable<Movie?> Get() => _movieService.GetAsync().Result;

    [HttpGet("{id}")]
    public Movie? Get(Guid id) => _movieService.GetAsync(id).Result;

    [HttpPatch("{id}")]
    public Movie? Patch([FromBody]Movie? movie, Guid id) => _movieService.UpdateAsync(id, movie).Result;

    [HttpDelete("{id}")]
    public void Delete(Guid id) => _movieService.DeleteAsync(id);
}
