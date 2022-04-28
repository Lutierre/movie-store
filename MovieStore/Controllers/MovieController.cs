using Microsoft.AspNetCore.Mvc;
using MovieStore.Abstractions;
using MovieStore.ActionFilters;
using MovieStore.Models;

namespace MovieStore.Controllers;

[ApiController]
[ServiceFilter(typeof(TimerFilterAttribute))]
[Route("Movies")]
public class MovieController : ControllerBase
{
    private readonly IService<Movie> _service;

    public MovieController(IService<Movie> service)
    {
        _service = service;
    }

    [HttpPost]
    public Movie Post([FromBody] Movie movie) => _service.Create(movie);

    [HttpGet]
    public IEnumerable<Movie> Get() => _service.Get();

    [HttpGet("{id}")]
    public Movie? Get(Guid id) => _service.Get(id);

    [HttpPatch("{id}")]
    public Movie? Patch([FromBody]Movie movie, Guid id) => _service.Update(id, movie);

    [HttpDelete("{id}")]
    public void Delete(Guid id) => _service.Delete(id);
}
