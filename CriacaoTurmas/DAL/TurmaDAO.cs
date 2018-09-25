using CriacaoTurmas.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CriacaoTurmas.DAL
{
    class TurmaDAO
    {
        private static Context ctx = Singleton.Instance.Context;

        public static bool AdicionarTurma(Turma turma)
        {
            if (BuscarTurmaPorMateria(turma) == null)
            {
                try
                {
                    ctx.Turmas.Add(turma);
                    ctx.SaveChanges();
                    return true;
                }
                catch (Exception teste)
                {
                    //MessageBox.Show(teste.Message);
                    return false;
                }
            }
            return false;
        }

        public static Turma BuscarTurmaPorMateria(Turma turma)
        {
            return ctx.Turmas.FirstOrDefault(x => x.Nome_turma.Equals(turma.Nome_turma));
        }
    }
}
