using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entidades.Models
{

    public class Matricula
    {
        public int MatriculaID { get; set; }
        public string ApplicationUserID { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
        public int TurmaID { get; set; }
        public virtual Turma Turma { get; set; }
    }
}