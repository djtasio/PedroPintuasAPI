using API_PedroPinturas.Models;
using API_PedroPinturas.DataAccess.Servicios;
using Microsoft.AspNetCore.Mvc;

namespace API_PedroPinturas.Controllers;

[ApiController]
[Route("[controller]")]
public class PedidoController : ControllerBase
{
    private readonly RespositoryAsync<Pedido> _repository;
    public PedidoController(RespositoryAsync<Pedido> repository)
    {
        _repository = repository;
    }

    // GET all action
    [HttpGet]
    public async Task<IActionResult> GetAll(){
        return Ok(await _repository.GetAllInnerJoin(new List<string>{"Compras","Compras.Producto","Compras.Producto.Color"}));
    }

    // GET by Id action
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
       var pedido = await _repository.Get(id);
       if(pedido == null) return NotFound();
       return Ok(await _repository.Get(id)); 
    }

    // GET by Id action
    [HttpGet("user/{id}")]
    public async Task<IActionResult> GetUser(int id)
    {
       return Ok(await _repository.GetOrderBy(id,new List<string>{"Compras","Compras.Producto","Compras.Producto.Color"},p => p.IdUsuario == id, p => p.Fecha)); 
    }

    [HttpGet("date/{datetime}")]
    public async Task<IActionResult> GetDate(string datetime)
    {
       return Ok(await _repository.Filter(p => p.Fecha.ToString("dd-MM-yyyy").Contains(datetime),new List<string>{"Compras","Compras.Producto","Compras.Producto.Color","Usuario"})); 
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Pedido pedido){
        if(pedido == null) return BadRequest();
        //Si lo que me están mandando no coincide con el modelo que yo he recibido
        //if(!ModelState.IsValid) return BadRequest(ModelState);
        var created = await _repository.DoAttach(pedido);
        return Created("created",created);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id){
        var pedido = await _repository.Get(id);
        if(pedido is null) return NotFound();
        await _repository.DeleteOnCascade(id,p => p.Id == id,new List<string>{"Compras"});
        return NoContent();
    }

}