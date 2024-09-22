using PolarisContacts.Application.Interfaces.Repositories;
using PolarisContacts.Application.Interfaces.Services;
using PolarisContacts.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using static PolarisContacts.CrossCutting.Helpers.Exceptions.CustomExceptions;

namespace PolarisContacts.Application.Services
{
    public class EnderecoService(IEnderecoRepository enderecoRepository) : IEnderecoService
    {
        private readonly IEnderecoRepository _enderecoRepository = enderecoRepository;

        public async Task AddEndereco(Endereco endereco)
        {
            if (endereco == null)
            {
                throw new ArgumentNullException(nameof(endereco));
            }

            //await _enderecoRepository.AddEndereco(endereco);
        }
    }
}