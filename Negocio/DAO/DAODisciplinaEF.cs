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
        

        public Disciplina buscarDiciplinaPorCodCred(string codCred)
        {
            Disciplina d = db.Disciplinas.Where(x =>
                x.Codcred.Contains(codCred)
            )
                .FirstOrDefault();

            return d;
            
        }

        public Disciplina buscarDiciplinaPorNome(string nome)
        {
            Disciplina d = db.Disciplinas.Where(x =>
                x.Nome.Contains(nome)
            )
                .FirstOrDefault();

            return d;
        }

        //public List<Disciplina> listarRequisitosDisciplinas(Disciplina d)
        //{
        //     var disciplina = d.Requerimentos.ToList();
             
        //    return disciplina;
        //}

        public List<Disciplina> visualizarDisciplinas()
        {
            List<Disciplina> disciplina = (List<Disciplina>)db.Disciplinas.ToList();
             
            return disciplina;
            
        }
    }
}
