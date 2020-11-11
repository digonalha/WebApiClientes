using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using WebApiClientes.Utilities;

namespace WebApiClientes.Models
{
    [DataContract]
    public class Cliente : BaseModel
    {

        [DataMember(Name = "nome")]
        [Required]
        [MaxLength(30)]
        public string Nome { get; private set; }

        [DataMember(Name = "cpf")]
        [Required]
        [MinLength(11)]
        [MaxLength(11)]
        public string Cpf { get; private set; }

        [DataMember(Name = "dataNascimento")]
        [Required]
        public DateTime DataNascimento { get; private set; }

        private Cliente() { }

        public static Cliente New(int id, string nome, string cpf, DateTime dataNascimento)
        {
            return new Cliente()
            {
                Id = id,
                Nome = nome,
                Cpf = cpf,
                DataNascimento = dataNascimento,
            };
        }

        public int GetIdade()
        {
            DateTime today = DateTime.Today;
            int idade = today.Year - DataNascimento.Year;

            if (DataNascimento.Date > today.AddYears(-idade))
                idade--;

            return idade;
        }

        public bool IsValid() => Cpf.ValidateCpf();


    }
}
