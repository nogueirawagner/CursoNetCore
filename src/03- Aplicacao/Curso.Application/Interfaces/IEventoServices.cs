using Core.Application.ViewModels;
using Curso.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Curso.Application.Interfaces
{
  public interface IEventoServices
  {
    ResponseService Adicionar(EventoViewModel eventoViewModel);
    void Atualizar(EventoViewModel eventoViewModel);
    EventoViewModel PegarPorId(Guid id);
    IEnumerable<EventoViewModel> PegarTodos();
    void Remover(Guid id);
    void Remover(List<Guid> ids);
  }
}
