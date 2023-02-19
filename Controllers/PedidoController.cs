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
        return Ok(await _repository.GetAll());
    }

    // GET by Id action
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
       var pedido = await _repository.Get(id);
       if(pedido == null) return NotFound();
       return Ok(await _repository.Get(id)); 
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Pedido pedido){
        if(pedido == null) return BadRequest();
        //Si lo que me están mandando no coincide con el modelo que yo he recibido
        if(!ModelState.IsValid) return BadRequest(ModelState);
        var created = await _repository.DoEntry(pedido);
        return Created("created",created);
    }

}