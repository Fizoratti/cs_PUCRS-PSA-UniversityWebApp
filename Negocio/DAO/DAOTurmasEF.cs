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

        public DAOTurmasEF(SchoolContext schoolContext)
        {
            _context = schoolContext;
        }

        public List<Turma> buscarTurmas(string searchString)
        {
            var turmas = _context.Turma.Where(t => t.Disciplina.Codcred.Contains(searchString)
                                    || t.Horario.Contains(searchString)
                                    || t.Numero.Contains(searchString)).ToList();

            return turmas;
        }

        public async Task<Turma> ComId(int id)
        {
            Turma turma = await _context.Turma
              .Include(t => t.Disciplina)
              .FirstOrDefaultAsync(m => m.TurmaID == id);

            return turma;
        }

        public Turma BuscarTurmaById(int id)
        {
            Turma turma = _context.Turma
                .Include(t => t.Disciplina)
                .FirstOrDefault(m => m.TurmaID == id);

            return turma;
        }

        public Task criarTurma(Turma turma)
        {
            throw new NotImplementedException();
        }

        public Task editarTurma(Turma turma)
        {
            throw new NotImplementedException();
        }

        public async Task deletarTurma(int id)
        {
            _context.Turma.Remove(BuscarTurmaById(id));

            await _context.SaveChangesAsync();
        }

        public Task<bool> DiminuirVaga(int turmaID)
        {
            throw new NotImplementedException();
        }

        public async Task Salvar(Turma turma)
        {
            await _context.Turma.AddAsync(turma);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Turma>> ListarTurmas(string pesquisa)
        {
            var turmas = _context
                .Turma
                .Include(p=> p.Disciplina)
                .Include(p=> p.Matriculas)
                .AsQueryable();
            if (!string.IsNullOrEmpty(pesquisa))
            {
                turmas = turmas.Where(p =>
                    p.Disciplina.Nome.Contains(pesquisa) ||
                    p.Disciplina.Codcred.Contains(pesquisa) ||
                    p.Horario.Contains(pesquisa) ||
                    p.Numero.Contains(pesquisa));
            }
            return await turmas.ToListAsync();
        }

       
        
    }
}
