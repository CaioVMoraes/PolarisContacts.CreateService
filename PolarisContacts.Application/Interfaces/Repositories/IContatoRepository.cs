using PolarisContacts.Domain;
using System.Data;
using System.Threading.Tasks;

namespace PolarisContacts.Application.Interfaces.Repositories
{
    public interface IContatoRepository
    {
        Task<int> AddContato(Contato contato, IDbConnection connection, IDbTransaction transaction);
    }
}