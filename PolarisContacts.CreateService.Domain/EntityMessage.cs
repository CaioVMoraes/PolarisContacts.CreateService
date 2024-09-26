using PolarisContacts.CreateService.Domain.Enuns;

namespace PolarisContacts.CreateService.Domain
{
    public class EntityMessage
    {
        public OperationType Operation { get; set; }
        public EntityType EntityType { get; set; }
        public object EntityData { get; set; }
    }
}
