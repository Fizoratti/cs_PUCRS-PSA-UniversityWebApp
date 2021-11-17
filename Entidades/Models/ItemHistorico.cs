using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entidades.Models
{
    public class ItemHistorico
    {
        public int ItemHistoricoID { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
        public int DisciplinaID { get; set; }
        public virtual Disciplina Disciplina { get; set; }
        public string AnoSemestre { get; set; }  // 2021-2
        public double Nota { get; set; } // 7.0
    }
}
