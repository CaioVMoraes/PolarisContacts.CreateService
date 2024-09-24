using Dapper;
using PolarisContacts.CreateService.Application.Interfaces.Repositories;
using PolarisContacts.DatabaseConnection;
using PolarisContacts.Domain;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace PolarisContacts.CreateService.Infrastructure.Repositories
{
    public class TelefoneRepository(IDatabaseConnection dbConnection) : ITelefoneRepository
    {
        private readonly IDatabaseConnection _dbConnection = dbConnection;

        public async Task<int> AddTelefone(Telefone telefone, IDbConnection connection, IDbTransaction transaction)
        {
            string query;
            var isSqlServer = connection.GetType() == typeof(SqlConnection);

            if (isSqlServer)
            {
                // SQL Server
                query = @"INSERT INTO Telefones (IdRegiao, IdContato, NumeroTelefone, Ativo) 
                             OUTPUT INSERTED.Id
                             VALUES (@IdRegiao, @IdContato, @NumeroTelefone, @Ativo)";
            }
            else
            {
                // SQLite
                query = @"INSERT INTO Telefones (IdRegiao, IdContato, NumeroTelefone, Ativo) 
                            VALUES (@IdRegiao, @IdContato, @NumeroTelefone, @Ativo);
                            SELECT last_insert_rowid();";
            }

            return await connection.QuerySingleAsync<int>(query, telefone, transaction);
        }
    }
}