using CriacaoTurmas.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CriacaoTurmas.DAL
{
    class ProfessorDAO
    {
        private static Context ctx = Singleton.Instance.Context;

        public static bool AdicionarProfessor(Professor professor)
        {
            if (BuscarProfessorPorMatricula(professor) == null)
            {
                try
                {
                    ctx.Professores.Add(professor);
                    ctx.SaveChanges();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
            return false;
        }

        public static List<Professor> ListaProfessor()
        {
            return ctx.Professores.ToList();
        }

        public static Professor BuscarProfessorPorMatricula(Professor professor)
        {
            return ctx.Professores.FirstOrDefault(x => x.matricula.Equals(professor.matricula));
        }
    }
}
