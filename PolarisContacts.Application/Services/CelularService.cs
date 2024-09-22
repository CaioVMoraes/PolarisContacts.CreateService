using PolarisContacts.Application.Interfaces.Repositories;
using PolarisContacts.Application.Interfaces.Services;
using PolarisContacts.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using static PolarisContacts.CrossCutting.Helpers.Exceptions.CustomExceptions;

namespace PolarisContacts.Application.Services
{
    public class CelularService(ICelularRepository celularRepository, IContatoService contatoService, IRegiaoService regiaoService) : ICelularService
    {
        private readonly ICelularRepository _celularRepository = celularRepository;
        private readonly IContatoService _contatoService = contatoService;
        private readonly IRegiaoService _regiaoService = regiaoService;

        public async Task AddCelular(Celular celular)
        {
            if (celular == null)
            {
                throw new ArgumentNullException(nameof(celular));
            }

            //await _celularRepository.AddCelular(celular);
        }
    }
}