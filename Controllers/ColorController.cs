using API_PedroPinturas.DataAccess.Servicios;
using API_PedroPinturas.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API_PedroPinturas.Controllers;

[ApiController]
[Route("[controller]")]
public class ColorController : BaseController<Model,Color>
{
    public ColorController(RespositoryAsync<Color> repository, IMapper mapper) : base(repository, mapper)
    {
    }

}