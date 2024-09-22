﻿using PolarisContacts.Application.Interfaces.Repositories;
using PolarisContacts.Application.Interfaces.Services;
using PolarisContacts.CrossCutting.Helpers;
using PolarisContacts.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using static PolarisContacts.CrossCutting.Helpers.Exceptions.CustomExceptions;

namespace PolarisContacts.Application.Services
{
    public class ContatoService(IDatabaseConnection dbConnection,
                                IContatoRepository contatoRepository,
                                ITelefoneRepository telefoneRepository,
                                ICelularRepository celularRepository,
                                IEmailRepository emailRepository,
                                IEnderecoRepository enderecoRepository,
                                IRegiaoService regiaoService) : IContatoService
    {
        private readonly IDatabaseConnection _dbConnection = dbConnection;
        private readonly IContatoRepository _contatoRepository = contatoRepository;
        private readonly ITelefoneRepository _telefoneRepository = telefoneRepository;
        private readonly ICelularRepository _celularRepository = celularRepository;
        private readonly IEmailRepository _emailRepository = emailRepository;
        private readonly IEnderecoRepository _enderecoRepository = enderecoRepository;
        private readonly IRegiaoService _regiaoService = regiaoService;

        public async Task<bool> AddContato(Contato contato)
        {
            if (contato.IdUsuario <= 0)
            {
                throw new UsuarioNotFoundException();
            }
            if (string.IsNullOrEmpty(contato.Nome))
            {
                throw new NomeObrigatorioException();
            }

            bool isSucesso = false;
            using IDbConnection connection = _dbConnection.AbrirConexao();

            IDbTransaction transaction = null;
            try
            {
                if (connection is SqlConnection)
                {
                    // Apenas inicie uma transação se estiver usando SQL Server
                    transaction = connection.BeginTransaction();
                }

                contato.Ativo = true;
                contato.Id = await _contatoRepository.AddContato(contato, connection, transaction);

                if (contato.Telefones is not null)
                {
                    foreach (var telefone in contato.Telefones)
                    {
                        if (!Validacoes.IsValidTelefone(telefone.NumeroTelefone))
                            throw new TelefoneInvalidoException();

                        telefone.IdContato = contato.Id;
                        telefone.Ativo = true;

                        telefone.Id = await _telefoneRepository.AddTelefone(telefone, connection, transaction);
                    }
                }

                if (contato.Celulares is not null)
                {
                    foreach (var celular in contato.Celulares)
                    {
                        if (!Validacoes.IsValidCelular(celular.NumeroCelular))
                            throw new CelularInvalidoException();

                        celular.IdContato = contato.Id;
                        celular.Ativo = true;

                        celular.Id = await _celularRepository.AddCelular(celular, connection, transaction);
                    }
                }

                if (contato.Emails is not null)
                {
                    foreach (var email in contato.Emails)
                    {
                        if (!Validacoes.IsValidEmail(email.EnderecoEmail))
                            throw new EmailInvalidoException();

                        email.IdContato = contato.Id;
                        email.Ativo = true;

                        email.Id = await _emailRepository.AddEmail(email, connection, transaction);
                    }
                }

                if (contato.Enderecos is not null)
                {
                    foreach (var endereco in contato.Enderecos)
                    {
                        if (!Validacoes.IsValidEndereco(endereco))
                            throw new EnderecoInvalidoException();

                        endereco.IdContato = contato.Id;
                        endereco.Ativo = true;

                        endereco.Id = await _enderecoRepository.AddEndereco(endereco, connection, transaction);
                    }
                }

                if (transaction != null)
                {
                    transaction.Commit();
                }

                isSucesso = true;
                return isSucesso;
            }
            catch (Exception)
            {
                if (transaction != null)
                {
                    transaction.Rollback();
                }
                throw;
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }
    }
}