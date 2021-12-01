using Negocio.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    class Facade
    {
        private DAOMatriculas dados = new DAOMatriculasEF();

        public Boolean Matricular(int turmaID, string applicationUserMatricula)
        {
            return dados.matricularAluno(turmaID, applicationUserMatricula);
        }
    }
}
