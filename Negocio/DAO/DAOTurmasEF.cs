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
    class DAOTurmasEF : DAOTurmas
    {
        private SchoolContext db = new SchoolContext();

        public List<Turma> buscarTurmas(string searchString){
            var turmas = turmas.Where(t => t.Disciplina.Codcred.Contains(searchString)
                                    || t.Horario.Contains(searchString)
                                    || t.Numero.Contains(searchString));

            return turmas;
        }

        public Turma buscarTurmaById(int id){
            var turma = await _context.Turma
                .Include(t => t.Disciplina)
                .FirstOrDefaultAsync(m => m.TurmaID == id);
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
