using System;
using Grpc.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
//using FluentResults;
using ApiNext.Service;
using ApiNext.Data.Dtos.Condominio;
using ApiNext.Model;


namespace ApiNext.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CondominioController : ControllerBase
    {
        private CondominioService _condominioService;

        public CondominioController(CondominioService service)
        {
            _condominioService = service;
        }

        [ProducesResponseType(typeof(Condominio), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(Condominio), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Condominio), StatusCodes.Status500InternalServerError)]
        [HttpPost]
        public object AdicionaCondominio(CreateCondominioDto dto)
        {
            return _condominioService.AdicionaCondominio(dto);
        }

        [ProducesResponseType(typeof(Condominio), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(Condominio), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Condominio), StatusCodes.Status500InternalServerError)]
        [HttpGet]
        public object ListaCondominio()
        {
            List<ReadCondominioDto> condominio = _condominioService.ListaCondominio();

            if (condominio == null) return null;

            return condominio;
        }

        [ProducesResponseType(typeof(Condominio), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(Condominio), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Condominio), StatusCodes.Status500InternalServerError)]
        [HttpPut]
        public object AtualizaFilme(int id, UpdateCondominoDto condominioDto)
        {
            Condominio atualiza = _condominioService.AtualizaCondominio(condominioDto);

            if (atualiza == null) return null;

            return atualiza;
        }

        [ProducesResponseType(typeof(Condominio), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(Condominio), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Condominio), StatusCodes.Status500InternalServerError)]
        [HttpDelete]
        public object Deletacondominio(int id)
        {
            var deleta = _condominioService.DeletaCondominio(id);

            if(deleta.IsFailed) return Problem(detail: "Id invalido", title: "Bad Requests", statusCode: 404);
            return NoContent();
        }
    }
}
