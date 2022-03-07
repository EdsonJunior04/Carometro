using FaceCheck.webAPI.Domains;
using FaceCheck.webAPI.Interfaces;
using FaceCheck.webAPI.Repositories;
using FaceCheck.webAPI.Utils;
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
    public class UsuariosController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository;
        public UsuariosController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        [HttpPost]
        [Authorize(Roles = "1")]
        
        public IActionResult Cadastrar(Usuario novoUsuario)
        {
            try
            {
                novoUsuario.Senha = Criptografia.GerarHash(novoUsuario.Senha);
                _usuarioRepository.Cadastrar(novoUsuario);
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
                return Ok(_usuarioRepository.ListarTodos());
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
                throw;
            }
        }

        [HttpDelete]
        [Authorize(Roles = "1")]
        public IActionResult Deletar(int id)
        {
            try
            {
                _usuarioRepository.Deletar(id);
                return NoContent();
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
                throw;
            }
        }

        [HttpGet("{idUsuario}")]
        [Authorize(Roles = "1")]
        public IActionResult Encontrar(int id)
        {
            try
            {
                return Ok(_usuarioRepository.Encontrar(id));
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }
        }
    }
}
