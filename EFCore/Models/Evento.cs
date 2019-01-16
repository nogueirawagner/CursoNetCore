using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EFCore.Models
{
    public class Evento
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório.")]
        [DisplayName("Nome do Evento")]
        [MaxLength(30, ErrorMessage = "O tamanho máximo é 30")]
        [MinLength(2, ErrorMessage = "O tamanho mínimo é 2")]
        public string Nome { get; set; }

        public bool Gratuito { get; set; }

        [DisplayName("Descrição do Evento")]
        [MaxLength(30, ErrorMessage = "O tamanho máximo é 30")]
        [MinLength(2, ErrorMessage = "O tamanho mínimo é 2")]
        public string Descricao { get; set; }

        [Range(10, 1000, 
            ErrorMessage = "O valor do evento deve ser entre 10 e 1000")]
        [DisplayName("Valor do Evento")]
        [Required(ErrorMessage = "Preencha o valor")]
        public decimal Valor { get; set; }
    }
}
