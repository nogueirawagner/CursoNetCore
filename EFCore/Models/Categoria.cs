using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCore.Models
{
    public class Categoria
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        // Propriedade de navegação do EF.
        public virtual ICollection<Evento> Eventos { get; set; }
    }
}
