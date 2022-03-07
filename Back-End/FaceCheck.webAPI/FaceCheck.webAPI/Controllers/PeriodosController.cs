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
    public class PeriodosController : ControllerBase
    {
        private IPeriodoRepository _periodoRepository { get; set; }

        public PeriodosController()
        {
            _periodoRepository = new PeriodoRepository();
        }

        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(_periodoRepository.Listar());
        }

        [HttpPost]
        public IActionResult Cadastrar(Periodo novoPeriodo)
        {
            _periodoRepository.Cadastrar(novoPeriodo);

            return StatusCode(201);
        }

    }
}
