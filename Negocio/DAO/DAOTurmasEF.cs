using System;
using System.Collections.Generic;
using System.Linq;
using Persistencia.Repositorio;
using Entidades.Models;
using Microsoft.EntityFrameworkCore;

namespace Negocio.DAO
{
    class DAOTurmasEF : DAOTurmas
    {
        private SchoolContext db = new SchoolContext();

        public List<Turma> buscarTurmas(string searchString){
            var turmas = db.Turma.Where(t => t.Disciplina.Codcred.Contains(searchString)
                                    || t.Horario.Contains(searchString)
                                    || t.Numero.Contains(searchString)).ToList();

            return turmas;
        }

        public Turma buscarTurmaById(int id){
            Turma turma = db.Turma
                .Include(t => t.Disciplina)
                .FirstOrDefault(m => m.TurmaID == id);
            
            return turma;
        }

        public bool criarTurma(Turma turma){
            return true;
        }

        public bool editarTurma(Turma turma){
            return true;
        }

        public bool deletarTurma(int id){
            return true;
        }

    }
}
