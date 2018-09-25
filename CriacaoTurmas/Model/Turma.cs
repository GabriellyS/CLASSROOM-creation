using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CriacaoTurmas.Model
{
    [Table("Turma")]
    class Turma
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TurmaID { get; set; }

        public string Nome_turma { get; set; }

        [ForeignKey("professor")]
        public int matriculaProfessor { get; set; }
        public virtual Professor professor { get; set; }

        public virtual ICollection<Aluno> alunos { get; set; }
    }
}
