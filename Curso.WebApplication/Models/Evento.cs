using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Curso.WebApplication.Models
{
    public class Evento
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public bool Gratuito { get; set; }
        public string Descricao { get; set; }
        public DateTime Data { get; set; }
    }
}
