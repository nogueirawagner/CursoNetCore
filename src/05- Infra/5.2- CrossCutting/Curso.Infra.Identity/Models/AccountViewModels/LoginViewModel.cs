using System.ComponentModel.DataAnnotations;

namespace Curso.Infra.Identity.Models.AccountViewModels
{
  public class LoginViewModel
  {
    [Required(ErrorMessage = "O Email deve ser informado.")]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; }

    [Required(ErrorMessage = "A senha deve ser informada.")]
    [DataType(DataType.Password)]
    public string Senha { get; set; }
  }
}