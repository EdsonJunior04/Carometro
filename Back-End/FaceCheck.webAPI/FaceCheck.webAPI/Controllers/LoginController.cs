using FaceCheck.webAPI.Domains;
using FaceCheck.webAPI.Interfaces;
using FaceCheck.webAPI.Repositories;
using FaceCheck.webAPI.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace FaceCheck.webAPI.Controllers
{
    [Produces("application/json")]

    [Route("api/[controller]")]

    [ApiController]
    public class LoginController : Controller
    {
        private IUsuarioRepository _usuarioRepository { get; set; }
        public LoginController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        [HttpPost]
        public IActionResult Logar(LoginViewModel Login)
        {
            Usuario UsuarioBuscado = _usuarioRepository.Login(Login.Email, Login.Senha);
            try
            {
                if (UsuarioBuscado != null)
                {
                    var Claims = new[]
                    {
                    new Claim(JwtRegisteredClaimNames.Email, UsuarioBuscado.Email),
                    new Claim(ClaimTypes.Role,UsuarioBuscado.IdTipoU.ToString()),
                    new Claim(JwtRegisteredClaimNames.Jti, UsuarioBuscado.IdUsuario.ToString()),
                    new Claim( "role", UsuarioBuscado.IdTipoU.ToString() )
                    };

                    var Chave = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("carometro-facecheck-autenticacao"));
                    var Credenciais = new SigningCredentials(Chave, SecurityAlgorithms.HmacSha256);
                    var Token = new JwtSecurityToken
                        (
                            issuer: "facecheck.webAPI",
                            audience: "facecheck.webAPI",
                            claims: Claims,
                            expires: DateTime.Now.AddMinutes(50),
                            signingCredentials: Credenciais
                        );
                    return Ok(new
                    {
                        token = new JwtSecurityTokenHandler().WriteToken(Token)
                    });
                }
                else
                {
                    return NotFound("Email ou senha inválidos! Usuário não encontrado!!!");
                }
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
                throw;
            }
        }
    }
}
