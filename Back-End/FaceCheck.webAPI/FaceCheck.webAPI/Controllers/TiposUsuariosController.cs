using FaceCheck.webAPI.Domains;
using FaceCheck.webAPI.Interfaces;
using FaceCheck.webAPI.Repositories;
using Microsoft.AspNetCore.Authorization;
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
    public class TiposUsuariosController : ControllerBase
    {
        private ITipoUsuarioRepository _tipoURepository;

        public TiposUsuariosController()
        {
            _tipoURepository = new TipoUsuarioRepository();
        }

        [HttpPost]
        [Authorize(Roles = "1")]
        public IActionResult Cadastrar(Tipousuario novoTipoUsuario)
        {
            try
            {
                _tipoURepository.Cadastrar(novoTipoUsuario);
                return StatusCode(201);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
                throw;
            }
        }

        [HttpGet]
        [Authorize(Roles = "1")]
        public IActionResult ListarTodos()
        {
            try
            {
                return Ok(_tipoURepository.ListarTodos());
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
                throw;
            }
        }
    }
}
