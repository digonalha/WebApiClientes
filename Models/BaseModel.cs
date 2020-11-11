using System.Runtime.Serialization;

namespace WebApiClientes.Models
{
    [DataContract]
    public abstract class BaseModel
    {
        [DataMember]
        public int Id { get; protected set; }
    }
}
