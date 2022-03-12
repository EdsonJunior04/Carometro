using FaceCheck.webAPI.Context;
using FaceCheck.webAPI.Domains;
using FaceCheck.webAPI.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FaceCheck.webAPI.Repositories
{
    public class AlunoRepository : IAlunoRepository
    {
        CarometroContext ctx = new();

        public void Atualizar(int idAluno, Aluno AlunoAtualizado)
        {
            Aluno alunoBuscado = ctx.Alunos.Find(idAluno);

            if (AlunoAtualizado != null)
            {
                alunoBuscado.IdSala = AlunoAtualizado.IdSala;
                alunoBuscado.Imagem = AlunoAtualizado.Imagem;

                ctx.Alunos.Update(alunoBuscado);

                ctx.SaveChangesAsync();
            }
        }

        public Aluno BuscarPorId(int idAluno)
        {
            return ctx.Alunos.FirstOrDefault(a => a.IdAlunos == idAluno);
        }

        public Aluno BuscarPorNome(string nome)
        {
            return ctx.Alunos.FirstOrDefault(a => a.NomeAluno == nome);

        }

        public List<Aluno> BuscarPorSala(int idSala)
        {
            List<Aluno> alunosSala = ctx.Alunos.Where(a => a.IdSala == idSala).ToList();

            return alunosSala;
           // return 
        }

        public void Cadastrar(Aluno novoAluno)
        {
            //novoAluno.Imagem = "https://cdn-icons-png.flaticon.com/512/64/64572.png";


            ctx.Alunos.Add(novoAluno);

            ctx.SaveChanges();
        }

        public string ConsultarImagemlDir(int idAluno)
        {
            string nome = idAluno.ToString() + ".png";

            string caminho = Path.Combine("imagem", nome);

            if (File.Exists(caminho))
            {
                byte[] bytesArquivo = File.ReadAllBytes(caminho);

                return Convert.ToBase64String(bytesArquivo);
            }

            return null;
        }

        public void Deletar(int idAluno)
        {
            ctx.Alunos.Remove(BuscarPorId(idAluno));

            ctx.SaveChanges();
        }

        public List<Aluno> Listar()
        {
            return ctx.Alunos.ToList();
        }

        public string SalvarImagemDir(IFormFile foto, int idAluno)
        {
            string arquivo = foto.FileName.Split('.').Last();

            if (arquivo == "png")
            {
                string nome = idAluno.ToString() + ".png";

                using (var strem = new FileStream(Path.Combine("Image", nome), FileMode.Create))
                {
                    foto.CopyTo(strem);
                }

                return " imagem salva! ";
            }

            if (arquivo == "jpg")
            {
                string nome = idAluno.ToString() + ".jpg";

                using (var strem = new FileStream(Path.Combine("Image", nome), FileMode.Create))
                {
                    foto.CopyTo(strem);
                }

                return "imagem salva! ";
            }

            return null;
        }
    }
   }

