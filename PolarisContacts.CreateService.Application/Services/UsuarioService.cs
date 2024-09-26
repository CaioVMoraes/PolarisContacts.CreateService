using PolarisContacts.CreateService.Application.Interfaces.Services;
using static PolarisContacts.CreateService.Helpers.Exceptions.CustomExceptions;

namespace PolarisContacts.CreateService.Application.Services
{
    public class UsuarioService : IUsuarioService
    {
        public void ValidaUsuario(string login, string senha)
        {
            if (string.IsNullOrEmpty(login))
            {
                throw new LoginVazioException();
            }
            if (string.IsNullOrEmpty(senha))
            {
                throw new SenhaVaziaException();
            }
        }
    }
}

