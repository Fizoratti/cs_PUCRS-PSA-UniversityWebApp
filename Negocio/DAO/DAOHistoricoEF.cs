using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Persistencia.Repositorio;
using System;
using Entidades.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Negocio.DAO
{
    class DAOHistoricoEF : DAOHistorico
    {
        private SchoolContext db = new SchoolContext();

        public List<Historico> buscarHistorico(string applicationUserMatricula){

            var historico = await _context.Historico
                                .Where(e => e.ApplicationUser.Matricula == applicationUserMatricula).ToListAsync();

            return historico;         
         }
    }
}
