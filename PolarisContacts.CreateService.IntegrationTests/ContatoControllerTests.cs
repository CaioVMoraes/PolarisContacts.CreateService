using Newtonsoft.Json;
using PolarisContacts.CreateService.Domain;
using System.Text;

namespace PolarisContacts.CreateService.IntegrationTests
{
    public class ContatoControllerTests : IClassFixture<IntegrationTestFixture>
    {
        private readonly HttpClient _client;
        private readonly IntegrationTestFixture _fixture;

        public ContatoControllerTests(IntegrationTestFixture fixture)
        {
            _fixture = fixture;
            _client = fixture.Client;
        }

        [Fact]
        public async Task AddContato_ReturnsSuccess()
        {
            var contato = new Contato
            {
                Nome = "Contato de Teste",
                IdUsuario = 2,
                Ativo = true,
                Celulares = new List<Celular>
            {
                new Celular
                {
                    IdRegiao = 1,
                    NumeroCelular = "12345-6789",
                    Ativo = true
                }
            },
                Enderecos = new List<Endereco>
            {
                new Endereco
                {
                    Logradouro = "Rua dos Cabiros",
                    Numero = "36",
                    Cidade = "São Paulo",
                    Estado = "SP",
                    Bairro = "Jardim Itajaí",
                    Complemento = "Casa",
                    CEP = "04855-140",
                    Ativo = true
                }
            },
                Telefones = new List<Telefone>
            {
                new Telefone
                {
                    IdRegiao = 1,
                    NumeroTelefone = "5526-9799",
                    Ativo = true
                }
            },
                Emails = new List<Email>
            {
                new Email
                {
                    EnderecoEmail = "Jhonatanpsilva77@gmail.com",
                    Ativo = true
                }
            }
            };

            var content = new StringContent(JsonConvert.SerializeObject(contato), Encoding.UTF8, "application/json");

            // Faz a requisição para inserir o contato
            var response = await _client.PostAsync("/Create/Contato/AddContato", content);

            // Verifica se a resposta é bem-sucedida
            Assert.True(response.IsSuccessStatusCode);
        }

        [Fact]
        public async Task InsertCelular_ReturnsSuccess()
        {
            var contato = new Contato
            {
                Nome = "Contato de Teste",
                IdUsuario = 2,
                Ativo = true,
                Celulares = new List<Celular>
            {
                new Celular
                {
                    IdRegiao = 1,
                    NumeroCelular = "12345-6789",
                    Ativo = true
                }
            }
            };

            var content = new StringContent(JsonConvert.SerializeObject(contato), Encoding.UTF8, "application/json");

            // Faz a requisição para inserir o contato
            var response = await _client.PostAsync("/Create/Contato/AddContato", content);

            // Verifica se a resposta é bem-sucedida
            Assert.True(response.IsSuccessStatusCode);
        }

        [Fact]
        public async Task InsertEndereco_ReturnsSuccess()
        {
            var contato = new Contato
            {
                Nome = "Contato de Teste",
                IdUsuario = 2,
                Ativo = true,
                Enderecos = new List<Endereco>
            {
                new Endereco
                {
                    Logradouro = "Rua dos Cabiros",
                    Numero = "36",
                    Cidade = "São Paulo",
                    Estado = "SP",
                    Bairro = "Jardim Itajaí",
                    Complemento = "Casa",
                    CEP = "04855-140",
                    Ativo = true
                }
            }
            };

            var content = new StringContent(JsonConvert.SerializeObject(contato), Encoding.UTF8, "application/json");

            // Faz a requisição para inserir o contato
            var response = await _client.PostAsync("/Create/Contato/AddContato", content);

            // Verifica se a resposta é bem-sucedida
            Assert.True(response.IsSuccessStatusCode);
        }

        [Fact]
        public async Task InsertTelefone_ReturnsSuccess()
        {
            var contato = new Contato
            {
                Nome = "Contato de Teste 2",
                IdUsuario = 2,
                Ativo = true,
                Telefones = new List<Telefone>
            {
                new Telefone
                {
                    IdRegiao = 1,
                    NumeroTelefone = "5526-9799",
                    Ativo = true
                }
            }
            };

            var content = new StringContent(JsonConvert.SerializeObject(contato), Encoding.UTF8, "application/json");

            // Faz a requisição para inserir o contato
            var response = await _client.PostAsync("/Create/Contato/AddContato", content);

            // Verifica se a resposta é bem-sucedida
            Assert.True(response.IsSuccessStatusCode);
        }

        [Fact]
        public async Task InsertEmail_ReturnsSuccess()
        {
            var contato = new Contato
            {
                Nome = "Contato de Teste 3",
                IdUsuario = 2,
                Ativo = true,
                Emails = new List<Email>
            {
                new Email
                {
                    EnderecoEmail = "Jhonatanpsilva77@gmail.com",
                    Ativo = true
                }
            }
            };

            var content = new StringContent(JsonConvert.SerializeObject(contato), Encoding.UTF8, "application/json");

            // Faz a requisição para inserir o contato
            var response = await _client.PostAsync("/Create/Contato/AddContato", content);

            // Verifica se a resposta é bem-sucedida
            Assert.True(response.IsSuccessStatusCode);
        }

    }
}