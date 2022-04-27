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
    private readonly ILogger<MovieController> _logger;

    private readonly IService<Movie> _service;
    
    public MovieController(ILogger<MovieController> logger, IService<Movie> service)
    {
        _logger = logger;
        _service = service;
    }
    
    [HttpPost]
    public Movie Post([FromHeader]string apiKey, [FromBody]Movie movie) => _service.Create(movie);

    [HttpGet]
    public IEnumerable<Movie> Get([FromHeader]string apiKey) => _service.Get();

    [HttpGet("{id}")]
    public Movie? Get([FromHeader]string apiKey, Guid id) => _service.Get(id);

    [HttpPatch("{id}")]
    public Movie? Patch([FromHeader]string apiKey, [FromBody]Movie movie, Guid id) => _service.Update(id, movie);

    [HttpDelete("{id}")]
    public void Delete([FromHeader]string apiKey, Guid id) => _service.Delete(id);
}
