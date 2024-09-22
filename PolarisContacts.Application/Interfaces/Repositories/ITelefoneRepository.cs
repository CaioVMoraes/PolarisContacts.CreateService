using PolarisContacts.Domain;
using System.Data;
using System.Threading.Tasks;

namespace PolarisContacts.Application.Interfaces.Repositories
{
    public interface ITelefoneRepository
    {
        Task<int> AddTelefone(Telefone telefone, IDbConnection connection, IDbTransaction transaction);
    }
}