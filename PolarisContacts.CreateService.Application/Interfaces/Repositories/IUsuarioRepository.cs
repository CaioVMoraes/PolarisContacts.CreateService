using System.Threading.Tasks;

namespace PolarisContacts.CreateService.Application.Interfaces.Repositories
{
    public interface IUsuarioRepository
    {
        Task<bool> CreateUser(string login, string senha);
    }
}