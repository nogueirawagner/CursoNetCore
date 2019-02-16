using AutoMapper;
using Core.Application.ViewModels;
using Curso.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Curso.Application.AutoMapper
{
  public class DomainToViewModelMappingProfile : Profile
  {
    public DomainToViewModelMappingProfile()
    {
      CreateMap<Evento, EventoViewModel>();
    }
  }
}
