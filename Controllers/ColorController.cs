using API_PedroPinturas.Models;
using API_PedroPinturas.Services;
using Microsoft.AspNetCore.Mvc;

namespace API_PedroPinturas.Controllers;

[ApiController]
[Route("[controller]")]
public class ColorController : ControllerBase
{
    private readonly ColorService _colorService;
    public ColorController(ColorService colorService)
    {
        _colorService = colorService;
    }

    // GET all action
    [HttpGet]
    public async Task<IActionResult> GetAll(){
        return Ok(await _colorService.GetAll());
    }

    // GET by Id action
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
       var pizza = await _colorService.Get(id);
       if(pizza is null) return NotFound();
       return Ok(await _colorService.Get(id)); 
    }

}