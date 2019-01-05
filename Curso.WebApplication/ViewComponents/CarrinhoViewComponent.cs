using System;
using System.Collections.Generic;
using System.Linq;
using Curso.WebApplication.Models;
using Microsoft.AspNetCore.Mvc;

namespace Curso.WebApplication.ViewComponents
{
    public class CarrinhoViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            // Logica
            var carrinho = new Carrinho()
            {
                TotalItens = 10,
                ValorTotal = 1400
            };
            return View(carrinho);
        }
    }
}
