using Curso.Domain.Models.Base;
using FluentValidation;
using System;

namespace Curso.Domain.Models
{
  public class Evento : Entity<Evento>
  {
    public string Nome { get; set; }
    public string Descricao { get; set; }
    public decimal Valor { get; set; }
    public bool Gratuito { get; set; }
    public DateTime DataInicio { get; set; }
    public DateTime DataFim { get; set; }

    public override bool EhValido()
    {
      Validar();
      foreach (var erro in ValidationResult.Errors)
        ValidationErrors.Add(erro.ErrorMessage);

      return ValidationResult.IsValid;
    }

    #region Validaçoes FluentValidator

    private void Validar()
    {
      ValidarNome();
      ValidarValor();
      ValidarDescricao();
      ValidarData();
      ValidationResult = Validate(this);
    }

    private void ValidarNome()
    {
      RuleFor(c => c.Nome)
          .NotEmpty().WithMessage("O nome do evento precisa ser fornecido")
          .Length(2, 150).WithMessage("O nome do evento precisa ter entre 2 e 150 caracteres");
    }

    private void ValidarDescricao()
    {
      RuleFor(c => c.Descricao)
          .Length(2, 150).WithMessage("O nome do evento precisa ter entre 2 e 150 caracteres");
    }

    private void ValidarValor()
    {
      if (!Gratuito)
        RuleFor(c => c.Valor)
            .ExclusiveBetween(1, 50000)
            .WithMessage("O valor deve estar entre 1.00 e 50.000");

      if (Gratuito)
        RuleFor(c => c.Valor)
            .Equal(0).When(e => e.Gratuito)
            .WithMessage("O valor não deve ser diferente de 0 para evento gratuito");
    }

    private void ValidarData()
    {
      RuleFor(c => c.DataInicio)
          .LessThanOrEqualTo(c => c.DataFim)
          .WithMessage("A data de início deve ser menor ou igual que a data do final do evento");

      RuleFor(c => c.DataInicio)
          .GreaterThanOrEqualTo(DateTime.Now)
          .WithMessage("A data de início deve ser maior ou igual a data atual");

      RuleFor(c => c.DataFim)
          .GreaterThanOrEqualTo(DateTime.Now)
          .WithMessage("A data final deve ser maior ou igual a data atual");
    }
    #endregion
  }
}
