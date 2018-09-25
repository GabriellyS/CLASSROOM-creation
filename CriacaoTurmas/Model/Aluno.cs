using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CriacaoTurmas.Model
{
    [Table("Aluno")]
    class Aluno
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int matricula { get; set; }
        public String nome { get; set; }
        public String telefone { get; set; }

        public virtual ICollection<Turma> Turmas { get; set; }

    }
}
