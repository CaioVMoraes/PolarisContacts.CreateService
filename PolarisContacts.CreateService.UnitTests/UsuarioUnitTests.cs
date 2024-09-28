using PolarisContacts.CreateService.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PolarisContacts.CreateService.Helpers.Exceptions.CustomExceptions;

namespace PolarisContacts.CreateService.UnitTests
{
    public class UsuarioUnitTests
    {
        private readonly UsuarioService _usuarioService;

        public UsuarioUnitTests()
        {
            _usuarioService = new UsuarioService();
        }

        [Fact]
        public void ValidaUsuario_DeveLancarLoginVazioException_QuandoLoginEhNulo()
        {
            // Arrange
            string login = null;
            string senha = "senhaValida";

            // Act & Assert
            Assert.Throws<LoginVazioException>(() => _usuarioService.ValidaUsuario(login, senha));
        }

        [Fact]
        public void ValidaUsuario_DeveLancarLoginVazioException_QuandoLoginEhVazio()
        {
            // Arrange
            string login = string.Empty;
            string senha = "senhaValida";

            // Act & Assert
            Assert.Throws<LoginVazioException>(() => _usuarioService.ValidaUsuario(login, senha));
        }

        [Fact]
        public void ValidaUsuario_DeveLancarSenhaVaziaException_QuandoSenhaEhNula()
        {
            // Arrange
            string login = "usuarioValido";
            string senha = null;

            // Act & Assert
            Assert.Throws<SenhaVaziaException>(() => _usuarioService.ValidaUsuario(login, senha));
        }

        [Fact]
        public void ValidaUsuario_DeveLancarSenhaVaziaException_QuandoSenhaEhVazia()
        {
            // Arrange
            string login = "usuarioValido";
            string senha = string.Empty;

            // Act & Assert
            Assert.Throws<SenhaVaziaException>(() => _usuarioService.ValidaUsuario(login, senha));
        }

        [Fact]
        public void ValidaUsuario_DeveNaoLancarExcecao_QuandoLoginESenhaSaoValidos()
        {
            // Arrange
            string login = "usuarioValido";
            string senha = "senhaValida";

            // Act & Assert
            // Se não lançar exceção, o teste passará
            _usuarioService.ValidaUsuario(login, senha);
        }
    }
}
