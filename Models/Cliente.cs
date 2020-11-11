using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

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
        public string Cpf { get; private set; }

        [DataMember(Name = "dataNascimento")]
        [Required]
        public DateTime DataNascimento { get; private set; }

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

        [DataMember(Name = "uf")]
        [Required]
        [MaxLength(2)]
        public string Uf { get; private set; }

        private Cliente() { }

        public static Cliente New(int id, string nome, string cpf, DateTime dataNascimento, string logradouro, string bairro, string cidade, string uf)
        {
            return new Cliente()
            {
                Id = id,
                Nome = nome,
                Cpf = cpf,
                DataNascimento = dataNascimento,
                Logradouro = logradouro,
                Bairro = bairro,
                Cidade = cidade,
                Uf = uf,
            };
        }

        public bool IsValid() => ValidCpf();

        public bool ValidCpf()
        {
            string cpf = Cpf;
            string tempCpf, digito;

            int soma, resto;
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            cpf = cpf.Trim().Replace(".", string.Empty).Replace("-", string.Empty);

            if (cpf.Length != 11)
                return false;

            tempCpf = cpf.Substring(0, 9);
            soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];

            resto = soma % 11;

            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = resto.ToString();
            tempCpf += digito;
            soma = 0;

            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];

            resto = soma % 11;

            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            return cpf.EndsWith(digito + resto.ToString());
        }
    }
}
