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
        private readonly SchoolContext _context;

        public DAODisciplinaEF(SchoolContext schoolContext)
        {
            this._context = schoolContext;
        }


        public async Task<Disciplina> buscarDiciplinaPorCodCred(string codCred)
        {
            var disciplina = await _context.Disciplinas.Where(x =>
                x.Codcred.Contains(codCred)
            ).FirstOrDefaultAsync();

            return disciplina;            
        }

        public Disciplina buscarDiciplinaPorNome(string nome)
        {
            Disciplina d = _context.Disciplinas.Where(x =>
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

        public async Task<IEnumerable<Disciplina>> ListarDisciplinas()
        {
            var disciplina = _context.Disciplinas.AsQueryable();
            return await disciplina.ToListAsync();
        }

        public async Task<IEnumerable<ItemHistorico>> buscarHistorico(string applicationUserMatricula)
        {

            var historico = _context
                .Historico
                .Include(e => e.ApplicationUser)
                .Include(e => e.Disciplina)
                .AsQueryable();
            if (!string.IsNullOrEmpty(applicationUserMatricula))
            {
                historico = historico.Where(e =>
                    e.ApplicationUser.Matricula == applicationUserMatricula);
            }
            return await historico.ToListAsync();
        }
    }
}
