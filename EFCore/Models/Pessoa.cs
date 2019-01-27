using System.ComponentModel.DataAnnotations;

namespace EFCore.Models
{
    public class Pessoa
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Idade { get; set; }
        public Genero Sexo { get; set; }
        public Endereco Endereco { get; set; }
    }

    public enum Genero
    {
        M,
        F
    }
}
