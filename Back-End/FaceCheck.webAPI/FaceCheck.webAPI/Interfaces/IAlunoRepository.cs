using FaceCheck.webAPI.Domains;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FaceCheck.webAPI.Interfaces
{
    interface IAlunoRepository
    {
        List<Aluno> Listar();

        Aluno BuscarPorId(int idAluno);

        Aluno BuscarPorNome(string nome);

        List<Aluno> BuscarPorSala(int idSala);

        void Cadastrar(Aluno novoAluno);

        void Atualizar(int idAluno, Aluno AlunoAtualizada);

        void Deletar(int idAluno);

        string SalvarImagemDir(IFormFile foto, int idAluno);

        string ConsultarImagemlDir(int idAluno);
    }
}
