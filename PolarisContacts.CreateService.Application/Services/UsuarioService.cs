using PolarisContacts.CreateService.Application.Interfaces.Repositories;
using PolarisContacts.CreateService.Application.Interfaces.Services;
using PolarisContacts.Domain;
using System.Threading.Tasks;
using static PolarisContacts.CrossCutting.Helpers.Exceptions.CustomExceptions;

namespace PolarisContacts.CreateService.Application.Services
{
    public class UsuarioService(IUsuarioRepository usuarioRepository) : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository = usuarioRepository;

        public async Task<bool> CreateUser(string login, string senha)
        {
            if (string.IsNullOrEmpty(login))
            {
                throw new LoginVazioException();
            }
            if (string.IsNullOrEmpty(senha))
            {
                throw new SenhaVaziaException();
            }

            return await _usuarioRepository.CreateUser(login, senha);
        }
    }
}

