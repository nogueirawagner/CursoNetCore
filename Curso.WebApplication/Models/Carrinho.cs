using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Curso.WebApplication.Models
{
    public class Carrinho
    {
        public Carrinho(int totalItens, int valorTotal)
        {
            TotalItens = totalItens;
            ValorTotal = valorTotal;

            if (TotalItens > 0 && ValorTotal > 0)
                EhValido = true;
        }
        public Carrinho()
        {

        }
        public int TotalItens { get; set; }
        public int ValorTotal { get; set; }
        public bool EhValido { get; set; }
    }
}
