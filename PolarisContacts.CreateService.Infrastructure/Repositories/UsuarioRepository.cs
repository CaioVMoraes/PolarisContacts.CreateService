using Dapper;
using PolarisContacts.CreateService.Application.Interfaces.Repositories;
using PolarisContacts.DatabaseConnection;
using PolarisContacts.Domain;
using System.Data;
using System.Threading.Tasks;

namespace PolarisContacts.CreateService.Infrastructure.Repositories
{
    public class UsuarioRepository(IDatabaseConnection dbConnection) : IUsuarioRepository
    {
        private readonly IDatabaseConnection _dbConnection = dbConnection;

        public async Task<bool> CreateUser(string login, string senha)
        {
            using IDbConnection conn = _dbConnection.AbrirConexao();

            string query = "INSERT INTO Usuarios ([Login], Senha, Ativo) VALUES (@Login, @Senha, 1)";

            return await conn.ExecuteAsync(query, new { Login = login, Senha = senha }) > 0;
        }
    }
}
