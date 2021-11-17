using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entidades.Models
{
    public class Disciplina
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int DisciplinaID { get; set; }
        public string Codcred { get; set; }
        public string Nome { get; set; }

        //public ICollection<Disciplina> Requerimentos { get; set; }
    }
}