using ApiNext.Data.Dtos.Morador;
using ApiNext.Data;
using ApiNext.Model;
using FluentResults;
using AutoMapper;

namespace ApiNext.Service
{
    public class MoradorService
    {
        private IMapper _mapper;
        private DataContext _context;

        public MoradorService(IMapper mapper, DataContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public ReadMoradorDto AdicionaMorador(CreateMoradorDto dto)
        {
            Morador morador = _mapper.Map<Morador>(dto);

            _context.Morador.Add(morador);
            _context.SaveChanges();

            return _mapper.Map<ReadMoradorDto>(dto);
        }

        public List<ReadMoradorDto> ListaMorador()
        {
            List<Morador> morador = _context.Morador.ToList();

            if (morador == null) return null;

            return _mapper.Map<List<ReadMoradorDto>>(morador);
        } 

        public Morador AtualizaMorador(UpdateMoradorDto dto)
        {
            Morador morador = _mapper.Map<Morador>(dto);
            _context.Update(dto);

            if(_context.SaveChanges() > 0) return morador;

            return null;
        }

        public Result DeletaMorador(int id)
        {
            Morador morador = _context.Morador.FirstOrDefault(m => m.Id == id);

            if (morador == null) return Result.Fail("Morador nao encontrado");

            return Result.Ok();
        }
    }
}
