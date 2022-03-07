using System;
using System.Collections.Generic;

#nullable disable

namespace FaceCheck.webAPI.Domains
{
    public partial class Sala
    {
        public Sala()
        {
            Alunos = new HashSet<Aluno>();
        }

        public int IdSala { get; set; }
        public int? IdPeriodo { get; set; }
        public string NomeSala { get; set; }

        public virtual Periodo IdPeriodoNavigation { get; set; }
        public virtual ICollection<Aluno> Alunos { get; set; }
    }
}
