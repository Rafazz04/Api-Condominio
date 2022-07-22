using System;
using Grpc.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using FluentResults;
using ApiNext.Service;
using ApiNext.Data.Dtos.Familia;
using ApiNext.Model;

namespace ApiNext.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FamiliaController : ControllerBase
    {
        private FamiliaService _familiaService;

        public FamiliaController(FamiliaService service)
        {
            _familiaService = service;
        }

        [ProducesResponseType(typeof(Familia), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(Familia), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Familia), StatusCodes.Status500InternalServerError)]
        [HttpPost]
        public object AdicionaFamilia(CreateFamiliaDto dto)
        {
            try
            {
                return _familiaService.AdicionaFamilia(dto);
            }
            catch(Exception ex)
            {
                return Problem(detail: ex.GetBaseException().Message);
            }
        }

        [ProducesResponseType(typeof(Familia), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(Familia), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Familia), StatusCodes.Status500InternalServerError)]
        [HttpGet]
        public IActionResult ListaFamilia()
        {
            try
            {
                List<ReadFamiliaDto> familia = _familiaService.ListaFamilia();
                if (familia == null) return Problem(detail: "Banco de dados vazio.", title: "Not Found", statusCode: 404);

                return Ok(familia);
            }
            catch (Exception ex)
            {
                return Problem(detail: ex.GetBaseException().Message);
            }
        }

        [ProducesResponseType(typeof(Familia), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(Familia), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Familia), StatusCodes.Status500InternalServerError)]
        [HttpPut]
        public IActionResult AtualizaFamilia(int id, UpdateFamiliaDto dto)
        {
            try
            {
                Familia atualiza = _familiaService.AtualizaFamilia(dto);
                if(atualiza == null) return Problem(detail: "Id invalido.", title: "Bad Requests", statusCode: 400);

                return Ok(atualiza);
            }
            catch (Exception ex)
            {
                return Problem(detail: ex.GetBaseException().Message);
            }
        }

        [ProducesResponseType(typeof(Familia), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(Familia), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Familia), StatusCodes.Status500InternalServerError)]
        [HttpDelete]
        public object DeletaFilme(int id)
        {
            try
            {
                var deleta = _familiaService.DeletaFamilia(id);

                if (deleta.IsFailed) return Problem(detail: "Id invalido.", title: "Bad Requests", statusCode: 400);
                return NoContent();
            }
            catch(Exception ex)
            {
                return Problem(detail: ex.GetBaseException().Message);
            }
            
        }
    }
}
