using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCore.Data;
using EFCore.Models;
using Microsoft.AspNetCore.Mvc;

namespace EFCore.Controllers
{
    public class PessoaController : Controller
    {
        private readonly EFContext _context;

        public PessoaController(EFContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var evento = new Evento()
            {
                Nome = "WAagner",
                Descricao = "Produto ",
                Valor = 20
            };

            ViewData["Evento"] = evento;

            ViewBag.Eventos = evento;

            var pessoas = _context.Pessoa.ToList();
            return View(pessoas);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Pessoa pessoa)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pessoa);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(pessoa);
        }
    }
}