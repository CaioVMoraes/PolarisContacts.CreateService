using Dapper;
using PolarisContacts.Application.Interfaces.Repositories;
using PolarisContacts.Domain;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace PolarisContacts.Infrastructure.Repositories
{
    public class ContatoRepository(IDatabaseConnection dbConnection) : IContatoRepository
    {
        private readonly IDatabaseConnection _dbConnection = dbConnection;
        
        public async Task<int> AddContato(Contato contato, IDbConnection connection, IDbTransaction transaction)
        {
            string query;
            var isSqlServer = connection.GetType() == typeof(SqlConnection);

            if (isSqlServer)
            {
                // SQL Server
                query = @"INSERT INTO Contatos (Nome, IdUsuario, Ativo)
                          OUTPUT INSERTED.Id
                          VALUES (@Nome, @IdUsuario, @Ativo)";
            }
            else
            {
                // SQLite
                query = @"INSERT INTO Contatos (Nome, IdUsuario, Ativo)
                          VALUES (@Nome, @IdUsuario, @Ativo);
                          SELECT last_insert_rowid();";
            }

            return await connection.QuerySingleAsync<int>(query, contato, transaction);
        }
    }
}