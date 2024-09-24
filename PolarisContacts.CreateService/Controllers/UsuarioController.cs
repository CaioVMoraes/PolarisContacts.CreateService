using Microsoft.AspNetCore.Mvc;
using PolarisContacts.CreateService.Application.Interfaces.Services;
using PolarisContacts.CreateService.Application.Services;

namespace PolarisContacts.CreateService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController(ILogger<UsuarioController> logger, IUsuarioService usuarioService) : ControllerBase
    {
        private readonly ILogger<UsuarioController> _logger = logger;
        private readonly IUsuarioService _usuarioService = usuarioService;

        [HttpPost("CreateUser")]
        public async Task<bool> CreateUser([FromQuery] string login, [FromQuery] string senha)
        {
            try
            {
                return await _usuarioService.CreateUser(login, senha);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
