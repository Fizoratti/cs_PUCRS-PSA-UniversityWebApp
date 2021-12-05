using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        public string Horario { get; set; }
        public string Numero { get; set; }
        public string Percentual => string.Format("{0:N}", (1-((double)VagasDisponiveis / (double)Vagas)) * 100);// (1/12)*100
        
        // capacidade da turma
        public int Vagas { get; private set; }
        public int VagasDisponiveis => Vagas - Matriculas.Count();
        public ICollection<Matricula> Matriculas { get; set; }

        public Turma()
        {
            Matriculas = new Collection<Matricula>();
        }
    }
}
