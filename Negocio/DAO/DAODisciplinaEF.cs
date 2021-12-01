using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entidades.Models;
using Persistencia.Repositorio;

namespace Negocio.DAO
{
    public class DAODisciplinaEF : DAODisciplina
    {
        private SchoolContext db = new SchoolContext();
        

        public Disciplina buscarDiciplinaPorCodCredAsync(string codCred)
        {
            Disciplina d = db.Disciplinas.Where(x =>
                x.codCred.Contains(codCred)
            )
                .FirstOrDefault();

            return d;
            
        }

        public Disciplina buscarDiciplinaPorNome(string nome)
        {
            Disciplina d = db.Disciplinas.Where(x =>
                x.nome.Contains(nome)
            )
                .FirstOrDefault();

            return d;
        }

        public List<Disciplina> ListarRequisitosDisciplinas(Disciplina d)
        {
             var disciplina = d.Requerimentos.ToList();
             
            return disciplina;
        }

        public List<Disciplina> visualizarDisciplinas()
        {
             var disciplina = db.Disciplinas.ToList();
             
            return disciplina;
            
        }
    }
}
