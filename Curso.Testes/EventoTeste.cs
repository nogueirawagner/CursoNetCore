using Curso.Domain.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Curso.Testes
{
    [TestClass]
    public class EventoTeste
    {
        [TestMethod]
        [TestCategory("Curso"), TestProperty("Autor", "Wagner")]
        [Description("Testando o tamanho do nome do evento.")]
        public void TestarNomeEventoInvalido()
        {
            var evento = new Evento();
            evento.Nome = "j";

            var ehValido = evento.EhValido();
            var msg = evento.ValidationErrors;

            var erroNome = msg.Any(s => s == "O nome do evento precisa ter " +
            "entre 2 e 150 caracteres");
            Assert.IsTrue(erroNome);

            Assert.AreEqual(evento.EhValido(), false);
        }
    }
}
