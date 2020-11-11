using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace WebApiClientes.Models
{
    [DataContract]
    public class Endereco : BaseModel
    {
        [DataMember(Name = "logradouro")]
        [Required]
        [MaxLength(50)]
        public string Logradouro { get; private set; }

        [DataMember(Name = "bairro")]
        [Required]
        [MaxLength(40)]
        public string Bairro { get; private set; }

        [DataMember(Name = "cidade")]
        [Required]
        [MaxLength(40)]
        public string Cidade { get; private set; }

        [DataMember(Name = "estado")]
        [Required]
        [MaxLength(40)]
        public string Estado { get; private set; }

        private Endereco() { }

        public static Endereco New(int id, string logradouro, string bairro, string cidade, string estado)
        {
            return new Endereco()
            {
                Id = id,
                Logradouro = logradouro,
                Bairro = bairro,
                Cidade = cidade,
                Estado = estado
            };
        }
    }
}
