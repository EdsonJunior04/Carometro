using System;
using System.Collections.Generic;

#nullable disable

namespace FaceCheck.webAPI.Domains
{
    public partial class Tipousuario
    {
        public Tipousuario()
        {
            Usuarios = new HashSet<Usuario>();
        }

        public byte IdTipoU { get; set; }
        public string NomeTipoU { get; set; }

        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
