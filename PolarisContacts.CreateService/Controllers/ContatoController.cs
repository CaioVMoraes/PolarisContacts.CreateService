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
        public async Task<bool> AddContato(Contato contato)
        {
            try
            {
                bool isSucess = await _contatoService.AddContato(contato);

                _logger.LogInformation("Publicando mensagem no RabbitMQ para o contato {ContatoId}", contato.Id);
                var message = JsonConvert.SerializeObject(contato);
                _rabbitMqProducer.Publish(message);

                return isSucess;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
