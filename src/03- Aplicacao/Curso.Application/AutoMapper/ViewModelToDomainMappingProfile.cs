using AutoMapper;
using Core.Application.ViewModels;
using Curso.Domain.Models;

namespace Curso.Application.AutoMapper
{
  public class ViewModelToDomainMappingProfile : Profile
  {
    public ViewModelToDomainMappingProfile()
    {
      CreateMap<EventoViewModel, Evento>();
    }
  }
}
