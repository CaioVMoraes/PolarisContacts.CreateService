using PolarisContacts.Domain;
using System.Data;
using System.Threading.Tasks;

namespace PolarisContacts.CreateService.Application.Interfaces.Repositories
{
    public interface IEmailRepository
    {
        Task<int> AddEmail(Email email, IDbConnection connection, IDbTransaction transaction);
    }
}
