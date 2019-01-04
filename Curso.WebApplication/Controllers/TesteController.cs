using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Curso.WebApplication.Controllers
{
    public class TesteController : Controller
    {
        [Route("")]
        [Route("dashboard/tela-inicial")]
        [Route("dashboard/tela-inicial/{id:int}/{valor:guid}")]
        public IActionResult Index(int id, Guid valor)
        {
            // Lógica

            return RedirectToAction("Teste");
        }

        [HttpGet, HttpPost]
        public IActionResult Teste()
        {
            return View("Index");
        }
    }
}