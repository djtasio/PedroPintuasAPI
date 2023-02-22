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
        return Ok(await _repository.GetAllInnerJoin(new List<string>{"Pedidos","Pedidos.Compras","Pedidos.Compras.Producto","Pedidos.Compras.Producto.Color"}));
    }

    // GET by Id action
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
       var usuario = await _repository.Get(id);
       if(usuario == null) return NotFound();
       return Ok(await _repository.GetInnerJoin(id,u => u.Id == id,new List<string>{"Pedidos","Pedidos.Compras","Pedidos.Compras.Producto","Pedidos.Compras.Producto.Color"})); 
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Usuario user){
        if(user == null) return BadRequest();
        //Si lo que me están mandando no coincide con el modelo que yo he recibido
        if(!ModelState.IsValid) return BadRequest(ModelState);
        var created = await _repository.Insert(user);
        return Created("created",created);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] Usuario user){
        if (id != user.Id) return BadRequest();
        if(user == null) return BadRequest();
        /*var userElement = await _repository.Get(id); .AsNoTracking() en el repository
        if(userElement == null) return NotFound();*/
        if(!ModelState.IsValid) return BadRequest();

        await _repository.Update(user);
        return NoContent();
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