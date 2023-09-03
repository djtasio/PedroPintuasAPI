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

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
       var usuario = await _repository.Get(id);
       if(usuario == null) return NotFound();
       return Ok(await _repository.Get(id)); 
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id){
        var evento = await _repository.Get(id);
        if(evento is null) return NotFound();
        await _repository.Delete(id);
        return NoContent();
    }

    
    [HttpPut("{id}")]
public async Task<IActionResult> Update(int id, [FromBody] Evento eventoToUpdate)
{
    var existingEvento = await _repository.Get(id);
    if (existingEvento == null) return NotFound();

    existingEvento.Event = eventoToUpdate.Event;
    existingEvento.Lugar = eventoToUpdate.Lugar;
    existingEvento.Descripcion = eventoToUpdate.Descripcion;
    existingEvento.Materiales = eventoToUpdate.Materiales;
    existingEvento.Fecha = eventoToUpdate.Fecha;
    existingEvento.AireLibre = eventoToUpdate.AireLibre;

    await _repository.Update(existingEvento);

    return NoContent();
}

[HttpGet("CheckEvent/{eventName}"), ActionName("CheckEventname")]
    public async Task<int> checkEventName(string eventName){
        Evento entity = await _repository.Find(e => e.Event == eventName);
        if(entity != null){
            return entity.Id;
        } else {
            return -1;
        }
    }
    
}