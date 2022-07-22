using AutoMapper;
using ApiNext.Data.Dtos.Familia;
using ApiNext.Model;

namespace ApiNext.Mapper
{
    public class FamiliaMappingProfile : Profile
    {
        public FamiliaMappingProfile()
        {
            CreateMap<CreateFamiliaDto, Familia>();
            CreateMap<Familia, ReadFamiliaDto>();
            CreateMap<UpdateFamiliaDto, Familia>();
        }
    }
}
