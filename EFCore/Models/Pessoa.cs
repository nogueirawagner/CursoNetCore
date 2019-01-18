using System.ComponentModel.DataAnnotations;

namespace EFCore.Models
{
    public class Pessoa
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public Genero Sexo { get; set; }
    }

    public enum Genero
    {
        M,
        F
    }
}
