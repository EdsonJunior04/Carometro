using FaceCheck.webAPI.Context;
using FaceCheck.webAPI.Domains;
using FaceCheck.webAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FaceCheck.webAPI.Repositories
{
    public class PeriodoRepository : IPeriodoRepository
    {
        CarometroContext ctx = new();

        public void Cadastrar(Periodo novoPeriodo)
        {
            ctx.Periodos.Add(novoPeriodo);

            ctx.SaveChanges();
        }

        public List<Periodo> Listar()
        {
            return ctx.Periodos.ToList();
        }
    }
}
