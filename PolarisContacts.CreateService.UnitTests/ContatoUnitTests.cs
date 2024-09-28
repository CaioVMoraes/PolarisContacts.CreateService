using PolarisContacts.CreateService.Application.Services;
using PolarisContacts.CreateService.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PolarisContacts.CreateService.Helpers.Exceptions.CustomExceptions;

namespace PolarisContacts.CreateService.UnitTests
{
    public class ContatoUnitTests
    {
        private readonly ContatoService _contatoService;

        public ContatoUnitTests()
        {
            _contatoService = new ContatoService();
        }

        [Fact]
        public void ValidaContato_DeveLancarUsuarioNotFoundException_QuandoIdUsuarioEhInvalido()
        {
            // Arrange
            var contato = new Contato { IdUsuario = 0, Nome = "Contato Valido" };

            // Act & Assert
            Assert.Throws<UsuarioNotFoundException>(() => _contatoService.ValidaContato(contato));
        }

        [Fact]
        public void ValidaContato_DeveLancarNomeObrigatorioException_QuandoNomeEhVazio()
        {
            // Arrange
            var contato = new Contato { IdUsuario = 1, Nome = "" };

            // Act & Assert
            Assert.Throws<NomeObrigatorioException>(() => _contatoService.ValidaContato(contato));
        }

        [Fact]
        public void ValidaContato_DeveLancarTelefoneInvalidoException_QuandoTelefoneEhInvalido()
        {
            // Arrange
            var contato = new Contato
            {
                IdUsuario = 1,
                Nome = "Contato Valido",
                Telefones = new List<Telefone> { new Telefone { NumeroTelefone = "12345" } } // Telefone inválido
            };

            // Act & Assert
            Assert.Throws<TelefoneInvalidoException>(() => _contatoService.ValidaContato(contato));
        }

        [Fact]
        public void ValidaContato_DeveLancarCelularInvalidoException_QuandoCelularEhInvalido()
        {
            // Arrange
            var contato = new Contato
            {
                IdUsuario = 1,
                Nome = "Contato Valido",
                Celulares = new List<Celular> { new Celular { NumeroCelular = "12345" } } // Celular inválido
            };

            // Act & Assert
            Assert.Throws<CelularInvalidoException>(() => _contatoService.ValidaContato(contato));
        }

        [Fact]
        public void ValidaContato_DeveLancarEmailInvalidoException_QuandoEmailEhInvalido()
        {
            // Arrange
            var contato = new Contato
            {
                IdUsuario = 1,
                Nome = "Contato Valido",
                Emails = new List<Email> { new Email { EnderecoEmail = "emailinvalido" } } // Email inválido
            };

            // Act & Assert
            Assert.Throws<EmailInvalidoException>(() => _contatoService.ValidaContato(contato));
        }

        [Fact]
        public void ValidaContato_DeveLancarEnderecoInvalidoException_QuandoEnderecoEhInvalido()
        {
            // Arrange
            var contato = new Contato
            {
                IdUsuario = 1,
                Nome = "Contato Valido",
                Enderecos = new List<Endereco> { new Endereco { Logradouro = "", Cidade = "Cidade Valida", Estado = "Estado Valido", CEP = "00000-000" } } // Endereço inválido
            };

            // Act & Assert
            Assert.Throws<EnderecoInvalidoException>(() => _contatoService.ValidaContato(contato));
        }

        [Fact]
        public void ValidaContato_DeveRetornarContato_QuandoContatoEhValido()
        {
            // Arrange
            var contato = new Contato
            {
                IdUsuario = 1,
                Nome = "Contato Valido",
                Telefones = new List<Telefone> { new Telefone { NumeroTelefone = "2345-6789" } },
                Celulares = new List<Celular> { new Celular { NumeroCelular = "98765-4321" } },
                Emails = new List<Email> { new Email { EnderecoEmail = "email@dominio.com" } },
                Enderecos = new List<Endereco>
                {
                    new Endereco
                    {
                        Logradouro = "Rua Valida",
                        Numero = "100",
                        Cidade = "Cidade Valida",
                        Estado = "Estado Valido",
                        CEP = "00000-000"
                    }
                }
            };

            // Act
            var result = _contatoService.ValidaContato(contato);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(contato, result);
        }
    }
}
