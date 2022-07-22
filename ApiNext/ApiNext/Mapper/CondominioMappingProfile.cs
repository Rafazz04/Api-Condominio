using AutoMapper;
using ApiNext.Data.Dtos.Condominio;
using ApiNext.Model;

namespace ApiNext.Mapper
{
    public class CondominioMappingProfile : Profile
    {
        public CondominioMappingProfile()
        {
            CreateMap<CreateCondominioDto, Condominio>();
            CreateMap<Condominio, ReadCondominioDto>();
            CreateMap<UpdateCondominoDto, Condominio>();
        }
    }
}
