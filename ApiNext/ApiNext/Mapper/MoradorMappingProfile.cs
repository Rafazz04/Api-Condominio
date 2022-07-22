using AutoMapper;
using ApiNext.Data.Dtos.Morador;
using ApiNext.Model;

namespace ApiNext.Mapper
{
    public class MoradorMappingProfile : Profile
    {
        public MoradorMappingProfile()
        {
            CreateMap<CreateMoradorDto, Morador>();
            CreateMap<Morador, ReadMoradorDto>();
            CreateMap<UpdateMoradorDto, Morador>();
        }
    }
}
