using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Entidades.Models;
using Persistencia.Repositorio;

namespace Negocio.DAO
{
    public class DAODisciplinaEF : DAODisciplina
    {
        private SchoolContext db = new SchoolContext();
        

        public async Task<Disciplina> buscarDiciplinaPorCodCred(string codCred)
        {
            var disciplina = await db.Disciplinas.Where(x =>
                x.Codcred.Contains(codCred)
            ).FirstOrDefaultAsync();

            return disciplina;            
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
