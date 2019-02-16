using System.ComponentModel.DataAnnotations;

namespace Curso.Infra.Identity.Models.AccountViewModels
{
  public class RegisterViewModel
  {
    [Required(ErrorMessage = "O Email deve ser informado.")]
    [DataType(DataType.EmailAddress)]
    [Display(Name = "Email")]
    public string Email { get; set; }

    [Required(ErrorMessage = "A senha deve ser informada.")]
    [StringLength(100, ErrorMessage = "A {0} deve ter no mínimo {2} e no máximo {1} caracteres.", MinimumLength = 6)]
    [DataType(DataType.Password)]
    [Display(Name = "Senha")]
    public string Senha { get; set; }

    [Required(ErrorMessage = "A confirmação de senha deve ser informada.")]
    [DataType(DataType.Password)]
    [Display(Name = "Confirmar senha")]
    [Compare("Senha", ErrorMessage = "As senhas não conferem.")]
    public string ConfirmaSenha { get; set; }
  }
}
