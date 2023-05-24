using API_PedroPinturas.Models;
using API_PedroPinturas.DataAccess.Servicios;
using Microsoft.AspNetCore.Mvc;

namespace API_PedroPinturas.Controllers;

[ApiController]
[Route("[controller]")]
public class CompraController : ControllerBase
{
    private readonly RespositoryAsync<Compra> _repository;
    private readonly ILogger<CompraController> _logger;
    public CompraController(RespositoryAsync<Compra> repository, ILogger<CompraController> logger)
{
    _repository = repository;
    _logger = logger;
}

    // GET all action
    [HttpGet]
    public async Task<IActionResult> GetAll(){
        return Ok(await _repository.GetAllInnerJoin(new List<string>{"Producto","Producto.Color"}));
    }

    // GET by Id action
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
       var color = await _repository.GetInnerJoin(id,c => c.Id == id,new List<string>{"Producto","Producto.Color"});
       if(color == null) return NotFound();
       return Ok(await _repository.Get(id)); 
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] List<Compra> compras){
        if(compras == null) return BadRequest();
        //if(!ModelState.IsValid) return BadRequest(ModelState);
        List<Compra> comprasDevolver = new List<Compra>();
        foreach(Compra compra in compras){
            var created = await _repository.DoEntry(compra);
            comprasDevolver.Add(created);
        }

        return Created("created",comprasDevolver);
    }
}