using System;
using System.Collections.Generic;
using System.Linq;
using Persistencia.Repositorio;
using Entidades.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Negocio.DAO
{
    public class DAOTurmasEF : DAOTurmas
    {
        private SchoolContext _context;

        public DAOTurmasEF(SchoolContext context)
        {
            _context = context;
        }

        public List<Turma> buscarTurmas(string searchString){
            var turmas = _context.Turma.Where(t => t.Disciplina.Codcred.Contains(searchString)
                                    || t.Horario.Contains(searchString)
                                    || t.Numero.Contains(searchString)).ToList();

            return turmas;
        }

        public async Task<Turma> ComId(int id) {
            Turma turma = await _context.Turma
              .Include(t => t.Disciplina)
              .FirstOrDefaultAsync(m => m.TurmaID == id);

            return turma;
        }
    
        public Turma BuscarTurmaById(int id){
            Turma turma = _context.Turma
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

        public Task<bool> DiminuirVaga(int turmaID)
        {
            throw new NotImplementedException();
        }
    }
}
