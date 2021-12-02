using Persistencia.Repositorio;
using Entidades.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Negocio.DAO
{

    public class DAOUsuariosEF : DAOUsuarios
    {
        private readonly SchoolContext _context;

        public DAOUsuariosEF(SchoolContext context)
        {
            _context = context;
        }

        public async Task<ApplicationUser> ComEmail(string email)
        {
            return await _context.ApplicationUser.FirstOrDefaultAsync(p => p.Email == email);
        }
    }
}
