using PolarisContacts.Domain;
using System.Threading.Tasks;

namespace PolarisContacts.CreateService.Application.Interfaces.Services
{
    public interface IUsuarioService
    {
        Task<bool> CreateUser(string login, string senha);
    }
}