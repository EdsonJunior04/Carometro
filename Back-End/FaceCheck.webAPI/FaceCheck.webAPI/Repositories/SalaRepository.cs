using FaceCheck.webAPI.Context;
using FaceCheck.webAPI.Domains;
using FaceCheck.webAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FaceCheck.webAPI.Repositories
{
    public class SalaRepository : ISalaRepository
    {
        CarometroContext ctx = new();

        public void Atualizar(int idSala, Sala SalaAtualizada)
        {
            Sala salaBuscada = BuscarPorId(idSala);

            if (SalaAtualizada != null)
            {
                salaBuscada.NomeSala = SalaAtualizada.NomeSala;

                ctx.Salas.Update(salaBuscada);

                ctx.SaveChanges();
            }
        }

        public Sala BuscarPorId(int idSala)
        {
            return ctx.Salas.FirstOrDefault(s => s.IdSala == idSala);
        }

        public void Cadastrar(Sala novaSala)
        {
            ctx.Salas.Add(novaSala);

            ctx.SaveChanges();
        }

        public void Deletar(int idSala)
        {
            ctx.Salas.Remove(BuscarPorId(idSala));

            ctx.SaveChanges();
        }

        public List<Sala> Listar()
        {
            return ctx.Salas.ToList();
        }
    }
}
