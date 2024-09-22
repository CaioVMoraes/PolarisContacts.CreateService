using PolarisContacts.Domain;
using System.Data;
using System.Threading.Tasks;

namespace PolarisContacts.Application.Interfaces.Repositories
{
    public interface IEmailRepository
    {
        Task<int> AddEmail(Email email, IDbConnection connection, IDbTransaction transaction);
    }
}
