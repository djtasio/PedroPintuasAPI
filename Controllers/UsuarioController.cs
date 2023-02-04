using API_PedroPinturas.DataAccess.Servicios;
using API_PedroPinturas.Models;
using Microsoft.AspNetCore.Mvc;

namespace API_PedroPinturas.Controllers;

[ApiController]
[Route("[controller]")]
public class UsuarioController : ControllerBase
{
    private readonly RespositoryAsync<User> _repository;
    public UsuarioController(RespositoryAsync<User> repository)
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
       var color = await _repository.Get(id);
       if(color is null) return NotFound();
       return Ok(await _repository.Get(id)); 
    }

    [HttpPost, ActionName("CheckUsername")]
    public async Task<bool> checkUsername(string username){
        var entity = await _repository.Find(u => u.Username == username);
        return (entity is null);
    }

}