using Microsoft.AspNetCore.Mvc;
using MovieStore.Abstractions;
using MovieStore.Models;
using MovieStore.Models.Enums;

namespace MovieStore.Controllers;

[ApiController]
[Route("Movies")]
public class MovieController : ControllerBase
{
    private readonly ILogger<MovieController> _logger;

    private IMovieService<Movie> _movieService;

    public MovieController(ILogger<MovieController> logger, IMovieService<Movie> movieService)
    {
        _logger = logger;
        _movieService = movieService;
    }
    
    [HttpPost]
    public Movie Post
    (
        [FromForm(Name = "Title")]string title,
        [FromForm(Name = "Description")]string? description,
        [FromForm(Name = "Genres")]Genre[] genres,
        [FromForm(Name = "ReleaseDate")]DateTime releaseDate
    )
    {
        return _movieService.Create(title, description, genres.ToArray(), releaseDate);
    }
    
    [HttpGet]
    public IEnumerable<Movie> Get() => _movieService.Get();

    [HttpGet]
    [Route("{id}")]
    public Movie? Get(Guid id) => _movieService.Get(id);

    [HttpPatch]
    [Route("{id}")]
    public Movie? Patch
    (
        Guid id,
        [FromForm(Name = "Title")] string title,
        [FromForm(Name = "Description")] string? description,
        [FromForm(Name = "Genres")] Genre[] genres,
        [FromForm(Name = "ReleaseDate")] DateTime releaseDate
    )
    {
        return _movieService.Update(id, title, description, genres, releaseDate);
    }

    [HttpDelete]
    [Route("{id}")]
    public void Delete(Guid id) => _movieService.Delete(id);
}
