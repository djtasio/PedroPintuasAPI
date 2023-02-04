using API_PedroPinturas.DataAccess.Servicios;
using Microsoft.AspNetCore.Mvc;

namespace API_PedroPinturas.Controllers;
public abstract class BaseController<Entity> : ControllerBase where Entity : class
{
    private readonly RespositoryAsync<Entity> _repository;
    public BaseController(RespositoryAsync<Entity> repository)
    {
        _repository = repository;
    }

    // GET all action
    [HttpGet]
    public async Task<IActionResult> GetAll(){
        return Ok(await _repository.GetAll());
    }

    // GET by Id action
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
       var color = await _repository.Get(id);
       if(color is null) return NotFound();
       return Ok(await _repository.Get(id)); 
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Entity e){
        if(e is null) return BadRequest();
        //Si lo que me están mandando no coincide con el modelo que yo he recibido
        if(!ModelState.IsValid) return BadRequest(ModelState);
        var created = await _repository.Insert(e);
        return Created("created",created);
    }


    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id){
        var pizzaElement = await _repository.Get(id);
        if(pizzaElement is null) return NotFound();
        await _repository.Delete(id);
        return NoContent();
    }

}