using PolarisContacts.Domain;
using System.Threading.Tasks;

namespace PolarisContacts.Application.Interfaces.Services
{
    public interface IUsuarioService
    {
        Task<bool> CreateUserAsync(string login, string senha);
    }
}