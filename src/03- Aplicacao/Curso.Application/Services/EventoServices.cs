using AutoMapper;
using Core.Application.ViewModels;
using Curso.Application.Interfaces;
using Curso.Domain.IRepositories;
using Curso.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Curso.Application.Services
{
  public class EventoServices : IEventoServices
  {
    private readonly IEventoRepository _eventoRepository;
    private readonly IMapper _mapper;

    public EventoServices(
      IEventoRepository eventoRepository, 
      IMapper mapper)
    {
      _eventoRepository = eventoRepository;
      _mapper = mapper;
    }

    public ResponseService Adicionar(EventoViewModel eventoViewModel)
    {
      // Transforma view model em modelo.
      var evento = _mapper.Map<Evento>(eventoViewModel);

      // Adiciona o evento.
      _eventoRepository.Adicionar(evento);

      // Verifica se o modelo é válido.
      if (evento.EhValido())
      {
        _eventoRepository.SaveChanges(); // Faz commit no banco.
        return (new ResponseService(true, eventoViewModel));
      }
      return (new ResponseService(false, eventoViewModel, evento.ValidationErrors));
    }

    public void Atualizar(EventoViewModel eventoViewModel)
    {
      var evento = _mapper.Map<Evento>(eventoViewModel);
      if (evento.EhValido())
      {
        _eventoRepository.Atualizar(evento);
        _eventoRepository.SaveChanges();
      }
    }

    public EventoViewModel PegarPorId(Guid id)
    {
      return _mapper.Map<EventoViewModel>(_eventoRepository.PegarPorId(id));
    }

    public IEnumerable<EventoViewModel> PegarTodos()
    {
      return _mapper.Map<IEnumerable<EventoViewModel>>(_eventoRepository.PegarTodos());
    }

    public void Remover(Guid id)
    {
      var evento = _eventoRepository.PegarPorId(id);
      if (evento != null)
      {
        _eventoRepository.Remover(id);
        _eventoRepository.SaveChanges();
      }
    }

    public void Remover(List<Guid> ids)
    {
      foreach (var id in ids)
      {
        var evento = _eventoRepository.PegarPorId(id);
        if (evento != null)
          _eventoRepository.Remover(id);
      }
      _eventoRepository.SaveChanges();
    }
  }
}
