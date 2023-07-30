using Microsoft.EntityFrameworkCore;
using mrteam.Models;

namespace mrteam.Servicios.Contrato
{
    public interface IUsuarioService
    {
        Task<Usuario> GetUsuarios(string email, string password);

        Task<Usuario> SaveUsuarios(Usuario modelo);
    }
}
