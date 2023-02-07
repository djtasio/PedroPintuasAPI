using API_PedroPinturas.Models;
using API_PedroPinturas.DataAccess.Servicios;
using Microsoft.AspNetCore.Mvc;

namespace API_PedroPinturas.Controllers;

[ApiController]
[Route("[controller]")]
public class UsuarioController : ControllerBase
{
    private readonly RespositoryAsync<Usuario> _repository;
    public UsuarioController(RespositoryAsync<Usuario> repository)
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
       var pizza = await _repository.Get(id);
       if(pizza is null) return NotFound();
       return Ok(await _repository.Get(id)); 
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Usuario user){
        if(user is null) return BadRequest();
        //Si lo que me están mandando no coincide con el modelo que yo he recibido
        if(!ModelState.IsValid) return BadRequest(ModelState);
        var created = await _repository.Insert(user);
        return Created("created",created);
    }

    [HttpPost("Username"), ActionName("CheckUsername")]
    public async Task<int> checkUsername(string user){
        Usuario entity = await _repository.Find(u => u.User == user);
        return entity.Id;
    }
}