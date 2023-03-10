using API_PedroPinturas.Models;
using API_PedroPinturas.DataAccess.Servicios;
using Microsoft.AspNetCore.Mvc;

namespace API_PedroPinturas.Controllers;

[ApiController]
[Route("[controller]")]
public class ColorController : ControllerBase
{
    private readonly RespositoryAsync<Color> _repository;
    public ColorController(RespositoryAsync<Color> repository)
    {
        _repository = repository;
    }

    // GET all action
    [HttpGet]
    public async Task<IActionResult> GetAll(){
        return Ok(await _repository.GetAllOrderBy(c => c.Name));
    }

    // GET by Id action
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
       var color = await _repository.Get(id);
       if(color == null) return NotFound();
       return Ok(await _repository.Get(id)); 
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Color color){
        if(color == null) return BadRequest();
        //Si lo que me están mandando no coincide con el modelo que yo he recibido
        //if(!ModelState.IsValid) return BadRequest(ModelState);
        Console.WriteLine(color.Id);
        var created = await _repository.Insert(color);
        return Created("created",created);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] Color color){
        if (id != color.Id) return BadRequest();
        if(color == null) return BadRequest();

        await _repository.Update(color);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id){
        var color = await _repository.Get(id);
        if(color is null) return NotFound();
        await _repository.Delete(id);
        return NoContent();
    }
}