
using System.Collections.Generic;
using System.Linq;
using Persistencia.Repositorio;
using Entidades.Models;

namespace Negocio.DAO
{
    public class DAOHistoricoEF : DAOHistorico
    {
        private readonly SchoolContext _schoolContext;

        public DAOHistoricoEF(SchoolContext schoolContext)
        {
            this._schoolContext = schoolContext;
        }


        public List<ItemHistorico> buscarHistorico(string applicationUserMatricula){

            var historico = _schoolContext.Historico
                                .Where(e => e.ApplicationUser.Matricula == applicationUserMatricula).ToList();

            return historico;         
         }
    }
}
