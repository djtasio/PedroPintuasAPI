using API_PedroPinturas.DataAccess.Servicios;
using API_PedroPinturas.Models;
using Microsoft.AspNetCore.Mvc;

namespace API_PedroPinturas.Controllers;

[ApiController]
[Route("[controller]")]
public class ColorController : BaseController<Color>
{
    private readonly RespositoryAsync<Color> _repository;
    public ColorController(RespositoryAsync<Color> repository) : base(repository)
    {
        _repository = repository;
    }
    /*[HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Color e){
        //if (id != e.Id) return BadRequest();
        var element = await _repository.Get(id);
        if(element is null) return NotFound();
        if(!ModelState.IsValid) return BadRequest();

        await _repository.Update(e);
        return NoContent();
    }*/

}