using API_PedroPinturas.Models;
using API_PedroPinturas.DataAccess.Servicios;
using Microsoft.AspNetCore.Mvc;

namespace API_PedroPinturas.Controllers;

[ApiController]
[Route("[controller]")]
public class ColorController : ControllerBase
{
    private readonly RespositoryAsync<Color> _repository;
    private readonly ILogger<ColorController> _logger;
    public ColorController(RespositoryAsync<Color> repository, ILogger<ColorController> logger)
{
    _repository = repository;
    _logger = logger;
}

    // GET all action
    [HttpGet]
public async Task<IActionResult> GetAll()
{
   try
   {
       return Ok(await _repository.GetAllOrderBy(c => c.Name));
   }
   catch (Exception ex)
   {
       _logger.LogError(ex, "Ocurrió un error al obtener todos los registros");
       return StatusCode(500, "Ocurrió un error interno en el servidor");
   }
}


    // GET by Id action
    [HttpGet("{id}")]
public async Task<IActionResult> Get(int id)
{
   try
   {
       var color = await _repository.Get(id);
       if (color == null)
           return NotFound();
           _logger.LogError( "Ocurrió un error al obtener el color con ID {Id}", id);
       
       return Ok(color);
   }
   catch (Exception ex)
   {
       _logger.LogError(ex, "Ocurrió un error al obtener el color con ID {Id}", id);
       return StatusCode(500, "Ocurrió un error interno en el servidor");
   }
}


    [HttpPost]
public async Task<IActionResult> Create([FromBody] Color color)
{
   try
   {
       if (color == null)
           return BadRequest();

       var created = await _repository.Insert(color);
       return Created("created", created);
   }
   catch (Exception ex)
   {
       _logger.LogError(ex, "Ocurrió un error al crear un nuevo color");
       return StatusCode(500, "Ocurrió un error interno en el servidor");
   }
}


    [HttpPut("{id}")]
public async Task<IActionResult> Update(int id, [FromBody] Color color)
{
   try
   {
       if (id != color.Id)
           return BadRequest();

       if (color == null)
           return BadRequest();

       await _repository.Update(color);
       return NoContent();
   }
   catch (Exception ex)
   {
       _logger.LogError(ex, "Ocurrió un error al actualizar el color con ID {Id}", id);
       return StatusCode(500, "Ocurrió un error interno en el servidor");
   }
}


    [HttpDelete("{id}")]
public async Task<IActionResult> Delete(int id)
{
   try
   {
       var color = await _repository.Get(id);
       if (color == null)
           return NotFound();

       await _repository.Delete(id);
       return NoContent();
   }
   catch (Exception ex)
   {
       _logger.LogError(ex, "Ocurrió un error al eliminar el color con ID {Id}", id);
       return StatusCode(500, "Ocurrió un error interno en el servidor");
   }
}

}