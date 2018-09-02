using CriacaoTurmas.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CriacaoTurmas.DAL
{
    class AlunoDAO
    {
        public static Context ctx = Singleton.Instance.Context;

        public static bool AdicionarAluno(Aluno aluno)
        {
            try
            {
                ctx.Alunos.Add(aluno);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static Aluno BuscarAlunoPorMatricula(Aluno aluno)
        {
            return ctx.Alunos.FirstOrDefault(x => x.matricula.Equals(aluno.matricula));
        }

        public static List<Aluno> ListaAluno()
        {
            return ctx.Alunos.ToList();
        }
    }
}
