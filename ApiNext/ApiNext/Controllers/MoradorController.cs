using System;
using Grpc.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using FluentResults;
using ApiNext.Service;
using ApiNext.Data.Dtos.Morador;
using ApiNext.Model;

namespace ApiNext.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoradorController : ControllerBase
    {
        private MoradorService _moradorService;

        public MoradorController(MoradorService Service)
        {
            _moradorService = Service;
        }

        [ProducesResponseType(typeof(Familia), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(Familia), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Familia), StatusCodes.Status500InternalServerError)]
        [HttpPost]
        public object AdicionaMorador(CreateMoradorDto dto)
        {
            try
            {
                return _moradorService.AdicionaMorador(dto);
            }
            catch (Exception ex)
            {
                return Problem(detail: ex.GetBaseException().Message);
            }
        }

        [ProducesResponseType(typeof(Familia), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(Familia), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Familia), StatusCodes.Status500InternalServerError)]
        [HttpGet]
        public  IActionResult ListaMorador()
        {
            try
            {
                List<ReadMoradorDto> morador = _moradorService.ListaMorador();
                if(morador == null) return Problem(detail: "Banco de dados vazio.", title: "Not Found", statusCode: 404);

                return Ok(morador);
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
        public IActionResult AtualizaFilme(int id, UpdateMoradorDto dto)
        {
            try
            {
                Morador atualiza = _moradorService.AtualizaMorador(dto);

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
        public object DeletaMorador(int id)
        {
            try
            {
                var deleta = _moradorService.DeletaMorador(id);

                if (deleta.IsFailed) return Problem(detail: "Id invalido.", title: "Bad Requests", statusCode: 400);

                return NoContent();
            }
            catch (Exception ex)
            {
                return Problem(detail: ex.GetBaseException().Message);
            }
        }
    }
}
