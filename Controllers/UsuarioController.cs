using API_PedroPinturas.Models;
using API_PedroPinturas.DataAccess.Servicios;
using Microsoft.AspNetCore.Mvc;
using Serilog;


namespace API_PedroPinturas.Controllers;

[ApiController]
[Route("[controller]")]
public class UsuarioController : ControllerBase
{
    private readonly RespositoryAsync<Usuario> _repository;
    private readonly ILogger<UsuarioController> _logger;

    public UsuarioController(RespositoryAsync<Usuario> repository, ILogger<UsuarioController> logger)
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
       var usuarios = await _repository.GetAllInnerJoin(new List<string>{"Pedidos","Pedidos.Compras","Pedidos.Compras.Producto","Pedidos.Compras.Producto.Color"});
       return Ok(usuarios);
   }
   catch (Exception ex)
   {
       _logger.LogError(ex, "Ocurrió un error al obtener todos los usuarios");
       return StatusCode(500, "Ocurrió un error interno en el servidor");
   }
}


     [HttpGet("pedidos/{id}")]
public async Task<IActionResult> GetInnerJoin(int id)
{
   try
   {
       var usuario = await _repository.Get(id);
       if(usuario == null)
           return NotFound();
       
       var result = await _repository.GetInnerJoin(id, u => u.Id == id, new List<string>{"Pedidos","Pedidos.Compras","Pedidos.Compras.Producto","Pedidos.Compras.Producto.Color"});
       return Ok(result); 
   }
   catch (Exception ex)
   {
       _logger.LogError(ex, "Ocurrió un error al obtener el usuario con ID {Id} y sus pedidos relacionados", id);
       return StatusCode(500, "Ocurrió un error interno en el servidor");
   }
}


    // GET by Id action
    [HttpGet("{id}")]
public async Task<IActionResult> Get(int id)
{
   try
   {
       var usuario = await _repository.Get(id);
       if(usuario == null)
           return NotFound();
       return Ok(usuario); 
   }
   catch (Exception ex)
   {
       _logger.LogError(ex, "Ocurrió un error al obtener el usuario con ID {Id}", id);
       return StatusCode(500, "Ocurrió un error interno en el servidor");
   }
}

    [HttpPost]
public async Task<IActionResult> Create([FromBody] Usuario user)
{
   try
   {
       if (user == null)
           return BadRequest();
       
       if (!ModelState.IsValid)
           return BadRequest(ModelState);
       
       var created = await _repository.Insert(user);
       return Created("created", created);
   }
   catch (Exception ex)
   {
       _logger.LogError(ex, "Ocurrió un error al crear un nuevo usuario");
       return StatusCode(500, "Ocurrió un error interno en el servidor");
   }
}


    [HttpPut("{id}")]
public async Task<IActionResult> Update(int id, [FromBody] Usuario user)
{
   try
   {
       if (id != user.Id)
           return BadRequest();
       
       if (user == null)
           return BadRequest();
       
       if (!ModelState.IsValid)
           return BadRequest(ModelState);
       
       /*var userElement = await _repository.Get(id); .AsNoTracking() en el repository
       if(userElement == null) return NotFound();*/
       
       await _repository.Update(user);
       return NoContent();
   }
   catch (Exception ex)
   {
       _logger.LogError(ex, "Ocurrió un error al actualizar el usuario con ID {Id}", id);
       return StatusCode(500, "Ocurrió un error interno en el servidor");
   }
}


    [HttpDelete("{id}")]
public async Task<IActionResult> Delete(int id)
{
   try
   {
       var user = await _repository.Get(id);
       if (user is null)
           return NotFound();
       
       await _repository.DeleteOnCascade(id, u => u.Id == id, new List<string>{"Pedidos","Pedidos.Compras"});
       return NoContent();
   }
   catch (Exception ex)
   {
       _logger.LogError(ex, "Ocurrió un error al eliminar el usuario con ID {Id}", id);
       return StatusCode(500, "Ocurrió un error interno en el servidor");
   }
}


    [HttpPost("Login")]
public async Task<int> Login([FromBody] Usuario user)
{
   try
   {   
       // Si lo que me están mandando no coincide con el modelo que yo he recibido
       Usuario entity = await _repository.Find(u => u.User == user.User && u.Contrasenia == user.Contrasenia);
       
       if (entity != null)
           return entity.Id;
       else
           return -1;
   }
   catch (Exception ex)
   {
       _logger.LogError(ex, "Ocurrió un error al realizar el inicio de sesión");
       throw;
   }
}


    [HttpGet("Username/{user}")]
[ActionName("CheckUsername")]
public async Task<int> CheckUsername(string user)
{
   try
   {
       Usuario entity = await _repository.Find(u => u.User == user);
       if (entity != null)
           return entity.Id;
       else
           return -1;
   }
   catch (Exception ex)
   {
       _logger.LogError(ex, "Ocurrió un error al verificar el nombre de usuario: {User}", user);
       throw; 
   }
}

}