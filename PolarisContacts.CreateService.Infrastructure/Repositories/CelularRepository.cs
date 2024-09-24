using Dapper;
using PolarisContacts.CreateService.Application.Interfaces.Repositories;
using PolarisContacts.DatabaseConnection;
using PolarisContacts.Domain;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace PolarisContacts.CreateService.Infrastructure.Repositories
{
    public class CelularRepository(IDatabaseConnection dbConnection) : ICelularRepository
    {
        private readonly IDatabaseConnection _dbConnection = dbConnection;

        public async Task<int> AddCelular(Celular celular, IDbConnection connection, IDbTransaction transaction)
        {
            string query;
            var isSqlServer = connection.GetType() == typeof(SqlConnection);

            if (isSqlServer)
            {
                // SQL Server
                query = @"INSERT INTO Celulares (IdRegiao, IdContato, NumeroCelular, Ativo) 
                             OUTPUT INSERTED.Id
                             VALUES (@IdRegiao, @IdContato, @NumeroCelular, @Ativo)";
            }
            else
            {
                // SQLite
                query = @"INSERT INTO Celulares (IdRegiao, IdContato, NumeroCelular, Ativo) 
                            VALUES (@IdRegiao, @IdContato, @NumeroCelular, @Ativo);
                            SELECT last_insert_rowid();";
            }

            return await connection.QuerySingleAsync<int>(query, celular, transaction);
        }
    }
}
