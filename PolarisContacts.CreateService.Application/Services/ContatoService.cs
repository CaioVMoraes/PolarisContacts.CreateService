using PolarisContacts.CreateService.Application.Interfaces.Services;
using PolarisContacts.CrossCutting.Helpers;
using PolarisContacts.Domain;
using static PolarisContacts.CrossCutting.Helpers.Exceptions.CustomExceptions;

namespace PolarisContacts.CreateService.Application.Services
{
    public class ContatoService : IContatoService
    {
        public Contato ValidaContato(Contato contato)
        {
            if (contato.IdUsuario <= 0)
            {
                throw new UsuarioNotFoundException();
            }
            if (string.IsNullOrEmpty(contato.Nome))
            {
                throw new NomeObrigatorioException();
            }

            contato.Ativo = true;

            if (contato.Telefones is not null)
            {
                foreach (var telefone in contato.Telefones)
                {
                    if (!Validacoes.IsValidTelefone(telefone.NumeroTelefone))
                        throw new TelefoneInvalidoException();

                    telefone.Ativo = true;
                }
            }

            if (contato.Celulares is not null)
            {
                foreach (var celular in contato.Celulares)
                {
                    if (!Validacoes.IsValidCelular(celular.NumeroCelular))
                        throw new CelularInvalidoException();

                    celular.Ativo = true;
                }
            }

            if (contato.Emails is not null)
            {
                foreach (var email in contato.Emails)
                {
                    if (!Validacoes.IsValidEmail(email.EnderecoEmail))
                        throw new EmailInvalidoException();

                    email.Ativo = true;
                }
            }

            if (contato.Enderecos is not null)
            {
                foreach (var endereco in contato.Enderecos)
                {
                    if (!Validacoes.IsValidEndereco(endereco))
                        throw new EnderecoInvalidoException();

                    endereco.Ativo = true;
                }
            }

            return contato;
        }
    }
}