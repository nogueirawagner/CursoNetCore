using System;
using System.Collections.Generic;
using System.Text;

namespace Curso.Application.Services
{
  public class ResponseService
  {
    public ResponseService(bool pSucesso, object pResult = null, List<string> pErros = null)
    {
      Sucesso = pSucesso;
      Erros = pErros;
      Result = pResult;
    }

    public bool Sucesso { get; set; }
    public List<string> Erros { get; set; }
    public object Result { get; set; }
  }
}
