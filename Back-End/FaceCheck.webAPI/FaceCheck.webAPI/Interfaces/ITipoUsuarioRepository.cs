using FaceCheck.webAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FaceCheck.webAPI.Interfaces
{
    interface ITipoUsuarioRepository
    {
        void Cadastrar(Tipousuario novoTipoUsuario);

        List<Tipousuario> ListarTodos();
    }
}
