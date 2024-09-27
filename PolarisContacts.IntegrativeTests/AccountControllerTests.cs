public class AccountControllerTests : IClassFixture<IntegrationTestFixture>
{
    private readonly HttpClient _client;
    private readonly IntegrationTestFixture _fixture;

    public AccountControllerTests(IntegrationTestFixture fixture)
    {
        _fixture = fixture;
        _client = fixture.Client;
    }

    [Fact]
    public async Task CreateUser_ReturnSuccess()
    {
        // Define os dados de teste
        string login = "Login Teste";
        string senha = "102030";       

        // Cria a URL com os parâmetros na query string
        var url = $"Usuario/CreateUser?login={login}&senha={senha}";

        // Faz a requisição para alterar a senha via POST
        var response = await _client.PostAsync(url, null); 

        // Lê o conteúdo da resposta
        var responseContent = await response.Content.ReadAsStringAsync();

        // Verifica se a resposta é bem-sucedida
        Assert.True(response.IsSuccessStatusCode);
        Assert.Equal("Mensagem publicada com sucesso.", responseContent);
    }
}
