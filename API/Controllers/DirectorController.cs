using API.ActionFilters;
using BLL.Abstractions.Interfaces;
using Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[ServiceFilter(typeof(TimerFilterAttribute))]
[Route("Directors")]
public class DirectorController : ControllerBase
{
    private readonly IService<Director> _directorService;

    public DirectorController(IService<Director> directorService)
    {
        _directorService = directorService;
    }
    
    [HttpPost]
    public async Task<Director> Post([FromBody] Director? director) => await _directorService.CreateAsync(director);
}
