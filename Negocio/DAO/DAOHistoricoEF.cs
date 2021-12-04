
using System.Collections.Generic;
using System.Linq;
using Persistencia.Repositorio;
using Entidades.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Negocio.DAO
{
    public class DAOHistoricoEF : DAOHistorico
    {
        private readonly SchoolContext _context;

        public DAOHistoricoEF(SchoolContext schoolContext)
        {
            this._context = schoolContext;
        }


        public async Task<IEnumerable<ItemHistorico>> buscarHistorico(string applicationUserMatricula){

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
