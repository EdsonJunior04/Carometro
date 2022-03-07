using FaceCheck.webAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FaceCheck.webAPI.Interfaces
{
    interface IUsuarioRepository
    {
        void Cadastrar(Usuario novoUsuario);

        List<Usuario> ListarTodos();

        public Usuario Login(string email, string senha);

        void Deletar(int idUsuario);

        Usuario Encontrar(int idUsuario); 
    }
}
