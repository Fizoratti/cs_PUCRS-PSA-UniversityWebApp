
using System.Collections.Generic;
using System.Linq;
using Persistencia.Repositorio;
using Entidades.Models;

namespace Negocio.DAO
{
    class DAOHistoricoEF : DAOHistorico
    {
        private SchoolContext db = new SchoolContext();

        public List<ItemHistorico> buscarHistorico(string applicationUserMatricula){

            var historico = db.Historico
                                .Where(e => e.ApplicationUser.Matricula == applicationUserMatricula).ToList();

            return historico;         
         }
    }
}
