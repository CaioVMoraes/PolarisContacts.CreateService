using Dapper;
using PolarisContacts.Application.Interfaces.Repositories;
using PolarisContacts.Domain;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace PolarisContacts.Infrastructure.Repositories
{
    public class EnderecoRepository(IDatabaseConnection dbConnection) : IEnderecoRepository
    {
        private readonly IDatabaseConnection _dbConnection = dbConnection;

        public async Task<int> AddEndereco(Endereco endereco, IDbConnection connection, IDbTransaction transaction)
        {
            string query;
            var isSqlServer = connection.GetType() == typeof(SqlConnection);

            if (isSqlServer)
            {
                // SQL Server
                query = @"INSERT INTO Enderecos (IdContato, Logradouro, Numero, Cidade, Estado, Bairro, Complemento, CEP, Ativo) 
                             OUTPUT INSERTED.Id
                             VALUES (@IdContato, @Logradouro, @Numero, @Cidade, @Estado, @Bairro, @Complemento, @CEP, @Ativo)";
            }
            else
            {
                // SQLite
                query = @"INSERT INTO Enderecos (IdContato, Logradouro, Numero, Cidade, Estado, Bairro, Complemento, CEP, Ativo) 
                            VALUES (@IdContato, @Logradouro, @Numero, @Cidade, @Estado, @Bairro, @Complemento, @CEP, @Ativo);
                            SELECT last_insert_rowid();";
            }

            return await connection.QuerySingleAsync<int>(query, endereco, transaction);

        }
    }
}
