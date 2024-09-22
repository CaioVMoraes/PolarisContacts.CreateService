using Dapper;
using PolarisContacts.Application.Interfaces.Repositories;
using PolarisContacts.Domain;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace PolarisContacts.Infrastructure.Repositories
{
    public class EmailRepository(IDatabaseConnection dbConnection) : IEmailRepository
    {
        private readonly IDatabaseConnection _dbConnection = dbConnection;

        public async Task<int> AddEmail(Email email, IDbConnection connection, IDbTransaction transaction)
        {
            string query;
            var isSqlServer = connection.GetType() == typeof(SqlConnection);

            if (isSqlServer)
            {
                // SQL Server
                query = @"INSERT INTO Emails (IdContato, EnderecoEmail, Ativo) 
                             OUTPUT INSERTED.Id
                             VALUES (@IdContato, @EnderecoEmail, @Ativo)";
            }
            else
            {
                // SQLite
                query = @"INSERT INTO Emails (IdContato, EnderecoEmail, Ativo) 
                            VALUES (@IdContato, @EnderecoEmail, @Ativo);
                            SELECT last_insert_rowid();";
            }

            return await connection.QuerySingleAsync<int>(query, email, transaction);
        }
    }
}
