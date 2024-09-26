using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PolarisContacts.CreateService.Application.Interfaces.Messaging;
using PolarisContacts.CreateService.Application.Interfaces.Services;
using PolarisContacts.Domain;

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
                contato = _contatoService.ValidaContato(contato);

                // Serializa o objeto contato para JSON
                var message = JsonConvert.SerializeObject(contato);

                // Publica a mensagem no RabbitMQ
                _rabbitMqProducer.Publish(message);

                return Ok("Mensagem publicada com sucesso.");
            }
            catch (Exception ex)
            {
                // Tratamento de erro
                return StatusCode(500, $"Erro ao publicar mensagem: {ex.Message}");
            }
        }
    }
}
