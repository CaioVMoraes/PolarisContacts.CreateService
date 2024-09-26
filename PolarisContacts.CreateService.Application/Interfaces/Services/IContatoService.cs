using PolarisContacts.Domain;

namespace PolarisContacts.CreateService.Application.Interfaces.Services
{
    public interface IContatoService
    {
        Contato ValidaContato(Contato contato);
    }
}