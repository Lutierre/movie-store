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
    private readonly IService<DirectorModel> _directorService;

    public DirectorController(IService<DirectorModel> directorService)
    {
        _directorService = directorService;
    }
    
    [HttpPost]
    public async Task<DirectorModel> Post([FromBody] DirectorModel? director) => await _directorService.CreateAsync(director);
}
