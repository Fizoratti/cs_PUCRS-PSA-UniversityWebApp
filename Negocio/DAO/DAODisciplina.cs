using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Entidades.Models;

namespace Negocio.DAO
{
    public interface DAODisciplina
    {
        //Visualizar disciplinas, turmas e vagas disponíveis para sua matrícula
        List<Disciplina> visualizarDisciplinas();

        //retornar uma disciplina
        Disciplina buscarDiciplinaPorNome(String nome);

        Task<Disciplina> buscarDiciplinaPorCodCred(String codCred);
        

        //Listar quais disciplinas são requisitos.
        //List<Disciplina> listarRequisitosDisciplinas(Disciplina d);

    }
}
