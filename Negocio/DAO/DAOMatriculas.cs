using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Persistencia.Repositorio;
using Entidades.Models;

namespace Negocio.DAO
{
    public interface DAOMatriculas
    {
        List<Matricula> buscarMatriculas(string applicationUserMatricula);
        Matricula buscarMatriculas(int id);
        void matricularAluno(int id, string applicationUserMatricula);
        bool editarMatriculaAluno(int id);
        bool excluirMatriculaAluno(int id);
        bool verificaExistenciaMatricula(int id);
        Task Salvar(Matricula matricula);
    }
}
