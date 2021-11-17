using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Models
{
    public class Turma
    {
        public int TurmaID { get; set; }
        public int DisciplinaID { get; set; }
        public virtual Disciplina Disciplina { get; set; }
        public string Horario { get; set; }  // 2LM4LM
        public string Numero { get; set; } // 128
        public int Vagas { get; set; } // 30
    }
}
