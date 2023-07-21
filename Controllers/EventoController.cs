using API_PedroPinturas.Models;
using API_PedroPinturas.DataAccess.Servicios;
using Microsoft.AspNetCore.Mvc;

namespace API_PedroPinturas.Controllers;

[ApiController]
[Route("[controller]")]
public class EventoController : ControllerBase
{
    private readonly RespositoryAsync<Evento> _repository;
    public EventoController(RespositoryAsync<Evento> repository)
    {
        _repository = repository;
    }

    // GET all action
    [HttpGet]
    public async Task<IActionResult> GetAll(){
        return Ok(await _repository.GetAllOrderBy(c => c.Event));
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Evento evento){
        if(evento == null) return BadRequest();
        Console.WriteLine(evento.Id);
        var created = await _repository.Insert(evento);
        return Created("created",created);
    }

    
}