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
    class DAOMatriculasEF : DAOMatriculas
    {
        private SchoolContext db = new SchoolContext();

        public bool matricular(int turmaID, string applicationUserMatricula)
        {
            var matricula = db.Matriculas.
            Include("Turma").FirstOrDefault(m => m.MatriculaID == turmaID);

            matricula.ApplicationUser.Matricula = applicationUserMatricula;

            db.SaveChanges();
            return true;
        }

        /*
        public bool comprarItem(int id, string compradorID)
        {
            var itemVenda = db.ItemsVendas.
            Include("Status").Include("Vendedor").FirstOrDefault(m => m.ItemVendaId == id);

            itemVenda.StatusID = 2;
            itemVenda.CompradorID = compradorID;

            db.SaveChanges();
            return true;
        }
        */
    }
}
