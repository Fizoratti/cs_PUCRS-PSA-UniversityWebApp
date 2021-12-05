using System.Collections.Generic;
using System.Threading.Tasks;
using Entidades.Models;

namespace Negocio.DAO
{
    public interface DAOUsuarios
    {
        Task<ApplicationUser> ComEmail(string emailDoUsuario);
        Task Atualiza(ApplicationUser usuario);
        Task<IEnumerable<ApplicationUser>> ListarAlunos(string disciplina);
    }
}
