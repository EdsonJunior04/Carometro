using FaceCheck.webAPI.Context;
using FaceCheck.webAPI.Domains;
using FaceCheck.webAPI.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FaceCheck.webAPI.Repositories
{
    public class TipoUsuarioRepository : ITipoUsuarioRepository
    {
        CarometroContext ctx = new();
        public void Cadastrar(Tipousuario novoTipoUsuario)
        {
            ctx.Tipousuarios.Add(novoTipoUsuario);

            ctx.SaveChanges();
        }

        public List<Tipousuario> ListarTodos()
        {
            return ctx.Tipousuarios
                .ToList();
        }
    }
}
