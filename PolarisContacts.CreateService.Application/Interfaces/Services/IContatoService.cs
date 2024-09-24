using PolarisContacts.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PolarisContacts.CreateService.Application.Interfaces.Services
{
    public interface IContatoService
    {
        Task<bool> AddContato(Contato contato);
    }
}