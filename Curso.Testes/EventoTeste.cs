using Curso.Domain.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Curso.Testes
{
    [TestClass]
    public class EventoTeste
    {
        [TestMethod]
        [TestCategory("Curso"), TestProperty("Autor", "Wagner")]
        public void TestarNomeEventoInvalido()
        {
            var evento = new Evento();
            evento.Nome = "j";

            Assert.AreEqual(evento.EhValido(), false);
        }
    }
}
