using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PolarisContacts.CreateService.Application.Interfaces.Messaging;
using PolarisContacts.CreateService.Application.Interfaces.Services;
using PolarisContacts.CreateService.Domain;
using PolarisContacts.CreateService.Domain.Enuns;

namespace PolarisContacts.CreateService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContatoController(ILogger<ContatoController> logger, IContatoService contatoService, IRabbitMqProducer rabbitMqProducer) : ControllerBase
    {
        private readonly ILogger<ContatoController> _logger = logger;
        private readonly IContatoService _contatoService = contatoService;
        private readonly IRabbitMqProducer _rabbitMqProducer = rabbitMqProducer;

        [HttpPost("AddContato")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        public IActionResult AddContato(Contato contato)
        {
            try
            {
                _contatoService.ValidaContato(contato);

                var entityMessage = new EntityMessage
                {
                    Operation = OperationType.Create,
                    EntityType = EntityType.Contato,
                    EntityData = contato
                };

                var message = JsonConvert.SerializeObject(entityMessage);

                _rabbitMqProducer.Publish(message);

                return Ok("Mensagem publicada com sucesso.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao publicar mensagem: {ex.Message}");
            }
        }
    }
}
