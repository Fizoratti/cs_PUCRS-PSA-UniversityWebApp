using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades.Models;
using Persistencia.Repositorio;

namespace Negocio.DAO
{

    class DAOUsuarioEF
    {
        private SchoolContext db = new SchoolContext();

        public ApplicationUser getUser() {
            return db.ApplicationUser.FirstOrDefault();
        }
    }
}
