using System;
using System.Collections.Generic;

#nullable disable

namespace FaceCheck.webAPI.Domains
{
    public partial class Periodo
    {
        public Periodo()
        {
            Salas = new HashSet<Sala>();
        }

        public int IdPeriodo { get; set; }
        public string NomePeriodo { get; set; }

        public virtual ICollection<Sala> Salas { get; set; }
    }
}
