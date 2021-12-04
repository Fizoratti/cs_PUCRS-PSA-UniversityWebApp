using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Persistencia.Repositorio;
using Entidades.Models;

namespace Negocio.DAO
{
    public interface DAOHistorico
    {
        public Task<IEnumerable<ItemHistorico>> buscarHistorico(string applicationUserMatricula);
    }
}