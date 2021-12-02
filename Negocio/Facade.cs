using Entidades.Models;
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

        public void Matricular(int turmaID, string applicationUserMatricula)
        {
            dados.matricularAluno(turmaID, applicationUserMatricula);
        }

        public List<Matricula> Listar(string applicationUserMatricula)
        {
            return dados.buscarMatriculas(applicationUserMatricula);
        }
    }
}
