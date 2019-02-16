using Curso.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Curso.Servicos.Api.Controllers
{
  [Produces("application/json")]
  public abstract class BaseController : Controller
  {
    protected Guid UsuarioId { get; set; }
    
    protected BaseController(IUser user)
    {
      if (user.IsAuthenticated())
      {
        UsuarioId = user.GetUserId();
      }
    }

    protected new IActionResult Response(bool success, object result = null, object erros = null)
    {
      if (success)
      {
        return Ok(new
        {
          success = true,
          data = result
        });
      }

      return BadRequest(new
      {
        success = false,
        data = result,
        errors = erros
      });
    }
  }
}