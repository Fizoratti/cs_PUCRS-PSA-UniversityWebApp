using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entidades.Models
{

    public class Matricula
    {
        public int MatriculaID { get; set; }
        public double? Nota { get; set; }
        public ApplicationUser Student { get; set; }
    }
}