namespace PolarisContacts.CreateService.Application.Interfaces.Messaging
{
    public interface IRabbitMqProducer
    {
        void Publish(string message);
    }
}
