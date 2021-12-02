using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Persistencia.Repositorio;
using Entidades.Models;

namespace Negocio.DAO
{
    public interface DAOTurmas
    {
        List<Turma> buscarTurmas(string searchString);
        Task<IEnumerable<Turma>> ListarTurmas(string pesquisa);
        Turma BuscarTurmaById(int id);
        bool criarTurma(Turma turma);
        bool editarTurma(Turma turma);
        bool deletarTurma(int id);
        Task<Turma> ComId(int turmaID);

        Task Salvar(Turma turma);

        Task<bool> DiminuirVaga(int turmaID);
    }
}
