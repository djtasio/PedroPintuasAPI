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
       var usuario = await _repository.Get(id);
       if(usuario is null) return NotFound();
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

    [HttpPost("Login")]
    public async Task<int> Login([FromBody] Usuario user){
        /*if(username is null) return BadRequest();
        if(password is null) return BadRequest();*/
        //Si lo que me están mandando no coincide con el modelo que yo he recibido
       Usuario entity = await _repository.Find(u => u.User == user.User && u.Contrasenia == user.Contrasenia);
        if(entity != null){
            return entity.Id;
        } else {
            return -1; 
        }
    }

    [HttpGet("Username/{user}"), ActionName("CheckUsername")]
    public async Task<int> checkUsername(string user){
        Usuario entity = await _repository.Find(u => u.User == user);
        if(entity != null){
            return entity.Id;
        } else {
            return -1;
        }
    }
}