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
        #region Propriedades do Evento
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório.")]
        [DisplayName("Nome do Evento")]
        [MaxLength(30, ErrorMessage = "O tamanho máximo é 30")]
        [MinLength(2, ErrorMessage = "O tamanho mínimo é 2")]
        public string Nome { get; set; }

        [DisplayName("Descrição do Evento")]
        [MaxLength(30, ErrorMessage = "O tamanho máximo é 30")]
        [MinLength(2, ErrorMessage = "O tamanho mínimo é 2")]
        public string Descricao { get; set; }

        [Display(Name = "Valor")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        [DataType(DataType.Currency, ErrorMessage = "Moeda em formato inválido")]
        [Required(ErrorMessage = "Preencha o valor")]
        public decimal Valor { get; set; }

        #endregion 

        public int CategoriaId { get; set; }

        //Propriedade de navegação
        public virtual Categoria Categoria { get; set; }
    }
}
