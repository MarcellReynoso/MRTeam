using Microsoft.EntityFrameworkCore;
using mrteam.Models;
using mrteam.Servicios.Contrato;

namespace mrteam.Servicios.Implementacion
{
    public class UsuarioService : IUsuarioService
    {
        private readonly MrteamContext _dbcontext;

        public UsuarioService(MrteamContext mrteam)
        {
            _dbcontext = mrteam; // Utiliza el contexto recibido a través de la inyección de dependencias
        }

        public async Task<Usuario> GetUsuarios(string email, string password)
        {
            Usuario usuario_encontrado = await _dbcontext.Usuarios
                .Where(u => u.Email == email && u.Password == password)
                .FirstOrDefaultAsync();

            return usuario_encontrado;
        }

        public async Task<Usuario> SaveUsuarios(Usuario modelo)
        {
            _dbcontext.Usuarios.Add(modelo);
            await _dbcontext.SaveChangesAsync();
            return modelo;
        }
    }
}