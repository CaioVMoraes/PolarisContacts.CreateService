using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PolarisContacts.CreateService.Application.Interfaces.Messaging;
using PolarisContacts.CreateService.Application.Interfaces.Services;
using PolarisContacts.CreateService.Application.Services;
using PolarisContacts.CreateService.Domain;
using PolarisContacts.CreateService.Domain.Enuns;
using PolarisContacts.CreateService.Infrastructure.Messaging;
using PolarisContacts.Domain;

namespace PolarisContacts.CreateService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController(ILogger<UsuarioController> logger, IUsuarioService usuarioService, IRabbitMqProducer rabbitMqProducer) : ControllerBase
    {
        private readonly ILogger<UsuarioController> _logger = logger;
        private readonly IUsuarioService _usuarioService = usuarioService;
        private readonly IRabbitMqProducer _rabbitMqProducer = rabbitMqProducer;

        [HttpPost("CreateUser")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        public IActionResult CreateUser([FromQuery] string login, [FromQuery] string senha)
        {
            try
            {
                // Serializa o objeto contato para JSON
                var entityMessage = new EntityMessage
                {
                    Operation = OperationType.Create,
                    EntityType = EntityType.Usuario,
                    EntityData = new PolarisContacts.CreateService.Domain.Usuario { Login = login, Senha = senha }
                };

                var message = JsonConvert.SerializeObject(entityMessage);

                // Publica a mensagem no RabbitMQ
                _rabbitMqProducer.Publish(message);

                return Ok("Mensagem publicada com sucesso.");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
