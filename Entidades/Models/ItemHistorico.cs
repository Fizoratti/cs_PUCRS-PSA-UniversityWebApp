using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entidades.Models
{
    public class ItemHistorico
    {
        public int ItemHistoricoID { get; set; }
        public string Codcred { get; set; }  // 4653B-04
        public string Semestre { get; set; }  // 2021-2
        public double Nota { get; set; } // 7.0
        public int DisciplinaID { get; set; }
        public virtual Disciplina Disciplina { get; set; }

        public int Matricula { get; set; } // 15111090
    }
}
