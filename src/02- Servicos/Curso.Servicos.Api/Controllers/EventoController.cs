using Core.Application.ViewModels;
using Curso.Application.Interfaces;
using Curso.Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Curso.Servicos.Api.Controllers
{
  [Route("Evento")]
  public class EventoController : BaseController
  {
    private readonly IUser _user;
    private readonly IEventoServices _eventoServices;

    public EventoController(
      IUser user,
      IEventoServices eventoServices
      ):base(user)
    {
      _user = user;
      _eventoServices = eventoServices;
    }

    [Route("adicionar")]
    [HttpPost]
    public IActionResult Adicionar([FromBody] EventoViewModel pEvento)
    {
      if (!ModelState.IsValid) return Response(false, pEvento);
      var evento = _eventoServices.Adicionar(pEvento);
      if(evento.Sucesso)
        return Response(true, evento.Result);
      return Response(false, evento.Result, evento.Erros);
    }
  }
}
