using ApiNext.Data.Dtos.Condominio;
using ApiNext.Data;
using ApiNext.Model;
using FluentResults;
using AutoMapper;
using System.Collections.Generic;

namespace ApiNext.Service
{
    public class CondominioService
    {
        private IMapper _mapper;
        private DataContext _context;

        public CondominioService(IMapper mapper, DataContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public ReadCondominioDto AdicionaCondominio(CreateCondominioDto dto)
        {
            Condominio condominio = _mapper.Map<Condominio>(dto);

            _context.Condominio.Add(condominio);
            _context.SaveChanges();

            return _mapper.Map<ReadCondominioDto>(condominio);
        }

        public List<ReadCondominioDto> ListaCondominio()
        {
            List<Condominio> condominio = _context.Condominio.ToList();

            if (condominio == null) return null;

            return _mapper.Map<List<ReadCondominioDto>>(condominio);
        }

        public Condominio AtualizaCondominio(UpdateCondominoDto dto)
        {
            Condominio condominio = _mapper.Map<Condominio>(dto);
            _context.Update(condominio);

            if(_context.SaveChanges() > 0) return condominio;

            return null;
        }

        public Result DeletaCondominio(int id)
        {
            Condominio condominio = _context.Condominio.FirstOrDefault(c => c.Id == id);

            if (condominio == null) return Result.Fail("Condominio nao encontrado");

            return Result.Ok();
        }

    }
}
