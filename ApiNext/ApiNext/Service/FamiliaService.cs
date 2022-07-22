using ApiNext.Data.Dtos.Familia;
using ApiNext.Data;
using ApiNext.Model;
using FluentResults;
using AutoMapper;

namespace ApiNext.Service
{
    public class FamiliaService
    {
        private IMapper _mapper;
        private DataContext _context;

        public FamiliaService(IMapper mapper, DataContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public ReadFamiliaDto AdicionaFamilia(CreateFamiliaDto dto)
        {
            Familia familia = _mapper.Map<Familia>(dto);

            _context.Familia.Add(familia);
            _context.SaveChanges();

            return _mapper.Map<ReadFamiliaDto>(familia);
        }

        public List<ReadFamiliaDto> ListaFamilia()
        {
            List<Familia> familia = _context.Familia.ToList();

            if (familia == null) return null;

            return _mapper.Map<List<ReadFamiliaDto>>(familia);
        }

        public Familia AtualizaFamilia(UpdateFamiliaDto familiadto)
        {
            Familia familia = _mapper.Map<Familia>(familiadto);
            _context.Familia.Update(familia);

            if(_context.SaveChanges() > 0) return familia;

            return null;
        }

        public Result DeletaFamilia(int id)
        {
            Familia familia = _context.Familia.FirstOrDefault(f => f.Id == id);

            if (familia == null) return Result.Fail("Familia nao encontrada");

            _context.Remove(familia);
            _context.SaveChanges();

            return Result.Ok();
        }
    }
}
