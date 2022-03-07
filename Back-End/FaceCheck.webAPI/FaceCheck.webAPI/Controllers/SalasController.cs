using FaceCheck.webAPI.Domains;
using FaceCheck.webAPI.Interfaces;
using FaceCheck.webAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FaceCheck.webAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class SalasController : ControllerBase
    {
        private ISalaRepository _salaRepository { get; set; }

        public SalasController()
        {
            _salaRepository = new SalaRepository();
        }

        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(_salaRepository.Listar());
        }

        [HttpGet("{idSala}")]
        public IActionResult BuscarPorId(int idSala)
        {
            return Ok(_salaRepository.BuscarPorId(idSala));
        }

 
        [HttpPost]
        public IActionResult Cadastrar(Sala novaSala)
        {
            _salaRepository.Cadastrar(novaSala);

            return StatusCode(201);
        }

        [HttpPut("{idSala}")]
        public IActionResult Atualizar(short idSala, Sala SalaAtualizada)
        {
            _salaRepository.Atualizar(idSala, SalaAtualizada);

            return StatusCode(204);
        }

       
        [HttpDelete("{idSala}")]
        public IActionResult Deletar(int idSala)
        {
            _salaRepository.Deletar(idSala);

            return StatusCode(204);
        }


    }
}
