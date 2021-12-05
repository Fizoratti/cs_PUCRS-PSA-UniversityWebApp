using Persistencia.Repositorio;
using Entidades.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Negocio.DAO
{

    public class DAOUsuariosEF : DAOUsuarios
    {
        private readonly SchoolContext _context;

        public DAOUsuariosEF(SchoolContext schoolContext)
        {
            _context = schoolContext;
        }

        public async Task Atualiza(ApplicationUser usuario)
        {
            _context.Users.Update(usuario);
            await _context.SaveChangesAsync();
        }

        public async Task<ApplicationUser> ComEmail(string email)
        {
            return await _context
                .ApplicationUser
                .Include(p=> p.Matriculas)
                    .ThenInclude(p=> p.Turma)
                        .ThenInclude(p=> p.Disciplina)
                .FirstOrDefaultAsync(p => p.Email == email);
        }

        public async Task<IEnumerable<ApplicationUser>> ListarAlunos(string disciplina)
        {
            var alunos = _context
                .ApplicationUser.AsQueryable();
           
            return await alunos.ToListAsync();
        }
    }
}
