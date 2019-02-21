using Curso.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace Curso.Infra.Identity.Models
{
  public class AspNetUser : IUser
  {
    private readonly IHttpContextAccessor _accessor;

    public AspNetUser(IHttpContextAccessor accessor)
    {
      _accessor = accessor;
    }

    //public string Nome
    //{
    //  get
    //  {
    //    return _accessor.HttpContext.User.Identity.Name;
    //  }
    //}

    public string Nome => _accessor.HttpContext.User.Identity.Name;

    public IEnumerable<Claim> GetClaimsIdentity()
    {
      return _accessor.HttpContext.User.Claims;
    }

    public Guid GetUserId()
    {
      return IsAuthenticated() ? Guid.Parse(_accessor.HttpContext.User.GetUserId()) : Guid.Empty;
    }

    public bool IsAuthenticated()
    {
      return _accessor.HttpContext.User.Identity.IsAuthenticated;
    }

  }
}
