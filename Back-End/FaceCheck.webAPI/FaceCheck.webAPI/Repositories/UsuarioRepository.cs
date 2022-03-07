using FaceCheck.webAPI.Context;
using FaceCheck.webAPI.Domains;
using FaceCheck.webAPI.Interfaces;
using FaceCheck.webAPI.Utils;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FaceCheck.webAPI.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {

        CarometroContext ctx = new();

        public void Cadastrar(Usuario novoUsuario)
        {
            ctx.Usuarios.Add(novoUsuario);

            ctx.SaveChanges();
        }

        public void Deletar(int idUsuario)
        {
            ctx.Usuarios.Remove(Encontrar(idUsuario));

            ctx.SaveChanges();
        }

        public Usuario Encontrar(int idUsuario)
        {
            return ctx.Usuarios.FirstOrDefault(c => c.IdUsuario == idUsuario);
        }

        public List<Usuario> ListarTodos()
        {
            return ctx.Usuarios
                .Include(u => u.IdTipoUNavigation)
                .ToList();
        }

        public Usuario Login(string email, string senha)
        {
            var usuario = ctx.Usuarios.FirstOrDefault(u => u.Email == email);

            if (usuario != null)
            {
                if (usuario.Senha == senha)
                {
                    usuario.Senha = Criptografia.GerarHash(usuario.Senha);
                    ctx.SaveChanges();
                }

                bool confere = Criptografia.Comparar(senha, usuario.Senha);

                if (confere)
                    return usuario;

            }

            return null;

        }

    }
}
