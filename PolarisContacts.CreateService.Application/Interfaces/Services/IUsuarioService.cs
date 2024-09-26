namespace PolarisContacts.CreateService.Application.Interfaces.Services
{
    public interface IUsuarioService
    {
        void ValidaUsuario(string login, string senha);
    }
}