using System.Threading.Tasks;
using Entidades.Models;

namespace Negocio.DAO
{
    public interface DAOUsuarios
    {
        Task<ApplicationUser> ComEmail(string emailDoUsuario);
    }
}
