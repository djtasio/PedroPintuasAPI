using API_PedroPinturas.Models;
using AutoMapper;

namespace Mvc.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Model, Color>().ReverseMap();
        }
    }
}