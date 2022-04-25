using Microsoft.AspNetCore.Mvc;
using MovieStore.Abstractions;
using MovieStore.Models;

namespace MovieStore.Controllers;

[ApiController]
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
    public Movie Post([FromBody]Movie movie) => _service.Create(movie);

    [HttpGet]
    public IEnumerable<Movie> Get() => _service.Get();

    [HttpGet]
    [Route("{id}")]
    public Movie? Get(Guid id) => _service.Get(id);

    [HttpPatch]
    [Route("{id}")]
    public Movie? Patch(Guid id, [FromBody]Movie movie) => _service.Update(id, movie);

    [HttpDelete]
    [Route("{id}")]
    public void Delete(Guid id) => _service.Delete(id);
}
