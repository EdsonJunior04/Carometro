using System;
using System.Collections.Generic;

#nullable disable

namespace FaceCheck.webAPI.Domains
{
    public partial class Usuario
    {
        public short IdUsuario { get; set; }
        public byte? IdTipoU { get; set; }
        public string NomeUsuario { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }

        public virtual Tipousuario IdTipoUNavigation { get; set; }
    }
}
