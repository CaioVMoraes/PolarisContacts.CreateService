using Microsoft.AspNetCore.Mvc;
using PolarisContacts.CreateService.Application.Interfaces.Services;
using PolarisContacts.Domain;

namespace PolarisContacts.CreateService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContatoController(ILogger<ContatoController> logger, IContatoService contatoService) : ControllerBase
    {
        private readonly ILogger<ContatoController> _logger = logger;
        private readonly IContatoService _contatoService = contatoService;

        [HttpPost("AddContato")]
        public async Task<bool> AddContato(Contato contato)
        {
            try
            {
                return await _contatoService.AddContato(contato);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
