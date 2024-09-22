using PolarisContacts.Application.Interfaces.Repositories;
using PolarisContacts.Application.Interfaces.Services;
using PolarisContacts.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using static PolarisContacts.CrossCutting.Helpers.Exceptions.CustomExceptions;

namespace PolarisContacts.Application.Services
{
    public class TelefoneService(ITelefoneRepository telefoneRepository, IContatoService contatoService, IRegiaoService regiaoService) : ITelefoneService
    {
        private readonly ITelefoneRepository _telefoneRepository = telefoneRepository;
        private readonly IContatoService _contatoService = contatoService;
        private readonly IRegiaoService _regiaoService = regiaoService;

        public async Task AddTelefone(Telefone telefone)
        {
            if (telefone == null)
            {
                throw new ArgumentNullException(nameof(telefone));
            }

            //await _telefoneRepository.AddTelefone(telefone);
        }
    }
}