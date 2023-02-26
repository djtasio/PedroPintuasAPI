using API_PedroPinturas.Models;
using API_PedroPinturas.DataAccess.Servicios;
using Microsoft.AspNetCore.Mvc;

namespace API_PedroPinturas.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductoController : ControllerBase
{
    private readonly RespositoryAsync<Producto> _repository;
    private readonly RespositoryAsync<Color> _colorRepository;
    public ProductoController(RespositoryAsync<Producto> repository)
    {
        _repository = repository;
    }

    // GET all action
    [HttpGet]
    public async Task<IActionResult> GetAll(){
        //List<Producto> products = await _repository.Find(u => u.User == user.User && u.Contrasenia == user.Contrasenia);
        return Ok(await _repository.GetAllInnerJoin(new List<string>{"Color"}));
    }

    // GET by Id action
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
       var usuario = await _repository.Get(id);
       if(usuario == null) return NotFound();
       return Ok(await _repository.Get(id)); 
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Producto producto){
        if(producto == null) return BadRequest();
        //Si lo que me están mandando no coincide con el modelo que yo he recibido
        if(!ModelState.IsValid) return BadRequest(ModelState);
        //Do entry porque el color que le añadimos al producto ya existe en la base de datos y por
        //tanto no queremos insertarlo, sino cogerlo
        var created = await _repository.DoEntry(producto);
        return Created("created",created);
    }

    [HttpPost("CheckProduct")]
    public async Task<IActionResult> CheckProduct([FromBody] Producto producto){
        /*if(username is null) return BadRequest();
        if(password is null) return BadRequest();*/
        //Si lo que me están mandando no coincide con el modelo que yo he recibido
        Producto entity = await _repository.Find(p => p.Productos == producto.Productos && 
        p.Calidad == producto.Calidad &&  p.Color == p.Color);
        return await Get(entity.Id);
    }
}