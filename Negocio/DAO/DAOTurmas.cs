using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Persistencia.Repositorio;
using Entidades.Models;

namespace Negocio.DAO
{
    interface DAOTurmas
    {
        List<Turma> buscarTurmas(string searchString);
        Turma buscarTurmaById(int id);
        bool criarTurma(Turma turma);
        bool editarTurma(Turma turma);
        bool deletarTurma(int id);
    }
}
