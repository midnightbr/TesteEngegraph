using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TesteEngegraph.Models
{
    public class Contact
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; }
        [Required]
        public string Cpf { get; set; }
        [Required]
        public string Sexo { get; set; }
        public Types Types { get; set; }
        [Required]
        public int TypesId { get; set; }
        [Required]
        public Boolean Ativo { get; set; } = false;

        public Contact()
        {
        }

        public Contact(int id, string nome, DateTime dataNascimento, string cpf, string sexo, Types types, bool ativo)
        {
            Id = id;
            Nome = nome;
            DataNascimento = dataNascimento;
            Cpf = cpf;
            Sexo = sexo;
            Types = types;
            Ativo = ativo;
        }
    }
}
