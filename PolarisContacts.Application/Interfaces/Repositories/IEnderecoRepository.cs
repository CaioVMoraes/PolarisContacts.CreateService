using PolarisContacts.Domain;
using System.Data;
using System.Threading.Tasks;

namespace PolarisContacts.Application.Interfaces.Repositories
{
    public interface IEnderecoRepository
    {
        Task<int> AddEndereco(Endereco endereco, IDbConnection connection, IDbTransaction transaction);
    }
}