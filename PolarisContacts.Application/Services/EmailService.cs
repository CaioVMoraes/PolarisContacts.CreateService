using PolarisContacts.Application.Interfaces.Repositories;
using PolarisContacts.Application.Interfaces.Services;
using PolarisContacts.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using static PolarisContacts.CrossCutting.Helpers.Exceptions.CustomExceptions;

namespace PolarisContacts.Application.Services
{
    public class EmailService(IEmailRepository emailRepository, IContatoService contatoService) : IEmailService
    {
        private readonly IEmailRepository _emailRepository = emailRepository;
        private readonly IContatoService _contatoService = contatoService;

        public async Task AddEmail(Email email)
        {
            if (email == null)
            {
                throw new ArgumentNullException(nameof(email));
            }

            //await _emailRepository.AddEmail(email);
        }
    }
}